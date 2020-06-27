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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private double costVizits = 0.08;
        public double vizits { get; set; }
        public double cost { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                costVizits /= 2;
            if (checkBox2.Checked)
                costVizits *= 1.8;
            if (checkBox3.Checked)
                costVizits *= 3;
            vizits = double.Parse(textBox1.Text);
            cost = vizits * costVizits;
            Close();
        }


    }
}
