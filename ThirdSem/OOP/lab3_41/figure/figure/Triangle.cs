using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class Triangle : Figure
    {
        private double side_a;
        private double side_b;
        private double side_c;
        public Triangle(double side_a, double side_b, double side_c, string name) : base(name)
        {
            this.side_a = side_a;
            this.side_b = side_b;
            this.side_c = side_c;
        }

        public override double P()
        {
            return side_c + side_b + side_a;
        }
        public override double S()
        {
            double p = P() / 2;
            return Math.Sqrt(p * (p - side_a) * (p - side_b) * (p - side_c));
        }
        public double Ha()
        {
            return 2 * S() / side_a;
        }
        public override void standartCharacteristic()
        {
            base.standartCharacteristic();
            Console.WriteLine("A = {0}\nB = {1}\nC = {2}", side_a, side_b, side_c);
        }


        protected double A
        {
            get { return side_a; }
        }
        protected double B
        {
            get { return side_b; }
        }
        protected double C
        {
            get { return side_c; }
        }
    }  
}
