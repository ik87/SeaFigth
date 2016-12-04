using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Boats : IObserver
    {

        int[,] size;

        Boats(int length) {
            size = new int[Map.MAPSIZE, Map.MAPSIZE];

        }



        public void Update()
        {
            
        }
    }
}
