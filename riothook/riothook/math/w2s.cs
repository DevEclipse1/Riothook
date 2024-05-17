using riothook.game.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace riothook.math.w2s
{
    public class w2s
    {
        public static Vector2 _w2s(int width, int height, Matrix4x4 mtx, Vector3 pos)
        {
            var td = new Vector2();

            float w = (mtx.M14 * pos.X) + (mtx.M24 * pos.Y) + (mtx.M34 * pos.Z) + mtx.M44;

            if (w > 0.001f)
            {
                float sx = (mtx.M11 * pos.X) + (mtx.M21 * pos.Y) + (mtx.M31 * pos.Z) + mtx.M41;
                float sy = (mtx.M12 * pos.X) + (mtx.M22 * pos.Y) + (mtx.M32 * pos.Z) + mtx.M42;
                float cx = width / 2f;
                float cy = height / 2f;
                float x = cx + (cx * sx / w);
                float y = cy - (cy * sy / w);

                td.X = (int)x + (int)window.windowLocation.X;
                td.Y = (int)y + (int)window.windowLocation.Y;
                return td;
            }
            else
            {
                return new Vector2(-999, -999);
            }
        }
    }
}
