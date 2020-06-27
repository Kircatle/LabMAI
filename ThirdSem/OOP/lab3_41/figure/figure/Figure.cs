using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figure
{
    abstract class Figure
    {
        private string name;

        public Figure(string name)
        {
            this.name = name;
        }

        public abstract double S();
        public abstract double P();
        public virtual void standartCharacteristic()
        {
            Console.WriteLine("Name = {0}", name);
        }
    }
}
