using System;

namespace ConsoleApp
{
    interface IK
    {
        void methodK();
    }
    interface IJ : IK
    {
        void methodJ();
    }
    interface IE
    {
        void methodE();
    }
    class D
    {
        public void methodD()
        {
            Console.WriteLine("method D");
        }
    }
    class B : D
    {
        public void methodB()
        {
            Console.WriteLine("method B");
        }

    }
    interface IC : IE, IJ
    {
        void methodC();
    }
    class A : B, IC
    {
        public void methodA()
        {
            Console.WriteLine("method A");
        }

        public void methodC()
        {
            Console.WriteLine("method C");
        }

        public void methodE()
        {
            Console.WriteLine("method E");
        }

        public void methodJ()
        {
            Console.WriteLine("method J");
        }

        public void methodK()
        {
            Console.WriteLine("method K");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IK f = new A();
            f.methodK();
            IJ c = (IJ)f;
            c.methodJ();
            c.methodK();
            IC j = (IC)c;
            j.methodC();
            j.methodE();
            j.methodJ();
            j.methodK();
            A a = (A)j;
            a.methodA();
            a.methodB();
            a.methodC();
            a.methodD();
            a.methodE();
            a.methodJ();
            a.methodK();
        }
    }
}
