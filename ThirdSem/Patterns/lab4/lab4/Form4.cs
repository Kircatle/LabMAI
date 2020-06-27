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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string site {get; set;}

        private void Button1_Click(object sender, EventArgs e)
        {
            site = (string)comboBox1.Text;
            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
                comboBox1.Items.Add(comboBox1.Text);
        }
    }
}
