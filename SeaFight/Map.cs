using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Map
    {
        public static int SIZE = 12; // size map = 10 ( indent 1 from the edges)
        public static int SHIPS = 10;
        public static char EMPTY = '\0';
        public static char SHIP = 'o';
        public static char HIT = 'h';
        public static char MISSED = 'm';


        private char[,] map;
        public Map()
        {
            map = new char[SIZE, SIZE];
            clearMap(); //fill map 0
        }
        public void setMap(Ship sh)
        {

            for (int i = 1; i < SIZE - 1; i++)
            {
                for (int j = 1; j < SIZE - 1; j++)
                {
                    if (sh.Posiztion[i, j] == Map.SHIP)
                        map[i, j] = Map.SHIP;
                }
            }
        }
        public char[,] GetMap
        {
            get { return map; }
            set { map = value;}
        }
        public void clearMap()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    map[i, j] = Map.EMPTY;
                }
            }
        }
    }
}
