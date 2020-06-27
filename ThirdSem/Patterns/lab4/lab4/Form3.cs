using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public double cost { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            cost = -double.Parse(textBox2.Text);
            Close();
        }
    }
}
