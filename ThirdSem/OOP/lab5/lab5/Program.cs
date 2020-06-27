using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface IA
    {
        void methodIA();
    }
    interface IC : IA
    {
        void method();
    }
    class B : IA
    {
        public void method()
        {
            Console.WriteLine("B");
        }
        public void methodIA()
        {
            Console.WriteLine("IA");
        }
    }
    class D : B, IC
    {
        public void methodD()
        {
            Console.WriteLine("D");
        }
        public void method()
        {
            Console.WriteLine("IC");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            IC d = new D();
            d.method();
            ((B)d).method();
        }
    }
}
/*
 
        IA
       /\
      /  \
     B    IC
      \   /
       \ /
       D
 */
