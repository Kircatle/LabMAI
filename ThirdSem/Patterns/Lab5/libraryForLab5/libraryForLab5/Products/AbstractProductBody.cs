using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    /// <summary>
    ///  Корпус автомобиля
    /// </summary>
    public abstract class AbstractProductBody
    {

        //Название
        public abstract string Name { get; }

        //Цена
        public abstract double Price { get; }

        //Вес
        public abstract double Weight { get; }

        //Коэффициент аэродинамики
        public abstract double Aerodynamic { get; } 

        //Максимально переносимый вес
        public abstract double MaxWeight { get; } 
    }
}
