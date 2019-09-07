using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class J
    {
        private K k = null;
        public J(K k)
        {
            this.k = k;
        }
        public K kA
        {
            set
            {
                Console.Write("set k\n");
                k = value;
            }
            get
            {
                Console.Write("get k->");
                return k;
            }
        }
        public void mJ()
        {
            Console.WriteLine("method of J");
        }
    }
}
