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
    public partial class Form1 : Form
    {
        char @operator;
        int operand;
        User user;

        public Form1()
        {
            InitializeComponent();
            user = new User();
        }

        private void OperateButton_Click(object sender, EventArgs e)
        {
            user.Curr = Convert.ToInt32(textBox1.Text);
            operand = Convert.ToInt32(textBox2.Text);
            @operator = Convert.ToChar(textBox3.Text);
            user.Compute(@operator, operand);
            textBox1.Text = user.Curr.ToString();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            user.Undo(1);
            textBox1.Text = user.Curr.ToString();
        }
        private void RedoButton_Click(object sender, EventArgs e)
        {
            user.Redo(1);
            textBox1.Text = user.Curr.ToString();
        }
    }
}
