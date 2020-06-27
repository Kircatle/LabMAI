using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    /// <summary>
    /// двигатель автомобиля
    /// </summary>
    public abstract class AbstractProductEngine
    {

       //Название
        public abstract string Name { get; }

        //Цена
        public abstract double Price { get; }

        //Вес
        public abstract double Weight { get; }

        //Максимальная скорость
        public abstract double MaxSpeed { get; }

        //Необходимое топливо
        public abstract double GetFuel(double speed);
    }
}
