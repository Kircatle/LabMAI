using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class A
    {
        private B b = null;
        private C c = null;

        public A(B b, C c) //Конструктор класса
        {
            this.b = b;
            this.c = c;
        }
        public B bA //переопределение поля b
        {
            get
            {
                Console.Write("a->get b->");
                return b;
            }
            set
            {
                Console.Write("a->set b\n");
                b = value;
            }
        }
        public C cA //переопределение поля c
        {
            get
            {
                Console.Write("a->get c->");
                return c;
            }
            set
            {
                Console.Write("a->set c\n");
                c = value;
            }
        }
        public void mA()
        {
            Console.WriteLine("method of A");
        }

    }
}
