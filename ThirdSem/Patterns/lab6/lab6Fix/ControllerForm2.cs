using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6Fix
{
    public class ControllerForm2
    {
        private Car car;
        private Model model;
        private Form2 view;

        public ControllerForm2(Form2 view, Model model)
        {
            this.model = model;
            this.view = view;
        }

        /// <summary>
        /// УСТАНОВИТЬ АВТОМОБИЛЬ
        /// </summary>
        /// <param name="Speed"></param>
        public void SetCar(double Speed)
        {
            car = new Car("tmp", Speed);
            model.SetCar(car);
        }

        /// <summary>
        /// ЗАПУСК МАШИНЫ
        /// </summary>
        public void StartCar()
        {
            model.Start = true;
        }

        /// <summary>
        /// ПУТЬ
        /// </summary>
        /// <returns></returns>
        public int Path()
        {
            return model.getPath();
        }

        /// <summary>
        /// СОСТОЯНИЕ МАШИНЫ
        /// </summary>
        /// <returns></returns>
        public bool ConditionCar()
        {
            return model.CarDrive;
        }
    }
}
