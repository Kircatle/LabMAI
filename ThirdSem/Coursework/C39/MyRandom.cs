using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C39
{
    static class MyRandom
    {
        /// <summary>
        /// Расширение для функции класса Random, которое дает возможность искать случайное вещественное число в заданном диапазоне.
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double NextDouble(this Random rand, double min, double max)
        {
            if (min > max)
                throw new ArgumentException("Минимальное значение не может быть больше, чем максимальное");
            return (rand.NextDouble() * (max - min) + min);
        }
    }
}


