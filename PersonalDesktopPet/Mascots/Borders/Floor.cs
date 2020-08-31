using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Mascots.Borders
{
    class Floor : Border
    {
        public Floor(Point startingPoint, Point endingPoint) : base(startingPoint, endingPoint)
        {

        }

        public override bool IsOn(Point mascot)
        {
            if (mascot.Y >= EndingPoint.Y - 128 && mascot.Y < EndingPoint.Y - 64)
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
