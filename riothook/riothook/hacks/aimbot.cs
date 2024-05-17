using riothook.game.entities;
using riothook.math;
using System;
using System.Diagnostics;
using System.Numerics;
using Swed32;
using riothook.game.offsets;

namespace riothook.hacks
{
    public class aimbot
    {
        private static float smoothness = 0;
        private static Vector2 targetAngle = Vector2.Zero;
        private static Stopwatch stopwatch = new Stopwatch();
        private static float deltaTime = 0;

        public static void _aimbot(Swed memory, IntPtr client)
        {
            // Calculate deltaTime
            deltaTime = (float)stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            if (entities.entitylist.TryPeek(out entity ent))
            {
                if (ent.distanceFromCrosshair <= globals.aimbotfov)
                {
                    targetAngle = calcangle._calcangle(entities.localplayer, ent);

                    // Gradually increase smoothness based on deltaTime
                    smoothness = Math.Min(smoothness + ((globals.aimbotsmoothness / 1000) * deltaTime), 1.0f);

                    Vector2 currentAngle = new Vector2(
                        memory.ReadFloat(entities.localplayer.address, offsets.entviewyaw), // yaw
                        memory.ReadFloat(entities.localplayer.address, offsets.entviewpitch) // pitch
                    );

                    // Perform linear interpolation
                    Vector2 smoothedAngle = Vector2.Lerp(currentAngle, targetAngle, smoothness);

                    // Write back smoothed angle to memory
                    memory.WriteFloat(entities.localplayer.address, offsets.entviewyaw, smoothedAngle.X);
                    memory.WriteFloat(entities.localplayer.address, offsets.entviewpitch, smoothedAngle.Y);
                }
                else
                {
                    // Reset smoothness if target is out of range
                    smoothness = 0;
                }
            }
        }
    }
}
