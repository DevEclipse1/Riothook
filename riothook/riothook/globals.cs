using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace riothook
{
    public static class globals
    {
        public static bool esp;

        public static Vector4 tracersColor = new Vector4(1,1,1,1);
        public static bool tracers;

        public static Vector4 boxsColor = new Vector4(1, 1, 1, 1);
        public static bool box;

        public static Vector4 healthbarColor = new Vector4(0, 1, 0, 1);
        public static bool healthbar;

        public static bool aimbot;
        public static float aimbotfov;
        public static float aimbotsmoothness;
        public static int aimbotkey;
        public static bool aimboton;
    }
}
