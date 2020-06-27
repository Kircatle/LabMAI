using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Cost : MoneySite
    {
        private double costHost;
    

        public Cost(string website, double costHost) : base(website)
        {
            this.costHost = costHost;
        }

        public override double sum()
        {
            return -costHost;
        }
        public override string info()
        {
            return string.Format("{0,20}\t{1,20:f2}", website, sum());            
        }
    }
}
