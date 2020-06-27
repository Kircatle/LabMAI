using System;
using System.Collections.Generic;
using System.Text;

namespace TreeValue.classes
{
    class A
    {
        public void mA()
        {
            Console.WriteLine("A->method of A");
        }
        public B bA
        {
            get
            {
                Console.Write("A->get B->");
                return b;
            }
        }
        public C cA
        {
            get
            {
                Console.Write("A->get C->");
                return c;
            }
        }
        private B b = new B();
        private C c = new C();
    }
}
