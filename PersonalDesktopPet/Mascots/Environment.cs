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
        private Mascot _mascot;

        private Rectangle _screenRectangle;
        private int _monitorCount;
        private Ceiling _ceiling;
        private Floor _floor;
        private Wall _leftWall;
        private Wall _rightWall;
        private List<Wall> _middleWallList;
        
        public Mascot Mascot
        {
            get
            {
                return _mascot;
            }
            set
            {
                _mascot = value;
            }
        }


        //Create all walls(left, right, middle, top, bottom)
        public Environment()
        {
            InitializeEnvironment();
            InitializeMascot();
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
            _leftWall = new Wall(new Point(startingX, startingY), new Point(startingX, singleHeight));
            _rightWall = new Wall(new Point(singleWidth * _monitorCount, startingY), new Point(singleWidth * _monitorCount, singleHeight));
            _middleWallList = new List<Wall>();
           
            for (int i = 1; i <= _monitorCount - 1; i++)
            {
                Wall middleWall = new Wall(new Point(i * singleWidth, startingY), new Point(i * singleWidth, singleHeight));
                _middleWallList.Add(middleWall);
            }
        }
        
        private void InitializeMascot()
        {
            _mascot = new Mascot(new Point(new Random().Next(_screenRectangle.X, _screenRectangle.Width + 1), 0));
        }
    }
}
