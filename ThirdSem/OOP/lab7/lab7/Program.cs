using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class B
    {
        public void methodB()
        {
            Console.WriteLine("not static B");
        }
    }

    static class C
    {
        public static void methodC()
        {
            Console.WriteLine("static C");
        }
    }
    class A
    {
        public void methodA_B(B b)
        {
            b.methodB();
        }
        public void methodA_C()
        {
            C.methodC();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = new A();
            a.methodA_B(b);
            a.methodA_C();
            C.methodC();
            Console.ReadKey();
        }
    }
}
