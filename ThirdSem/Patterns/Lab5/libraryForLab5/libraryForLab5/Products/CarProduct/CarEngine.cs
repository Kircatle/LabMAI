using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class CarEngine : AbstractProductEngine
    {

        public override double MaxSpeed => 80;
        public override string Name => "Двигатель ВАЗ-1111";
        public override double Price => 50000;
        public override double Weight => 250;
        public override double GetFuel(double speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException("Скорость не может быть меньше нуля.", nameof(speed));
            }

            if (speed == 0)
            {
                return 0;
            }

            var fuel = 0.0008 * speed * speed - 0.2 * speed + 15;
            return fuel;
        }
    }
}
