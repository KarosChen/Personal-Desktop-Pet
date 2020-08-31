using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDesktopPet.Mascots.Animations
{
    class Pose
    {
        int _duration;
        int _velocityX;
        int _velocityY;
        Point _imageAnchor;
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

        public int VelocityX
        {
            get
            {
                return _velocityX;
            }
            set
            {
                _velocityX = value;
            }
        }

        public int VelocityY
        {
            get
            {
                return _velocityY;
            }
            set
            {
                _velocityY = value;
            }
        }

        public Point ImageAnchor
        {
            get
            {
                return _imageAnchor;
            }
            set
            {
                _imageAnchor = value;
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
