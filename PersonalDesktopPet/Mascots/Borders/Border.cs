using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Mascots.Borders
{
    abstract class Border
    {
        private Point _startingPoint;
        private Point _endingPoint;

        public Point StartingPoint
        {
            get
            {
                return _startingPoint;
            }
            set
            {
                _startingPoint = value;
            }
        }

        public Point EndingPoint
        {
            get
            {
                return _endingPoint;
            }
            set
            {
                _endingPoint = value;
            }
        }

        public Border(Point startingPoint, Point endingPoint)
        {
            _startingPoint = startingPoint;
            _endingPoint = endingPoint;
        }

        abstract public bool IsOn(Point mascotAnchor);
    }
}
