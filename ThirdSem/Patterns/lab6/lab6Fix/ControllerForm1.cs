using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6Fix
{
    public class ControllerForm1
    {
        private Car car;
        private Model model;
        private Form1 view;

        public ControllerForm1(Form1 view, Model model)
        {
            this.model = model;
            this.view = view;
        }

        /// <summary>
        /// УСТАНОВИТЬ АВТОМОБИЛЬ
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Speed"></param>
        public void SetCar(string Name, double Speed)
        {
            car = new Car(Name, Speed);
            model.SetCar(car);
        }
        /// <summary>
        /// ЗАПУСК
        /// </summary>
        public void StartCar()
        {
            model.Start = true;
        }
        /// <summary>
        /// СТОП
        /// </summary>
        public void StopCar()
        {
            model.Start = false;
        }
        /// <summary>
        /// ПРОЙДЕННЫЙ ПУТЬ
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
        /// <summary>
        /// ИНФОРМАЦИЯ О МАШИНЕ
        /// </summary>
        /// <returns></returns>
        public string Info()
        {
            return model.CarInfo();
        }
    }
}
