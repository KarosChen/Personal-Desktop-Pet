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

        public Action()
        {
            string[] typeArray = this.GetType().ToString().Split('.');
            _animation = new Animation(typeArray[typeArray.Length - 1]);
        }

        public void Execute()
        {
            _nextPose = _animation.GetNextPose();
        }

        public Image GetNextImage()
        {
            return _nextPose.Image;
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
