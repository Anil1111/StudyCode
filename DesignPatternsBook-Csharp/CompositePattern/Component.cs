﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.CompositePattern
{
   abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
       public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);


    }
}
