using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riothook.game.offsets
{
    public static class offsets
    {
        public static int enthealth = 0xEC;
        public static int localplayerent = 0x0017E0A8;
        public static int entlist = 0x0018AC04; // 0x4 offset between entities
        public static int entname = 0x77;
        public static int entpos = 0x4;
        public static int entfeetpos = 0x28;
        public static int entviewyaw = 0x34;
        public static int entviewpitch = 0x38;
        public static int entgrounded = 0x5D;
        public static int entteam = 0x1B8;
        public static int entviewmatrix = 0x17DFFC - 0x2C;
    };
}
