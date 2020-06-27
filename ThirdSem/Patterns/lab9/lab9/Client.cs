using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Client : Form
    {

        private User user;
        
        public Client()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.Compute('/', Convert.ToInt32(textBox2.Text)).ToString();
            
        }

        private void MultButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.Compute('*', Convert.ToInt32(textBox2.Text)).ToString(); ;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.Compute('-', Convert.ToInt32(textBox2.Text)).ToString(); ;
            
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.Compute('+', Convert.ToInt32(textBox2.Text)).ToString(); ;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            user = new User(Convert.ToInt32(textBox1.Text));
        }
    }
}
