namespace PersonalDesktopPet
{
    partial class desktopPetForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mascotPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mascotPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mascotPictureBox
            // 
            this.mascotPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mascotPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.mascotPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mascotPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mascotPictureBox.Name = "mascotPictureBox";
            this.mascotPictureBox.Size = new System.Drawing.Size(128, 128);
            this.mascotPictureBox.TabIndex = 0;
            this.mascotPictureBox.TabStop = false;
            this.mascotPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mascotPictureBox_MouseDown);
            this.mascotPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mascotPictureBox_MouseMove);
            this.mascotPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mascotPictureBox_MouseUp);
            // 
            // desktopPetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(128, 128);
            this.Controls.Add(this.mascotPictureBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "desktopPetForm";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Olive;
            this.Load += new System.EventHandler(this.desktopPetForm_Load);
            this.LocationChanged += new System.EventHandler(this.desktopPetForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mascotPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mascotPictureBox;
    }
}

