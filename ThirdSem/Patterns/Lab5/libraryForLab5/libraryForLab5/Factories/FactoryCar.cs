using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class FactoryCar : AbstractFactoryAuto
    {
        public override AbstractProductBody CreateBody()
        {
            return new CarBody();
        }

        public override AbstractProductEngine CreateEngine()
        {
            return new CarEngine();
        }

        public override AbstractProductTank CreateTank()
        {
            return new CarTank();
        }
    }
}
