using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C39
{
    public class Particle
    {
        public Func<double, double> Function { get; set; }
        private Random rnd;
        private double distanse1, distanse2;

        public Particle(Func<double, double> function, double distanse1, double distanse2, Random rnd)
        {
            this.distanse1 = distanse1;
            this.distanse2 = distanse2;
            this.rnd = rnd;
            X = rnd.NextDouble(distanse1, distanse2);
            BestLocalX = X;
            V = rnd.NextDouble();
            this.Function = function;
        }
        /// <summary>
        /// Лучший x, который нашел рой
        /// </summary>
        public double BestX { get; set; }

        /// <summary>
        /// X в настоящий момент
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Лучший X, который находила эта точка
        /// </summary>
        public double BestLocalX { get; set; }

        /// <summary>
        /// Скорость
        /// </summary>
        public double V { get; set; }

        /// <summary>
        /// Функция от X
        /// </summary>
        public double Y
        {
            get
            {
                return Function(X);
            }
        }

        /// <summary>
        /// Функция от лучшего локального X
        /// </summary>
        public double BestLocalY
        {
            get
            {
                return Function(BestLocalX);
            }
           
        }
        /// <summary>
        /// Функция от лучшего X
        /// </summary>
        public double BestY
        {
            get
            {
                return Function(BestX);
            }
        }
        
        /// <summary>
        /// Позиция точки
        /// </summary>
        /// <returns></returns>
        public double[] Position()
        {
            double[] pos = new double[2];
            pos[0] = X;
            pos[1] = Function(X);
            return pos;
        }
     
    }
}
