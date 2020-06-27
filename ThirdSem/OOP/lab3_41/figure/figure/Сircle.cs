using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class Circle : Figure
    {
        private int radius;
        private double pi = 3.14;
        public Circle(int radius, string name) : base(name)
        {
            this.radius = radius;
        }

        public override double S()
        {
            return pi * radius * radius;
        }
        public override double P()
        {
            return 2 * pi * radius;
        }
        public double diametr()
        {
            return 2 * radius;
        }

        public override void standartCharacteristic()
        {
            base.standartCharacteristic();
            Console.WriteLine("r = {0}", radius);
        }


    }
}
