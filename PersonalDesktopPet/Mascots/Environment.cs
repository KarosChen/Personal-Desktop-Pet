using PersonalDesktopPet.Mascots.Borders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PersonalDesktopPet.Mascots
{
    class Environment
    {
        private Rectangle _screenRectangle;
        private int _monitorCount;
        private Ceiling _ceiling;
        private Floor _floor;
        private LeftWall _leftWall;
        private RightWall _rightWall;
        private List<Border> _middleWallList;

        public Rectangle ScreenRectangle
        {
            get
            {
                return _screenRectangle;
            }
            set
            {
                _screenRectangle = value;
            }
        }

        //Create Walls and Mascot
        public Environment()
        {
            InitializeEnvironment();
        }

        private void InitializeEnvironment()
        {
            _screenRectangle = SystemInformation.VirtualScreen;
            _monitorCount = SystemInformation.MonitorCount;

            int startingX = _screenRectangle.X;
            int startingY = _screenRectangle.Y;
            int singleWidth = _screenRectangle.Width / _monitorCount;
            int singleHeight = _screenRectangle.Height;
            

            _ceiling = new Ceiling(new Point(startingX, startingY), new Point(singleWidth * _monitorCount, startingY));
            _floor = new Floor(new Point(startingX, singleHeight), new Point(singleWidth * _monitorCount, singleHeight));
            _leftWall = new LeftWall(new Point(startingX, startingY), new Point(startingX, singleHeight));
            _rightWall = new RightWall(new Point(singleWidth * _monitorCount, startingY), new Point(singleWidth * _monitorCount, singleHeight));
            _middleWallList = new List<Border>();
           
            for (int i = 1; i <= _monitorCount - 1; i++)
            {
                RightWall rightMiddleWall = new RightWall(new Point(i * singleWidth, startingY), new Point(i * singleWidth, singleHeight));
                LeftWall leftMiddleWall = new LeftWall(new Point(i * singleWidth, startingY), new Point(i * singleWidth, singleHeight));
                _middleWallList.Add(rightMiddleWall);
                _middleWallList.Add(leftMiddleWall);
            }
        }

        public bool IsOnFloor(Point location)
        {
            return _floor.IsOn(location);
        }

        public bool IsOnLeftWall(Point location)
        {
            return _leftWall.IsOn(location);
        }

        public bool IsOnRightWall(Point location)
        {
            return _rightWall.IsOn(location);
        }

        public bool IsOnCeiling(Point location)
        {
            return _ceiling.IsOn(location);
        }

        public bool IsUnderFloor(Point location)
        {
            return _floor.IsUnder(location);
        }
    }
}
