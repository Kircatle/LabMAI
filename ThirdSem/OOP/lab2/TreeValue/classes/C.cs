using System;
using System.Collections.Generic;
using System.Text;

namespace TreeValue.classes
{
    class C
    {
        public void mC()
        {
            Console.WriteLine("method of C");
        }
        public E eA
        {
            get
            {
                Console.Write("get E->");
                return e;
            }
        }
        public J jA
        {
            get
            {
                Console.Write("get J->");
                return j;
            }
        }
        private E e = new E();
        private J j = new J();
    }
}
