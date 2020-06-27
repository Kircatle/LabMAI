using System;
using System.Windows.Forms;
using libraryForLab5;
using System.Drawing;
using System.Threading;

namespace lab5
{
    public partial class DriveForm : System.Windows.Forms.Form
    {
        AbstractFactoryAuto factory;
        private Image carImage;
        private int pause = 500;
        public DriveForm(AbstractFactoryAuto factory, Image carImage)
        {
            InitializeComponent();
            this.factory = factory;
            this.carImage = carImage;
        }

        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            speedLabel.Text = speedTrackBar.Value.ToString();
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            var speed = speedTrackBar.Value;
            var auto = new ClientAuto(factory);
            auto.Moved += AutoMoved; 
            auto.Start(speed);  
        }


        /// <summary>
        /// Обработчик события auto.Moved
        /// </summary>
        private void AutoMoved(object sender, double e)
        {
            Refresh();
            var y = 100;
            var x = (int)e;
            var graphics = CreateGraphics();
            graphics.DrawImage(carImage, x, y);
            pathLabel.Text = $"{x}";
            Thread.Sleep(pause);
        }
    }
}
