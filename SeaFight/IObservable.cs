﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    interface IObservable
    {
        void AddObserver(IObserver o);

    }
}
