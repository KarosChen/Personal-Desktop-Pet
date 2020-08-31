using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Mascots.Borders
{
    class LeftWall : Border
    {
        public LeftWall(Point startingPoint, Point endingPoint) : base(startingPoint, endingPoint)
        {

        }

        public override bool IsOn(Point mascot)
        {
            if (mascot.X == StartingPoint.X && mascot.Y < EndingPoint.Y - 128 && mascot.Y > 0)
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
