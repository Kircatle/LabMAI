using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class A
    {
        public A(B b, C c) //Конструктор класса
        {
            this.b = b;
            this.c = c;
        }
        public B bA // доступ к атрибуту b
        {
            get
            {
                Console.Write("a->get b->");
                return b;
            }
        }
        public C cA //переопределение поля c
        {
            get
            {
                Console.Write("a->get c->");
                return c;
            }
        }
        public void mA()
        {
            Console.WriteLine("a->method of A");
        }
        private B b = null;
        private C c = null;
    }
}
