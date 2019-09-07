using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class B
    {
        private D d = null;
        public B(D d)
        {
            this.d = d;
        }
        public D dA
        {
            get
            {
                Console.Write("get d->");
                return d;
            }
            set
            {
                Console.Write("set d\n");
                d = value;
            }
        }
        public void mB()
        {
            Console.WriteLine("method of B");
        }
    }
}
