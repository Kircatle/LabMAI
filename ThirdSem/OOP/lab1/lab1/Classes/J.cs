using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class J
    {
        public J(K k)
        {
            this.k = k;
        }
        public K kA
        {
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
        private K k = null;
    }
}
