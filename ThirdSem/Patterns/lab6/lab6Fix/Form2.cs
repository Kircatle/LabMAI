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
    public partial class Form2 : Form, IObserver
    {
        private Image carImage;
        private ControllerForm2 controller;
        private Model model;
        public delegate void InvokeRefreshDelegate();

        public Form2(Model model)
        {
            InitializeComponent();
            this.model = model;
            carImage = Properties.Resources.car;
            this.model.Register(this);
            attachController(makeController());

        }
        public void attachController(ControllerForm2 controller)
        {
            this.controller = controller;
        }
        protected ControllerForm2 makeController()
        {
            return new ControllerForm2(this, model);
        }

        public void DrawCar(int x, int y)
        {
            BeginInvoke(new InvokeRefreshDelegate(InvokeRefresh));
            var graphics = CreateGraphics();
            graphics.DrawImage(carImage, x, y);
        }
        public void InvokeRefresh()
        {
            this.Refresh();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            controller.SetCar(Convert.ToDouble(textBox1.Text));
            controller.StartCar();
        }
        public void UpdateState()
        {
            if (controller != null && controller.ConditionCar())
            {
                DrawCar(controller.Path(), 200);
            }
           

        }
    }
}
