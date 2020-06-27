using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class FactoryTruck : AbstractFactoryAuto
    {
        public override AbstractProductBody CreateBody()
        {
            return new TruckBody();
        }

        public override AbstractProductEngine CreateEngine()
        {
            return new TruckEngine();
        }

        public override AbstractProductTank CreateTank()
        {
            return new TruckTank();
        }
    }
}
