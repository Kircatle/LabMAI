using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class TruckBody : AbstractProductBody
    {

		public override double Aerodynamic => 0.7;
        public override double MaxWeight => 7900;
        public override string Name => "Корпус KAMAZ-5490";
        public override double Price => 1500000;
        public override double Weight => 1000;
    }
}
