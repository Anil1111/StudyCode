﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.MediatorPattern
{
    class ConcreteColleague2:Colleague
    {
        public ConcreteColleague2(Mediator mediator):base(mediator)
        {

        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"同事2得到信息{message}");
        }
    }
}
