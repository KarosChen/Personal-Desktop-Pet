using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalDesktopPet.Animations;

namespace PersonalDesktopPet.Actions
{
    class Action
    {
        private Animation _animation;
        
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
            Animation = new Animation(typeArray[typeArray.Length - 1]);
        }
    }
}
