using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_work
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack tom = new MyStack(3);
            tom.add_to_stack(1);
            tom.add_to_stack(2);
            tom.add_to_stack(3);
            tom.pop_from_stack();
            Console.Write(tom.count_elem());
            Console.Write("\n");
            Console.Write(tom.top_elem());
            Console.Write("\n");
        }
    }
}
