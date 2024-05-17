using riothook.game.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace riothook.game.entities
{
    public class entity
    {
        public IntPtr address {  get; set; }
        public int health { get; set; }
        public Vector3 position { get; set; }
        public Vector2 position2d { get; set; }
        public Vector3 feetpos {  get; set; }
        public Vector2 feetpos2d { get; set; }
        public float distanceFromCrosshair { get; set; }
        public int team { get; set; }

        public bool onscreen()
        {
            if (position2d.X > window.window.windowLocation.X && position2d.Y > window.window.windowLocation.Y && position2d.X < window.window.windowLocation.X + window.window.windowSize.X && position2d.Y < window.window.windowLocation.Y + window.window.windowSize.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
