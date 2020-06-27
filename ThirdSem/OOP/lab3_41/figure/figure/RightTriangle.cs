using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    class RightTriangle : Triangle
    {
        public RightTriangle(double side_a, double side_b, double side_c, string name) : base(side_a, side_b, side_c, name) {}

        public override double S()
        {
            return 0.5 * A * B;
        }
        public double Biss90()
        {
            return Math.Sqrt(2) * A * B / (A + B);
        }
    }
}
