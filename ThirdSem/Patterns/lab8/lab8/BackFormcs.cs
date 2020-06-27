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
    public partial class BackFormcs : Form
    {
        public event EventHandler ApplyHandler;
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public BackFormcs()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeBackButton_Click(object sender, EventArgs e)
        {
            Red = redTrackPad.Value;
            Green = greenTrackPad.Value;
            Blue = blueTrackPad.Value;
            if (ApplyHandler != null)
                ApplyHandler(this, new EventArgs());
        }

        private void BackFormcs_Load(object sender, EventArgs e)
        {

        }
    }
}
