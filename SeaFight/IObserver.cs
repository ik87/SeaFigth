using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    interface IObserver
    {
        char[,] Position { get; set; }
        int Length { get; set; }
        bool Horisont { get; set; }
        int CurrentLength { get; set; }
        
    }
}
