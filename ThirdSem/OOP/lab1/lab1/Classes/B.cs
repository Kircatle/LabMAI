﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class B
    {
        public B(D d)
        {
            this.d = d;
        }
        public D dA
        {
            get
            {
                Console.Write("get d->");
                return d;
            }
        }
        public void mB()
        {
            Console.WriteLine("method of B");
        }
        private D d = null;
    }
}
