using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_work
{
    class MyStack
    {
        public int size_stack;
        public int[] nums;
        public int last_elem;

        public MyStack(int size_stack)
        {
            this.size_stack = size_stack;
            this.nums = new int[this.size_stack];
            this.last_elem = -1;
        }
        public void add_to_stack(int elem)
        {
            if (this.last_elem == this.size_stack - 1)
            {
                Console.WriteLine("Ошибка: Превышен размер стека");
                return;
            }
            this.last_elem++;
            this.nums[this.last_elem] = elem;
        }
        public void pop_from_stack()
        {
            if (this.last_elem == -1)
            {
                Console.WriteLine("Ошибка: Стек пуст");
                return;
            }
            this.nums[this.last_elem] = 0;
            this.last_elem--;
        }
        public int top_elem()
        {
            if (this.last_elem == -1)
            {
                Console.WriteLine("Ошибка: Стек пуст");
                return -1;

            }

            return this.nums[this.last_elem];
        }
        public int count_elem()
        {
            return this.last_elem + 1;
        }
    }
}
