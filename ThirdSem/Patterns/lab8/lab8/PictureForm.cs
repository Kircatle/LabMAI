using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    
    public partial class PictureForm : Form
    {

        private int pbh, pbw; 
        
        public PictureForm()
        {
            InitializeComponent();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChoosePictureButton_Click(object sender, EventArgs e)
        {
            ChoosePictureForm dialog = new ChoosePictureForm();
            dialog.Owner = this;
            dialog.ApplyHandler += new EventHandler(setPicture);
            dialog.Show();
        }
        private void setPicture(object sender, System.EventArgs e)
        {
            double mh, mw;
            ChoosePictureForm dialog = (ChoosePictureForm)sender;
            this.pictureBox1.Image = Image.FromFile(dialog.PicturePath);
            if ((pictureBox1.Image.Width > pbw) || (pictureBox1.Image.Height > pbh))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                mh = (double)pbh / (double)pictureBox1.Image.Height;
                mw = (double)pbh / (double)pictureBox1.Image.Width;

                if (mh < mw)
                {
                    pictureBox1.Width = Convert.ToInt16(pictureBox1.Image.Width * mh);
                    pictureBox1.Height = pbh;
                }
                else
                {
                    pictureBox1.Width = pbw;
                    pictureBox1.Height = Convert.ToInt16(pictureBox1.Image.Height * mw);
                }
            }
            else
               if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void SetBackButton_Click(object sender, EventArgs e)
        {
            BackFormcs dialog = new BackFormcs();
            dialog.Owner = this;
            dialog.ApplyHandler += new EventHandler(setColour);
            dialog.Show();

        }
        private void setColour(object sender, System.EventArgs e)
        {
            BackFormcs dialog = (BackFormcs)sender;
            this.BackColor = Color.FromArgb(dialog.Red, dialog.Green, dialog.Blue);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void PictureForm_Load(object sender, EventArgs e)
        {
            pbh = pictureBox1.Height;
            pbw = pictureBox1.Width;
        }
    }
}
