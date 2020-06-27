using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Calculator
    {
        private int curr;

        public int Curr
        {
            get { return curr;}
            set { curr = value; }
        }

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    curr += operand;
                    break;
                case '-':
                    curr -= operand;
                    break;
                case '*':
                    curr *= operand;
                    break;
                case '/':
                    curr /= operand;
                    break;
            }
      
        }
    }
}
