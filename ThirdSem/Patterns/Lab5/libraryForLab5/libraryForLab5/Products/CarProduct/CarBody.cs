using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class CarBody : AbstractProductBody
    {
		public override double Aerodynamic => 1.1;
        public override double MaxWeight => 985;
        public override string Name => "Корпус ВАЗ-1111";
        public override double Price => 30000;
        public override double Weight => 350;
    }
}
