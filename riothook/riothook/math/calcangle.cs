using riothook.game.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace riothook.math
{
    public class calcangle
    {
        public static Vector2 _calcangle(entity localplayer,entity entity)
        {
            float x, y;
            var dx = entity.position.X - localplayer.position.X;
            var dy = entity.position.Y - localplayer.position.Y;
            x = (float)(Math.Atan2(dy, dx) * 180 / Math.PI) + 90;
            float dz = entity.position.Z - localplayer.position.Z;
            float dist = Vector3.Distance(localplayer.position, entity.position);
            y = (float)(Math.Atan2(dz, dist) * 180 / Math.PI);
            return new Vector2(x, y);
        }
    }
}
