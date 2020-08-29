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
using PersonalDesktopPet.Mascots;
using MascotActions = PersonalDesktopPet.Mascots.Actions;

namespace PersonalDesktopPet
{
    public partial class desktopPetForm : Form
    {
        private int _mousePreviousX;
        private int _mousePreviousY;
        private bool _isDragging = false;

        private MascotActions.Action _executingAction;
        private Timer _playAnimationTimer;

        public desktopPetForm()
        {
            InitializeComponent();
        }

        private void desktopPetForm_Load(object sender, EventArgs e)
        {
            Mascot mascot = new Mascot();
            _executingAction = mascot.GetExecutingAction();
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
            _playAnimationTimer.Interval = _executingAction.Animation.GiveNextPose().Duration * 50;
            Image displayingImage = _executingAction.Animation.GiveNextPose().Image;

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
        private void mascotPictureBox_MouseDown(object sender, MouseEventArgs mouse)
        {
            if (mouse.Button == MouseButtons.Left)
            {
                _mousePreviousX = mouse.X;
                _mousePreviousY = mouse.Y;
                _isDragging = true;
            }
        }

        private void mascotPictureBox_MouseMove(object sender, MouseEventArgs mouse)
        {
            if (_isDragging)
            {
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
            }
        }

        private void mascotPictureBox_MouseUp(object sender, MouseEventArgs mouse)
        {
            _isDragging = false;
        }
    }
}
