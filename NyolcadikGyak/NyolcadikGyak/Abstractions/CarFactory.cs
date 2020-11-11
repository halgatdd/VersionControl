﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NyolcadikGyak.Entities;

namespace NyolcadikGyak.Abstractions
{
    class CarFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Entities.Toy();
        }
    }
}
