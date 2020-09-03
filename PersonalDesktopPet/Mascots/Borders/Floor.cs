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
            if (mascot.Y >= EndingPoint.Y - 8 && mascot.Y <= EndingPoint.Y )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUnder(Point mascot)
        {
            if (mascot.Y > EndingPoint.Y + 128)
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
