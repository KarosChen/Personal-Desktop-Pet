using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MascotActions = PersonalDesktopPet.Mascots.Actions;
using Mascots = PersonalDesktopPet.Mascots;

namespace PersonalDesktopPet
{
    public partial class desktopPetForm : TransparentForm
    {
        private int _mousePreviousX;
        private int _mousePreviousY;
        private bool _isDragging = false;
        private bool _isFalling = false;

        Mascots.Environment _mascotEnvironment;
        Mascots.Mascot _mascot;
        private Timer _playAnimationTimer;

        public desktopPetForm()
        {
            this.AddBackgroundImage(new Bitmap(128, 128));
            InitializeComponent();
        }

        private void desktopPetForm_Load(object sender, EventArgs e)
        {
            _mascotEnvironment = new Mascots.Environment();
            _mascot = new Mascots.Mascot(new Point(new Random().Next(_mascotEnvironment.ScreenRectangle.X, _mascotEnvironment.ScreenRectangle.Width + 1), 0));
            _isFalling = true;
            InitializeTimer();
            _playAnimationTimer.Start();
        }

        private void InitializeTimer()
        {
            _playAnimationTimer = new Timer();
            _playAnimationTimer.Tick += null;
            _playAnimationTimer.Tick += new EventHandler(TimerTick);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _mascot.ExecuteAction();
            Image displayingImage = _mascot.GetNextImage();
            _playAnimationTimer.Interval = _mascot.GetNextDuration();
            this.Location = _mascot.Location;
            //The range is a test function to set form and pictureBox width and height 
            this.Width = displayingImage.Width;
            this.Height = displayingImage.Height;
            mascotPictureBox.Width = displayingImage.Width;
            mascotPictureBox.Height = displayingImage.Height;
            mascotPictureBox.Image = displayingImage;
        }

        private void desktopPetForm_LocationChanged(object sender, EventArgs e)
        {
            if (_isFalling)
            {
                Point imageAnchor = _mascot.GetNextImageAnchor();
                Point mascotAnchor = new Point(_mascot.Location.X + imageAnchor.X, _mascot.Location.Y + imageAnchor.Y);
                if (_mascotEnvironment.IsOnFloor(mascotAnchor))
                {
                    _mascot.SetAction(Mascots.Mascot.ActionEnum.Stand);
                }
            }
        }

        /// <summary>
        /// Make image can be dragged and moved 
        /// </summary>
        /// <param name="sender"> mascotPictureBox </param>
        /// <param name="mouse"> mascotEvent </param>
        /// mouse X and Y is referenced to location of Form
        /// 
        private void mascotPictureBox_MouseDown(object sender, MouseEventArgs mouse)
        {
            if (mouse.Button == MouseButtons.Left)
            {
                _isFalling = false;
                //Let mouse locate at (64, 0) in image
                _mousePreviousX = 64;
                _mousePreviousY = 0;
                _isDragging = true;
                //Let mascot stop and execute stand action
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
                _mascot.SetAction(Mascots.Mascot.ActionEnum.Stand);
                _mascot.Location = new Point(this.Left, this.Top);
            }
        }

        private void mascotPictureBox_MouseMove(object sender, MouseEventArgs mouse)
        {
            if (_isDragging)
            {
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
                //Set mascot location
                _mascot.Location = new Point(this.Left, this.Top);
            }
        }

        private void mascotPictureBox_MouseUp(object sender, MouseEventArgs mouse)
        {
            _isDragging = false;
            if (_mascotEnvironment.IsNotOnBorder(Point.Add(_mascot.Location, new Size(64, 0))))
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.Falling);
                _mascot.Location = new Point(this.Left, this.Top);
                _isFalling = true;
            }
            else if (_mascotEnvironment.IsOnLeftWall(Point.Add(_mascot.Location, new Size(64, 0))))
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.GrabWall);
                _mascot.Location = new Point(this.Left, this.Top);
            }
        }
    }
}
