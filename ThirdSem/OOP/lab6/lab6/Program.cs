using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class B1
    {
        public A1 a { set; get; }
        public void method()
        {
            Console.WriteLine("Method B1");
        }

    }
    class A1 // 1:1
    {
        public B1 b { set; get; }
        public void method()
        {
            Console.WriteLine("Method A1");
        }
    }
    class A
    {
        private B[] b = null;
        private int size = 0;
        private int N = 0;

        public A(int N)
        {
            this.N = N;
            this.b = new B[N];
        }
        public void setB(B b) // привязываем к а очередное б
        {
            if (size < N)
            {
                this.b[size] = b;
                size++;
                b.setA(this);
            }
        }
        public B getNext(int index) //возвращает б
        {
            if (index < size)
            {
                return b[index];
            }
            return null;
        }
        public void method()
        {
            Console.WriteLine("Method A");
        }



    }
    class B
    {
        public A a { set; get; }
        public B()
        {

        }

        public B(A a)
        {
            a.setB(this);
        }
        public void method()
        {
            Console.WriteLine("Method B");
        }
        public void setA(A a)
        {
            this.a = a;
        }

    }




    class Program
    {
        static void Main(string[] args)
        {

            // 1:1
            var a1 = new A1();
            var b1 = new B1();
            a1.b = b1;
            b1.a = a1;
            b1.a.method();
            a1.b.method();
            // 1:N
            A a = new A(4);
            for (int i = 0; i < 4; i++)
            {
                B b = new B(a);
                b.a.method();
            }

            B b21 = new B();
            b21.setA(a);
            b21.a.setB(b21);

            for (int i = 0; i < 3; i++)
            {
                a.getNext(i).method();
            }


            Console.ReadKey();
        }
    }
}
