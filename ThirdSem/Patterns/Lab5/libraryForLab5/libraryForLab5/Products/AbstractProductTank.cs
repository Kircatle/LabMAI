using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    /// <summary>
    /// бак автомобиля
    /// </summary>
    public abstract class AbstractProductTank
    {

        //Название
        public abstract string Name { get; }

        //Цена
        public abstract double Price { get; }

        //Вес
        public abstract double Weight { get; }

        //Максимальный вес
        public abstract double MaxVolume { get; }

        //Пустой ли бак
        public abstract bool Empty { get; }

        //Зависимость скорости от заполненности бака
        public abstract double SpeedFactor { get; }

        //расход топлива
        public abstract double SpendFuel(double fuel);
    }
}
