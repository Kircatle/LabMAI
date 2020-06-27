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
    public partial class ChoosePictureForm : Form
    {
        public string PicturePath { get; private set; }

        public event EventHandler ApplyHandler;

        public ChoosePictureForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChoosePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fb = new OpenFileDialog();
            fb.InitialDirectory = "c:\\";
            if (fb.ShowDialog() == DialogResult.OK)
                PicturePath = fb.FileName;
            pathLabel.Text = $"Путь: {PicturePath}";

        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
                ApplyHandler?.Invoke(this, new EventArgs());
        }
    }
}
