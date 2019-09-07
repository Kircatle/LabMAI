using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class C
    {
        private E e = null;
        private J j = null;
        public C(E e, J j)
        {
            this.e = e;
            this.j = j;
        }
        public E eA
        {
            get
            {
                Console.Write("get e->");
                return e;
            }
            set
            {
                Console.Write("set e\n");
                e = value;
            }
        }
        public J jA
        {
            get
            {
                Console.Write("get j->");
                return j;
            }
            set
            {
                Console.Write("set j\n");
                j = value;
            }
        }
        public void mC()
        {
            Console.WriteLine("method of C");
        }
    }
}
