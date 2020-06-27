using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    
    class User
    {
        private Calculator calculator;
        private List<Command> commands;
        private int curr;

        public User(int curr)
        {
            calculator = new Calculator(curr);
            commands = new List<Command>();
        }
        private int current = 0;
        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Делаем возврат операций
            for (int i = 0; i < levels; i++)

                if (current < commands.Count - 1)
                    commands[current++].Execute();
        }
        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            // Делаем отмену операций
            for (int i = 0; i < levels; i++)
                if (current > 0)
                    commands[--current].UnExecute();
        }
        public int Compute(char @operator, int operand)
        {
            // Создаем команду операции и выполняем её
            Command command = new CalculatorCommand(
            calculator, @operator, operand);
            command.Execute();
            // Добавляем операцию к списку отмены
            commands.Add(command);
            current++;
            return command.Execute();
        }
    }
}
