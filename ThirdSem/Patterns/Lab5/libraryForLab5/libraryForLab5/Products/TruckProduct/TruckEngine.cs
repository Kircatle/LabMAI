using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class TruckEngine : AbstractProductEngine
    {
		public override double MaxSpeed => 110;
        public override string Name => "Daimler OM 457LA";
        public override double Price => 2000000;
        public override double Weight => 1500;
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

            var fuel = 0.005 * speed * speed - 0.8 * speed + 60;
            return fuel;
        }
    }
}
