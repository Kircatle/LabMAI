using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList data;
        MoneySite money;

        private void Form1_Load(object sender, EventArgs e)
        {
            data = new ArrayList();
            groupBox2.Enabled = !groupBox2.Enabled;
            groupBox3.Enabled = !groupBox3.Enabled;
            ToolTip tool1 = new ToolTip();
            ToolTip tool2 = new ToolTip();
            ToolTip tool3 = new ToolTip();
            tool1.SetToolTip(trackBar1, "увелечение/уменьшение шрифта");
            tool2.SetToolTip(trackBar2, "увелечение/уменьшение шрифта");
            tool3.SetToolTip(comboBox1, "Чтобы внести фамилию нажмите 2 раза");
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = !groupBox2.Enabled;
        }


        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = !groupBox3.Enabled;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
                comboBox1.Items.Add(comboBox1.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            double costVizits = 0.08;
            textBox3.Text = "";
            if (radioButton1.Checked)
            {
                if (!checkBox1.Checked)
                    costVizits /= 2;
                if (checkBox2.Checked)
                    costVizits *= 1.8;
                if (checkBox3.Checked)
                    costVizits *= 3;

                money = new Revenue(comboBox1.Text, Convert.ToDouble(textBox1.Text), costVizits);
            }
            if (radioButton2.Checked)
            {
                money = new Cost(comboBox1.Text, Convert.ToDouble(textBox2.Text));
            }

            data.Add(money);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                money = (MoneySite)data[i];
                if (money.GetType().Name == "Revenue")
                    listBox1.Items.Add(money.info());
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                money = (MoneySite)data[i];
                if (money.GetType().Name == "Cost")
                    listBox2.Items.Add(money.info());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double s = 0;
            for (int i = 0; i < data.Count; i++)
            {
                money = (MoneySite)data[i];
                s += money.sum();
            }
            textBox3.Text = string.Format("{0:f2}", s);
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            listBox1.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            listBox2.Font = new Font("Microsoft Sans Serif", trackBar2.Value);
        }
    }
}
