using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryForLab5;

namespace lab5
{
    public partial class ChooseFactoryForm : Form
    {
        public ChooseFactoryForm()
        {
            InitializeComponent();
        }


        AbstractFactoryAuto factrory;
        DriveForm form;
        private Image carImage;

        private void CarRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            factrory = new FactoryCar();
            carImage = Properties.Resources.car;
        }

        private void TruckRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            factrory = new FactoryTruck();
            carImage = Properties.Resources.truck;
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            form = new DriveForm(factrory, carImage);
            form.ShowDialog();
        }
    }
}
