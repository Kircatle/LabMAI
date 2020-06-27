using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Revenue : MoneySite
    {
        private double countVisits;
        private double costVisits;


        public Revenue(string website, double countVisits, double costVisits) : base(website)
        {
            this.countVisits = countVisits;
            this.costVisits = costVisits;
        }

        public override double sum()
        {
            return costVisits*countVisits;
        }
        public override string info()
        {
            return string.Format("{0,20}\t{1,20:f2}\t{2,20}", website, sum(), countVisits);
        }
    }
}
