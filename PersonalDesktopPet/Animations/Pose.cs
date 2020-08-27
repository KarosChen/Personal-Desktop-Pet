using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Animations
{
    class Pose
    {
        int _duration;
        int _xVelocity;
        int _yVelocity;
        Image _image;

        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public int XVelocity
        {
            get
            {
                return _xVelocity;
            }
            set
            {
                _xVelocity = value;
            }
        }

        public int YVelocity
        {
            get
            {
                return _yVelocity;
            }
            set
            {
                _yVelocity = value;
            }
        }

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
    }
}
