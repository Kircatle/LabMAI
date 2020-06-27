using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Calculator
    {
        public int Curr { get; private set; }

        public Calculator(int Curr)
        {
            this.Curr = Curr;
        }
        public int Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    Curr += operand;
                    break;
                case '-':
                    Curr -= operand;
                    break;
                case '*':
                    Curr *= operand;
                    break;
                case '/':
                    Curr /= operand;
                    break;
            }
            return Curr;
        }
    }
}
