using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

namespace C39
{
    public class Swarm 
    {
        private Particle[] swarm;
        private Random rnd;
        private ArrayList listeners = new ArrayList();
        private Timer timer;
        private int k = 0;
        private int iter;
        private int swarmsize;

        public Swarm()
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 100;
        }
        public double Best
        {
            get
            {
                return swarm[0].BestX;
            }
        }
        

           /// <summary>
        /// Обновление памяти лучшей позиции системы у частицы
        /// </summary>
        /// 

        public void BestUpdate(double value)
        {
            for (int i = 0; i < swarmsize; i++)
                swarm[i].BestX = value;
        }
        
        /// <summary>
        /// Создает рой и привязывает его к переменной
        /// </summary>
        /// <param name="swarmsize"></param>
        /// <param name="distance1"></param>
        /// <param name="distance2"></param>
        /// <param name="function"></param>
        /// <param name="rnd"></param>
       public void AttachSwarm(int swarmsize, double distance1, double distance2, Func<double,double> function, Random rnd)
       {
            this.swarmsize = swarmsize;
            this.rnd = rnd;
            this.swarm = CreateSwarm(swarmsize, distance1, distance2, function, rnd);
        }
        /// <summary>
        /// создание роя(АЛГОРИТМ ОПТИМИЗАЦИИ РОЯ ЧАСТЬ 1: СЛУЧАЙНОЕ РАСПРЕДЕЛЕНИЕ ЧАСТИЦ ПО МНОЖЕСТВУ РЕШЕНИЙ)
        /// </summary>
        public Particle[] CreateSwarm(int swarmsize, double distance1, double distance2, Func<double, double> function, Random rnd)
        {
            swarm = new Particle[swarmsize];
            for (int i = 0; i < swarmsize; i++)
            {
                swarm[i] = new Particle(function, distance1, distance2, rnd);
            }
            BestUpdate(swarm[0].X);
            for (int i = 0; i < swarmsize; i++)
            {
                if (swarm[i].Y > swarm[i].BestY)
                    BestUpdate(swarm[i].X);
            }
            return swarm;
        }

        /// <summary>
        /// обработчик таймера (АЛГОРИТМ ОПТИМИЗАЦИИ РОЯ ЧАСТЬ 2: ОСНОВНАЯ ЧАСТЬ)
        /// </summary>
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            k++;
            if (k >= iter)
            {
                k = 0;
                timer.Stop();
            }
            //Обновление лучших собственных положений точек
            for (int i = 0; i < swarmsize; i++)
            {
                if (swarm[i].Y > swarm[i].BestLocalY) 
                {
                    swarm[i].BestLocalX = swarm[i].X;
                }
            }
            
            //Обновление лучшего положения системы
            for (int i = 0; i < swarmsize; i++)
            {
                if (swarm[i].Y > swarm[i].BestY)
                    BestUpdate(swarm[i].X);
            }

            //Пересчитывание скорости и положения точки
            for (int i = 0; i < swarmsize; i++)
                {
                    var alpha = rnd.NextDouble();
                    var beta = rnd.NextDouble();
                    var gamma = rnd.NextDouble();
                    swarm[i].V = gamma*(swarm[i].V + alpha * (swarm[i].BestLocalX - swarm[i].X) + beta * (swarm[i].BestX - swarm[i].X));
                    swarm[i].X += swarm[i].V;
                }
                UpdateObservers();
        }
        
        /// <summary>
        /// Возвращает все положения точек в данный момент
        /// </summary>
        public List<double[]> Position()
        {
            var condition = new List<double[]>();
            foreach (Particle sw in swarm)
            {
                condition.Add(sw.Position());
            }
            return condition;
        }

        /// <summary>
        /// Запусе таймера
        /// </summary>
        public void StartOptimization(int iter)
        {
            this.iter = iter;
            timer.Enabled = true;
        }
        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void StopOptimization()
        {
            timer.Stop();
        }


        /// <summary>
        /// Методы для подписания/обновления наблюдателей
        /// </summary>
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
