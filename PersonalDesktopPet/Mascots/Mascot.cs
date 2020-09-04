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
        private Point _headLocation;
        private Point _imageAnchorLocation;
        private Actions.Action _executingAction;
        private List<Actions.Action> _actionList;

        public enum ActionEnum
        {
            Stand,
            Walk,
            Falling,
            GrabWall,
            GrabCeiling
        }


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

        public Point HeadLocation
        {
            get
            {
                int width = _executingAction.GetNextImage().Width;
                _headLocation = new Point(_location.X + width / 2, _location.Y);
                return _headLocation;
            }
            set
            {
                _headLocation = value;
            }
        }

        public Point ImageAnchorLocation
        {
            get
            {
                Point imageAnchor = _executingAction.GetImageAnchor();
                _imageAnchorLocation = new Point(_location.X + imageAnchor.X, _location.Y + imageAnchor.Y);
                return _imageAnchorLocation;
            }
            set
            {
                _imageAnchorLocation = value;
            }
        }

        public Mascot(Point initialPoint)
        {
            _actionList = new List<Actions.Action>();
            _location = initialPoint;
            _actionList.Add(new Stand());
            _actionList.Add(new Walk());
            _actionList.Add(new Falling());
            _actionList.Add(new GrabWall());
            _actionList.Add(new GrabCeiling());
            SetAction(ActionEnum.Falling, false);
        }

        public void SetAction(ActionEnum actionNumber, bool isFliped)
        {
            _executingAction = _actionList[(int)actionNumber];
            _executingAction.IsFliped = isFliped;
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

        public Point GetNextImageAnchor()
        {
            return _executingAction.GetImageAnchor();
        }
    }
}
