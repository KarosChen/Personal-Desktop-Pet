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
            this.petPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.petPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // petPictureBox
            // 
            this.petPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.petPictureBox.Location = new System.Drawing.Point(0, 0);
            this.petPictureBox.Name = "petPictureBox";
            this.petPictureBox.Size = new System.Drawing.Size(799, 450);
            this.petPictureBox.TabIndex = 0;
            this.petPictureBox.TabStop = false;
            // 
            // desktopPetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.petPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "desktopPetForm";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.desktopPetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.petPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox petPictureBox;
    }
}

