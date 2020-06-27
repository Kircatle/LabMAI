using System;
using System.Collections.Generic;
using System.Text;

namespace TreeValue.classes
{
    class B
    {
        public void mB()
        {
            Console.WriteLine("method of B");
        }
        public D dA
        {
            get
            {
                Console.Write("get D->");
                return d;
            }
        }
        private D d = new D();
    }
}
