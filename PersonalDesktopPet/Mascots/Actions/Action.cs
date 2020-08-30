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

        public Image GetNextImage()
        {
            _nextPose = _animation.GetNextPose();
            return _nextPose.Image;
        }

        public int GetNextDuration()
        {
            return _nextPose.Duration;
        }
    }
}
