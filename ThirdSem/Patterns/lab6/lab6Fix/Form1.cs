using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6Fix
{
    public partial class Form1 : Form, IObserver
    {
        private Image carImage;
        private ControllerForm1 controller;
        private Model model;
        public delegate void InvokeRefreshDelegate();
        public delegate void InvokeChangeListBoxDelegate(string carinfo, string time);
        private int timeElapsed;

        public Form1(Model model)
        {
            InitializeComponent();
            this.model = model;
            carImage = Properties.Resources.car;
            this.model.Register(this);
            attachController(makeController());
        }

        /// <summary>
        /// ПРИСВАНИЕВАНИЕ КОНТРОЛЛЕРА
        /// </summary>
        /// <param name="controller"></param>
        public void attachController(ControllerForm1 controller) 
        {
            this.controller = controller;
        }
        
        /// <summary>
        /// СОЗДАНИЕ КОНТРОЛЛЕРА
        /// </summary>
        /// <returns></returns>
        protected ControllerForm1 makeController()
        {
            return new ControllerForm1(this, model);
        }
        
        public void InvokeRefresh()
        {
            Refresh();
        }
        public void InvokeChangeListBox(string carinfo, string time)
        {
            listBox1.Items.Add(carinfo + " " + time);
        }
        
        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            speedTrackBarLabel.Text = String.Format("Скорость: {0}", speedTrackBar.Value);
        }

        /// <summary>
        /// ЗАПУСК МАШИНЫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            controller.StartCar();
            textBox1.Text = "0";
        }

        /// <summary>
        /// ОСТАНОВИТЬ МАШИНУ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            controller.StopCar();
        }
        private void AcceptBox_Click(object sender, EventArgs e)
        {
            controller.SetCar(nameCarTextBox.Text, speedTrackBar.Value);
        }
         public void DrawCar(int x, int y)
        {
            BeginInvoke(new InvokeRefreshDelegate(InvokeRefresh));
            var graphics = CreateGraphics();
            graphics.DrawImage(carImage, x, y);
        }

        /// <summary>
        /// ОБНОВЛЕНИЕ ФОРМЫ
        /// </summary>
        public void UpdateState()
        {
            if (controller != null)
            {
                if (controller.ConditionCar())
                {
                    DrawCar(controller.Path(), 200);
                }
    
                if (controller.ConditionCar() && !timer1.Enabled)
                {

                    timeElapsed = 0;
                    timer1.Start();
                    timer1.Interval = 1000;
                }
                else if (!controller.ConditionCar())
                {

                    timeElapsed = 0;
                    timer1.Stop();
                    listBox1.BeginInvoke(new InvokeChangeListBoxDelegate(InvokeChangeListBox), controller.Info(), "Время:"+textBox1.Text);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed += 1000;
            textBox1.Text = String.Format("{0}", timeElapsed / 1000);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
