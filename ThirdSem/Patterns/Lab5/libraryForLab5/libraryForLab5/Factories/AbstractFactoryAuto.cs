using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public abstract class AbstractFactoryAuto
    {
        public abstract AbstractProductBody CreateBody();
        public abstract AbstractProductEngine CreateEngine();
        public abstract AbstractProductTank CreateTank();
    }
}
