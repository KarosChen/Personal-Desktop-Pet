using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using PersonalDesktopPet.Mascots.Actions;


namespace PersonalDesktopPet.Mascots
{
    class Mascot
    {
        private Point _location;
        private Stand _stand;
        private Walk _walk;
        private Falling _falling;
        private Mascots.Actions.Action _executingAction;

        public Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }


        public Mascot(Point initialPoint)
        {
            _location = initialPoint;
            _stand = new Stand();
            _walk = new Walk();
            _falling = new Falling();
            _executingAction = _falling;
            
        }

        public void ExecuteAction()
        {
            _executingAction.Execute();
            _location = new Point(_location.X + _executingAction.GetVelocityX(), _location.Y + _executingAction.GetVelocityY());
        }

        public Image GetNextImage()
        {
            return _executingAction.GetNextImage();
            
        }

        public int GetNextDuration()
        {
            return _executingAction.GetNextDuration();
        }

        public string GetBorderType()
        {
            return _executingAction.GetBorderType();
        }
    }
}
