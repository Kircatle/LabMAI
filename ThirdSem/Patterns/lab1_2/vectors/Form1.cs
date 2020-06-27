using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vectors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = Convert.ToDouble(textBox1.Text);
                double y1 = Convert.ToDouble(textBox2.Text);
                double z1 = Convert.ToDouble(textBox3.Text);
                double x2 = Convert.ToDouble(textBox4.Text);
                double y2 = Convert.ToDouble(textBox5.Text);
                double z2 = Convert.ToDouble(textBox6.Text);
                GeomVector v1 = new GeomVector(x1, y1, z1);
                GeomVector v2 = new GeomVector(x2, y2, z2);
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        textBox7.Text = (v1 + v2).ToString();
                        break;
                    case 1:
                        textBox7.Text = (v1 - v2).ToString();
                        break;
                    case 2:
                        textBox7.Text = (v1 * v2).ToString();
                        break;
                    case 3:
                        textBox7.Text = GeomVector.scalarMultiplication(v1, v2).ToString();
                        break;
                }
            }
            catch (FormatException)
            {
                DialogResult result = MessageBox.Show("Неверное значение для координат.\nПовторить?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                { }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                }
            }
            catch (OverflowException)
            {

                DialogResult result =  MessageBox.Show("Слишком большой размер координат", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                { }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                }
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 about = new Form2();
            about.Show();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
