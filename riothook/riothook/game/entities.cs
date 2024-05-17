using Swed32;
using System;
using System.Collections.Concurrent;
using System.Numerics;
using riothook.game.offsets;
using riothook.game.viewmatrix;
using riothook.math.w2s;
using riothook.game.window;

namespace riothook.game.entities
{
    public class entities
    {
        public static Swed memory = new Swed("ac_client");
        public static IntPtr game;

        public static ConcurrentQueue<entity> entitylist = new ConcurrentQueue<entity>();
        public static entity localplayer = new entity();

        private static void updateEntity(entity ent)
        {
            ent.health = memory.ReadInt(ent.address, offsets.offsets.enthealth);
            ent.position = memory.ReadVec(ent.address, offsets.offsets.entpos);
            ent.position2d = w2s._w2s((int)window.window.windowSize.X, (int)window.window.windowSize.Y, readmtx.mtx, ent.position);
            ent.feetpos = memory.ReadVec(ent.address, offsets.offsets.entfeetpos);
            ent.feetpos2d = w2s._w2s((int)window.window.windowSize.X, (int)window.window.windowSize.Y, readmtx.mtx, ent.feetpos);
            ent.distanceFromCrosshair = Vector2.Distance(new Vector2(window.window.windowLocation.X + window.window.windowSize.X / 2, window.window.windowLocation.Y + window.window.windowSize.Y / 2), ent.position2d);
            ent.team = memory.ReadInt(ent.address, offsets.offsets.entteam);
        }

        public static void updateEntities()
        {
            ConcurrentQueue<entity> newEntityList = new ConcurrentQueue<entity>();
            List<entity> entityList = new List<entity>();

            for (int i = 0; i < 17; i++)
            {
                IntPtr newent = memory.ReadPointer(game, offsets.offsets.entlist, i * 0x4);
                entity ent = new entity();
                ent.address = newent;
                updateEntity(ent);
                if (ent.health > 0 && ent.health < 101 && ent.position != Vector3.Zero && ent.feetpos != Vector3.Zero)
                {
                    entityList.Add(ent);
                }
            }

            entityList.Sort((ent1, ent2) => ent1.distanceFromCrosshair.CompareTo(ent2.distanceFromCrosshair));

            foreach (var ent in entityList)
            {
                newEntityList.Enqueue(ent);
            }

            entitylist = newEntityList;
        }

        public static void updateLocalplayer()
        {
            localplayer.address = memory.ReadPointer(game, offsets.offsets.localplayerent);
            updateEntity(localplayer);
        }
    }
}
