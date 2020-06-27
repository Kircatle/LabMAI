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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 revForm;     
        Form3 costForm;      
        Form4 siteForm;     

        private void СайтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            siteForm = new Form4();
            siteForm.ShowDialog();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            revForm = new Form2();
            revForm.ShowDialog();
            dataGridView1.Rows.Insert(0, 1);
            dataGridView1[0, 0].Value = siteForm.site;
            dataGridView1[1, 0].Value = revForm.cost;
            dataGridView1[2, 0].Value = revForm.vizits;

        }
        private void ДанныеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            costForm = new Form3();
            costForm.ShowDialog();
            dataGridView2.Rows.Insert(0, 1);
            dataGridView2[0, 0].Value = siteForm.site;
            dataGridView2[1, 0].Value = costForm.cost;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "Вебсайт");
            dataGridView1.Columns.Add("", "Доход");
            dataGridView1.Columns.Add("", "Посетители");

            dataGridView2.Columns.Add("", "Вебсайт");
            dataGridView2.Columns.Add("", "Расход");
        }

        private void ПрибыльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double s = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                s = s + (double)(dataGridView1[1, i].Value);
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                s = s + (double)(dataGridView2[1, i].Value);
            MessageBox.Show(string.Format("{0:f2}", s), "Итоговая сумма");
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            siteForm = new Form4();
            siteForm.ShowDialog();
        }
    }
}
