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
        int _imageAnchorX;
        int _imageAnchorY;
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

        public int ImageAnchorX
        {
            get
            {
                return _imageAnchorX;
            }
            set
            {
                _imageAnchorX = value;
            }
        }

        public int ImageAnchorY
        {
            get
            {
                return _imageAnchorY;
            }
            set
            {
                _imageAnchorY = value;
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
