using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace C39
{
    public partial class View : Form, IObserver
    {

        delegate void InvokeC();
        delegate void InvokeD(DataPoint dp);
        delegate void InvokeL(double[] poi);
        delegate void InvokeS(double poi);
        private Langueage lform;
        private About aform;
        private Swarm model;
        Controller controller;
        Func<double, double> function;
        int condition = 0;
        public View()
        {
            aform = new About();
            lform = new Langueage(this, aform);
            InitializeComponent();
            model = new Swarm();
            attachController(makeController());
            model.Register(this);
            this.t1 = new ToolTip();
            this.t2 = new ToolTip();
            this.t3 = new ToolTip();
            this.t4 = new ToolTip();
            t1.SetToolTip(label2, "Диапазон X");
            t2.SetToolTip(textBox4, "Например: x^2, sin(x), cos(x), tan(x), ctg(x)");
            t3.SetToolTip(textBox5, "Количество частиц, которые будут искать глобальный максимум функции");
            t4.SetToolTip(textBox3, "Сколько раз выполнить алгоритм");


        }
        public void attachController(Controller controller)
        {
            this.controller = controller;
        }
        protected Controller makeController()
        {
            return new Controller(this, model);
        }

        private void InvokeClear()
        {
            chart1.Series[1].Points.Clear();
        }
        private void InvokeAdd(DataPoint dp)
        {
            chart1.Series[1].Points.Add(dp);
        }
        private void InvokeList(double[] par)
        {
            listBox1.Items.Add($"X = {par[0]}");
        }
        private void InvokeLis(double par)
        {
            listBox1.Items.Add($"Best X = {par}");
        }
        private void Lclear()
        {
            listBox1.Items.Clear();
        }
        private void DrawGraphic(Func<double,double> func)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(textBox1.Text);
            chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(textBox2.Text);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Abs(func(Convert.ToInt32(textBox2.Text)));
            chart1.ChartAreas[0].AxisY.Minimum = -Math.Abs(func(Convert.ToInt32(textBox1.Text)));

            for (int i = Convert.ToInt32(textBox1.Text); i <= Convert.ToInt32(textBox2.Text); i++)
            {

                chart1.Series[0].Points.AddXY(i, func(i));
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        { 
            function = controller.CreateFunction(textBox4.Text);
            DrawGraphic(function);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            List<double[]> pos = new List<double[]>();
            double best;
            controller.CreateSwarm(Convert.ToInt32(textBox5.Text), Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text),function);
            pos = controller.Position();
            best = controller.Best();
            DrawParticle(pos, best); 
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            controller.StartOptimization(Convert.ToInt32(textBox3.Text));
        }

        public void UpdateState()
        {
            if (condition != 0 )
            {
                var pos = model.Position();
                DrawParticle(pos, model.Best);
            }
            else
            {
                condition++;
            }
        }
        private void DrawParticle(List<double[]> pos, double Best)
        {
            chart1.BeginInvoke(new InvokeC(InvokeClear));
            listBox1.BeginInvoke(new InvokeC(Lclear));
            listBox1.BeginInvoke(new InvokeS(InvokeLis), Best);
            foreach (double[] par in pos)
            {
                DataPoint dp = new DataPoint(par[0], par[1]);
                dp.MarkerStyle = MarkerStyle.Circle;
                chart1.BeginInvoke(new InvokeD(InvokeAdd), dp);
                listBox1.BeginInvoke(new InvokeL(InvokeList), par);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            controller.Stop();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            lform.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            aform.ShowDialog();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
                                                                                                                                                                        
        }
    }
}

