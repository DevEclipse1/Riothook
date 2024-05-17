using riothook.game.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;
using System.Numerics;
using riothook.game.window;

namespace riothook.hacks.esp
{
    public class esp
    {
        public static void drawTracer(ImDrawListPtr drawlist, entity ent)
        {
            if (ent != null && ent.address != IntPtr.Zero)
            {
                drawlist.AddLine(new Vector2(window.windowLocation.X + window.windowSize.X / 2, window.windowLocation.Y + window.windowSize.Y), ent.feetpos2d, ImGui.ColorConvertFloat4ToU32(globals.tracersColor),1);
            }
        }

        public static void drawBox(ImDrawListPtr drawlist, entity ent)
        {
            if (ent != null && ent.address != IntPtr.Zero)
            {
                Vector2 bottom = ent.feetpos2d;
                Vector2 top = ent.position2d;

                float height = bottom.Y - top.Y;
                float width = height / 2;

                drawlist.AddRect(top - new Vector2(width / 2), new Vector2(top.X + width, top.Y + height), ImGui.ColorConvertFloat4ToU32(globals.tracersColor), 1);
            }
        }

        public static void drawHealthbar(ImDrawListPtr drawlist, entity ent)
        {
            if (ent != null && ent.address != IntPtr.Zero)
            {
                if (ent.health > 0)
                {
                    Vector2 bottom = ent.feetpos2d;
                    Vector2 top = ent.position2d;

                    float height = bottom.Y - top.Y;
                    float width = height / 2;

                    float healthWidth = Math.Min(width, ent.health);

                    drawlist.AddRectFilled(bottom - new Vector2(width / 2, 1), new Vector2(bottom.X - (width / 2) + healthWidth, bottom.Y + 2), ImGui.ColorConvertFloat4ToU32(globals.healthbarColor), 1);
                }
            }
        }
    }
}
