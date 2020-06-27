using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace lab6Fix
{
    public struct Car
    {
        public double Speed { get; }
        public string Name { get; }
        public int Path { get; set; }

        public Car(string Name, double Speed)
        {
            this.Speed = Speed;
            this.Name = Name;
            Path = 0;
        }
        public override string ToString()
        {
            return $"Название: {this.Name} Скорость: {this.Speed} ";
        }

    }


    public class Model
    {
        private ArrayList listeners = new ArrayList();
        private Car car;
        private bool start;
        private Timer timer;


        public Model()
        {
            start = false;
            timer = new Timer();
            timer.AutoReset = true;
            timer.Enabled = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        /// <summary>
        /// ЗАПУСК ТАЙМЕРА
        /// </summary>
        public bool Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
                if (value)
                {
                    timer.Interval = 130 - car.Speed;
                    timer.Enabled = true;
                    UpdateObservers();
                }
            }
        }
        public bool CarDrive
        {
            get { return timer.Enabled; }
        }

        public void SetCar(Car car)
        {
            this.car = car;
        }
        public int getPath()
        {
            return car.Path;
        }

        /// <summary>
        /// ОБРАБОТЧИК ТАЙМЕРА
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           if (car.Path < 500)
                car.Path += 5;
            if (!Start || car.Path == 500)
            {
                timer.Enabled = false;
            }
            UpdateObservers();
        }
        public string CarInfo()
        {
            return car.ToString();
        }

        /// <summary>
        /// РАБОТА С OBSERVER
        /// </summary>
        /// <param name="o"></param>
        public void Register(IObserver o)
        {
            listeners.Add(o);
            o.UpdateState();
        }

        public void Deregister(IObserver o)
        {
            listeners.Remove(o);
        }
        public void UpdateObservers()
        {
            foreach (IObserver ob in listeners)
            {
                ob.UpdateState();
            }
        }
    }
}
