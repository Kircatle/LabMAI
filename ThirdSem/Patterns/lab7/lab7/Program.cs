using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace lab7
{


    delegate void KeyHandler(char arg);


    /// <summary>
    /// класс события - нажатие кнопки
    /// </summary>
    class KeyEvent 
    {
        public event KeyHandler KeyPress;
        public void OnKeyPress(char key)
        {
            KeyPress?.Invoke(key);
        }
    }

    abstract class ProcessKey
    {
        protected ProcessKey successor;
        public void SetSuccessor(ProcessKey successor)
        {
            this.successor = successor;
        }

        public abstract void keyhandler(char arg);
    }

    class CountKey
    {
        public int count = 0;

        public void keyhandler(char arg)
        {
            count++;
        }
    }

    class ConcreteHandler1 : ProcessKey
    {
        public override void keyhandler(char arg)
        {
            if (arg >= '0' && arg <= '9')
            {
                Console.WriteLine("{0} handled request " + arg, this.GetType().Name);
            }
            else if (successor != null)
            {
                successor.keyhandler(arg);
            }
        }
    }

    class ConcreteHandler2 : ProcessKey
    {
        public override void keyhandler(char arg)
        {
            if (arg >= 'a' && arg <= 'z')
            {
                Console.WriteLine("{0} handled request " + arg, this.GetType().Name);
            }
            else if (successor != null)
            {
                successor.keyhandler(arg);
            }
        }
    }

    class ConcreteHandler3 : ProcessKey
    {
        public override void keyhandler(char arg)
        {
            if (arg >= 'а' && arg <= 'я')
            {
                Console.WriteLine("{0} handled request " + arg, this.GetType().Name);
            }
            else if (successor != null)
            {
                successor.keyhandler(arg);
            }
        }
    }

    class ConcreteHandler4 : ProcessKey
    {
        public override void keyhandler(char arg)
        {
            if (arg == '\t' || arg == ' ' || arg == ',')
            {
                Console.WriteLine("{0} handled request " + arg, this.GetType().Name);
            }
            else if (successor != null)
            {
                successor.keyhandler(arg);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char ch;
            ProcessKey h1 = new ConcreteHandler1();
            ProcessKey h2 = new ConcreteHandler2();
            ProcessKey h3 = new ConcreteHandler3();
            ProcessKey h4 = new ConcreteHandler4();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            h3.SetSuccessor(h4);

            KeyEvent kevt = new KeyEvent(); // нажатие кнопки
            CountKey ck = new CountKey(); 
            kevt.KeyPress += new KeyHandler(h1.keyhandler);
            kevt.KeyPress += new KeyHandler(ck.keyhandler);

            do
            {
                ch = (char)Console.Read();
                kevt.OnKeyPress(ch);
            } while (ch != '.');
            Console.WriteLine("keys were pressed: " + ck.count);
            Console.ReadKey();
        }
    }
}