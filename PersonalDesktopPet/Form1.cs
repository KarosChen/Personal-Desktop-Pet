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

namespace PersonalDesktopPet
{
    public partial class desktopPetForm : Form
    {
        public desktopPetForm()
        {
            InitializeComponent();
        }

        private void desktopPetForm_Load(object sender, EventArgs e)
        {
            /*
            FileStream imageStream = File.OpenRead("");
            petPictureBox.Image = Image.FromStream(imageStream);
            imageStream.*/
            Mascot mascot = new Mascot();
            petPictureBox.Image = mascot.Test();
        }
    }
}
