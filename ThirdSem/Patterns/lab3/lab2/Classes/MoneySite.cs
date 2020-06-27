using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract class MoneySite
    {
        protected string website;
        abstract public double sum();
        abstract public string info();

        public MoneySite(string website)
        {
            this.website = website;
        }
    }
}
