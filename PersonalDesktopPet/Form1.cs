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
    public partial class desktopPetForm : Form
    {
        private int _mousePreviousX;
        private int _mousePreviousY;
        private bool _isDragging = false;

        //private MascotActions.Action _executingAction;
        Mascots.Environment _mascotEnvironment;
        private Timer _playAnimationTimer;

        public desktopPetForm()
        {
            InitializeComponent();
        }

        private void desktopPetForm_Load(object sender, EventArgs e)
        {
            _mascotEnvironment = new Mascots.Environment();
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
            _mascotEnvironment.Mascot.ExecuteAction();
            Image displayingImage = _mascotEnvironment.Mascot.GetNextImage();
            _playAnimationTimer.Interval = _mascotEnvironment.Mascot.GetNextDuration();
            this.Location = _mascotEnvironment.Mascot.Location;
            //The range is a test function to set form and pictureBox width and height 
            this.Width = displayingImage.Width;
            this.Height = displayingImage.Height;
            mascotPictureBox.Width = displayingImage.Width;
            mascotPictureBox.Height = displayingImage.Height;
            mascotPictureBox.Image = displayingImage;
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
                //Let mouse locate at (64, 0) in image
                _mousePreviousX = 64;
                _mousePreviousY = 0;
                _isDragging = true;
                //Let mascot stop and execute stand action
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
                _mascotEnvironment.Mascot.SetAction(Mascots.Mascot.ActionEnum.Stand);
                _mascotEnvironment.Mascot.Location = new Point(this.Left, this.Top);
            }
        }

        private void mascotPictureBox_MouseMove(object sender, MouseEventArgs mouse)
        {
            if (_isDragging)
            {
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
                //Set mascot location
                _mascotEnvironment.Mascot.Location = new Point(this.Left, this.Top);
            }
        }

        private void mascotPictureBox_MouseUp(object sender, MouseEventArgs mouse)
        {
            _isDragging = false;
            if (_mascotEnvironment.IsNotOnBorder())
            {
                _mascotEnvironment.Mascot.SetAction(Mascots.Mascot.ActionEnum.Falling);
                _mascotEnvironment.Mascot.Location = new Point(this.Left, this.Top);
            }
        }
    }
}
