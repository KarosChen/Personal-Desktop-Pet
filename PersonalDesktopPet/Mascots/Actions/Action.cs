using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalDesktopPet.Mascots.Animations;

namespace PersonalDesktopPet.Mascots.Actions
{
    class Action
    {
        private Animation _animation;
        private Pose _nextPose;
        private bool _isFliped = false;
        
        public Animation Animation
        {
            get
            {
                return _animation;
            }
            set
            {
                _animation = value;
            }
        }

        public bool IsFliped
        {
            get
            {
                return _isFliped;
            }
            set
            {
                _isFliped = value;
            }
        }

        public Action()
        {
            string[] typeArray = this.GetType().ToString().Split('.');
            _animation = new Animation(typeArray[typeArray.Length - 1]);
            _nextPose = _animation.DisplayingPose;
        }

        public void Execute()
        {
            _animation.SetNextPose();
            _nextPose = _animation.DisplayingPose;
        }

        public Image GetNextImage()
        {
            if (IsFliped)
            {
                Image flipedImage = (Image)_nextPose.Image.Clone();
                flipedImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                return flipedImage;
            }
            else
            {
                return _nextPose.Image;
            }
        }

        public int GetNextDuration()
        {
            return _nextPose.Duration;
        }

        public int GetVelocityX()
        {
            return _nextPose.VelocityX;
        }

        public int GetVelocityY()
        {
            return _nextPose.VelocityY;
        }

        public Point GetImageAnchor()
        {
            return _nextPose.ImageAnchor;
        }

        public string GetBorderType()
        {
            return _animation.BorderType;
        }
    }
}
