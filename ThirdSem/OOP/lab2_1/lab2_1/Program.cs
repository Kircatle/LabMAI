using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1.classes
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.mA();
            a.bA.mB();
            a.bA.dA.mD();
            a.cA.mC();
            a.cA.eA.mE();
            a.cA.jA.mJ();
            a.cA.jA.kA.mK();
        }
    }
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
