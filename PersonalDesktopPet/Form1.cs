﻿using System;
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
        private System.Timers.Timer _automaticModeTimer;

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
            InitializePlayAnimationTimer();
            InitializeAutomaticModeTimer();
            _playAnimationTimer.Start();
        }

        private void InitializePlayAnimationTimer()
        {
            _playAnimationTimer = new Timer();
            _playAnimationTimer.Tick += null;
            _playAnimationTimer.Tick += new EventHandler(playAnimationTimerTick);
        }

        private void InitializeAutomaticModeTimer()
        {
            _automaticModeTimer = new System.Timers.Timer(4000);
            _automaticModeTimer.Elapsed += new System.Timers.ElapsedEventHandler(automaticModeTimerTick);
        }


        private void playAnimationTimerTick(object sender, EventArgs e)
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

        private void automaticModeTimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            _mascot.IsAutomaticMode = true;
            _mascot.ExecuteAutomaticMode();
        }

        private void desktopPetForm_LocationChanged(object sender, EventArgs e)
        {
            if (_isFalling)
            {
                if (_mascotEnvironment.IsOnFloor(_mascot.ImageAnchorLocation))
                {
                    _mascot.SetAction(Mascots.Mascot.ActionEnum.Stand, false);
                }
                else if (_mascotEnvironment.IsUnderFloor(_mascot.ImageAnchorLocation))
                {
                    this.Top = 0;
                }
            }
            _mascot.Location = new Point(this.Left, this.Top);
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
                _automaticModeTimer.Stop();
                _mascot.IsAutomaticMode = false;
                _isFalling = false;
                //Let mouse locate at (64, 0) in image
                _mousePreviousX = 64;
                _mousePreviousY = 0;
                _isDragging = true;
                //Let mascot stop and execute stand action
                this.Left += (mouse.X - _mousePreviousX);
                this.Top += (mouse.Y - _mousePreviousY);
                _mascot.SetAction(Mascots.Mascot.ActionEnum.Stand, false);
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
            if (_mascotEnvironment.IsOnLeftWall(_mascot.HeadLocation))
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.GrabWall, false);
            }
            else if (_mascotEnvironment.IsOnRightWall(_mascot.HeadLocation))
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.GrabWall, true);
            }
            else if (_mascotEnvironment.IsOnCeiling(_mascot.HeadLocation))
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.GrabCeiling, false);
                Point imageAnchor = _mascot.GetNextImageAnchor();
                Point mascotAnchor = new Point(this.Left, this.Top - imageAnchor.Y);
                _mascot.Location = mascotAnchor;
            }
            else
            {
                _mascot.SetAction(Mascots.Mascot.ActionEnum.Falling, false);
                _isFalling = true;
            }
            _automaticModeTimer.Start();
        }
    }
}
