using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class Rectangle : Figure
    {

        private double side_a;
        private double side_b;
        public Rectangle(double side_a, double side_b, string name) : base(name)
        {
            this.side_a = side_a;
            this.side_b = side_b;
        }

        public override double P()
        {
            return (side_a + side_b) * 2;
        }

        public override double S()
        {
            return side_b * side_a;
        }
        public double diagonal()
        {
            return Math.Sqrt((side_a *side_a + side_b * side_b)); 
        }
        public override void standartCharacteristic()
        {
            base.standartCharacteristic();
            Console.WriteLine("A = {0}\nB = {1}", side_a, side_b);
        }
    }

}
