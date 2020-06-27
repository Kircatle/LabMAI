using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
 /*    Вариант 15
            A 
           / \    
          B   C
         /   / \  
        D   E   J
                 \
                  K
 */

    class Program
    {
        static void Main(string[] args)
        {
 
            K k = new K();

            J j = new J(k);
            D d = new D();
            E e = new E();

            B b = new B(d);
            C c = new C(e, j);

            A a = new A(b, c);


            a.mA(); // A
            a.bA.mB(); // A->B
            a.cA.mC(); // A->C
            a.bA.dA.mD(); // A->B->D
            a.cA.eA.mE(); // A->C->E
            a.cA.jA.mJ(); // A->C->J
            a.cA.jA.kA.mK(); // A->C->J->K

        }
    }
}
