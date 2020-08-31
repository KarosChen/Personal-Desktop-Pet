using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Mascots.Borders
{
    class Ceiling : Border
    {
        public Ceiling(Point startingPoint, Point endingPoint) : base(startingPoint, endingPoint)
        {

        }

        public override bool IsOn(Point mascot)
        {
            if (mascot.Y == 0)
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
