using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class User
    {
       
        // Initializers
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public int Curr
        {
            get { return _calculator.Curr; }
            set { _calculator.Curr = value; }
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (_current < _commands.Count - 1)
                 _commands[_current++].Execute();
        }
        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (_current > 0)
                    _commands[--_current].UnExecute();
        }
        public void Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand(
            _calculator, @operator, operand);
            command.Execute();
            _commands.Add(command);
            _current++;
        }
    }
}
