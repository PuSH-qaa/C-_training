﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    class Square : Figure
    {
        private int size;
        private bool colored = false;
        public Square(int size)
        {
            this.size = size;
        }

        public int Size
        {
            get
            {
                return size;   
            }
            set
            {
                this.size = value;
            }
        }

    }
}