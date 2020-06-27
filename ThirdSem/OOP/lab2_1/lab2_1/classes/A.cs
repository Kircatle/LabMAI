using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1.classes
{
    public class A
    {
        public void mA()
        {
            Console.WriteLine("A->method of A");
        }
        public class B
        {
            public void mB()
            {
                Console.WriteLine("method of B");
            }
            public class D
            {
                public void mD()
                {
                    Console.WriteLine("method of D");
                }
            }
            public D dA
            {
                get
                {
                    Console.Write("get d -> ");
                    return d;
                }
            }
            private D d = new D();
        } //class B
        public class C
        {
            public void mC()
            {
                Console.WriteLine("method of C");
            }
            public class E
            {
                public void mE()
                {
                    Console.WriteLine("method of E");
                }
            }
            public class J
            {
                public void mJ()
                {
                    Console.WriteLine("method of J");
                }
                public class K
                {
                    public void mK()
                    {
                        Console.WriteLine("method of K");
                    }

                } //class K
                public K kA
                {
                    get
                    {
                        Console.Write("get k -> ");
                        return k;
                    }
                }

                private K k = new K();
            } //class J

            public E eA
            {
                get
                {
                    Console.Write("get e ->");
                    return e;
                }
            }
            public J jA
            {
                get
                {
                    Console.Write("get j ->");
                    return j;
                }
            }
            private J j = new J();
            private E e = new E();
        } //class C
        public B bA
        {
            get
            {
                Console.Write("A->get b ->");
                return b;
            }
        }
        public C cA
        {
            get
            {
                Console.Write("A->get c ->");
                return c;
            }
        }

        private B b = new B();
        private C c = new C();

    } // class A
}


/* 
 Вариант 15
    A
   / \
  B   C
 /    /\
D    E  J
         \
          K
                */
