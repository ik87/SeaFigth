using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{

    class Map : IObservable
    {
        public static char BOAT = 'o';
        public static char EMPTY = '\0';
        public static char HIT = 'h';
        public static char MISSED = 'm';
        public static int MAPSIZE = 12;
        char[,] shotMap;
        private List<IObserver> ships;

        public Map() {
            ships = new List<IObserver>();
            shotMap = new char[Map.MAPSIZE, Map.MAPSIZE];
        }

        public void AddObserver(IObserver o)
        {

            ships.Add(o);
        }

        public bool Shot(int x, int y)
        {
            foreach (IObserver ship in ships)
            {
                
                if (ship.Position[y, x] == Map.BOAT && ship.CurrentLength != 0)
                {
                        ship.CurrentLength--;
                        ship.Position[y, x] = Map.HIT;
                        shotMap[y, x] = Map.HIT;
                    if (ship.CurrentLength == 0) {
                        WrapMissing(ship);
                    }
                        return true; 
                }
           }
            if(shotMap[y, x] == Map.EMPTY)
                shotMap[y, x] = Map.MISSED;
            return false;
       }

        public void FillMap(Random rn)
        {

            foreach (IObserver ship in ships)
            {
                bool builder = true;
                do {
                    ship.Horisont = (rn.Next(0, 2) == 1);
                    int x = rn.Next(1, MAPSIZE - 1);
                    int y = rn.Next(1, MAPSIZE - 1);

                    if (DetectEmpty(x, y))
                    {
                        if (ship.Length == 1)
                        {
                            ship.Position[y, x] = Map.BOAT;
                            builder = false;
                        }
                        else
                        {
                            for (int i = 0; i < ship.Length; )
                            {

                                if (ship.Horisont)
                                {
                                    if (DetectEmpty(x + i, y))
                                    {
                                        ship.Position[y, x + i] = Map.BOAT;
                                    }
                                    else
                                    {
                                        ShipClear(ship);
                                        break;
                                    }
                                }
                                else
                                {
                                    if (DetectEmpty(x, y + i))
                                    {
                                        ship.Position[y + i, x] = Map.BOAT;
                                    }
                                    else
                                    {
                                        ShipClear(ship);
                                        break;
                                    }

                                }
                                i++;
                                if (i == ship.Length) {
                                    builder = false;
                                    break;
                                }
                            }
                        }
                    }
                } while (builder);
            }
        }

        private bool DetectEmpty(int x, int y) {
            if ((y + 1) > Map.MAPSIZE - 1 || (x + 1) > Map.MAPSIZE - 1) {
                return false;
            }
                foreach (IObserver ship in ships) {
                if (ship.Position[y, x] != BOAT && ship.Position[y, x + 1] != BOAT && 
                    ship.Position[y + 1, x + 1] != BOAT && ship.Position[y + 1, x] != BOAT &&
                   ship.Position[y + 1, x - 1] != BOAT && ship.Position[y, x - 1] != BOAT && 
                   ship.Position[y - 1, x - 1] != BOAT && ship.Position[y - 1, x] != BOAT && 
                   ship.Position[y - 1, x + 1] != BOAT) {
                    return true;
                }
               }
            return false;
        }

        private void WrapMissing(IObserver ship) {
            for (int y = 1; y < Map.MAPSIZE - 1; y++)
            {
                for (int x = 1; x < Map.MAPSIZE - 1; x++)
                {
                    if (ship.Position[y, x] == Map.HIT) {

                        if (ship.Position[y, x + 1] != Map.HIT) {
                            shotMap[y, x + 1] = Map.MISSED;
                        }
                        if (ship.Position[y + 1, x + 1] != Map.HIT)
                        {
                            shotMap[y + 1, x + 1 ] = Map.MISSED;
                        }
                        if (ship.Position[y + 1, x] != Map.HIT)
                        {
                            shotMap[y + 1, x] = Map.MISSED;
                        }
                        if (ship.Position[y + 1, x - 1] != Map.HIT)
                        {
                            shotMap[y + 1, x - 1] = Map.MISSED;
                        }
                        if (ship.Position[y, x - 1] != Map.HIT)
                        {
                            shotMap[y, x - 1] = Map.MISSED;
                        }
                        if (ship.Position[y - 1, x - 1] != Map.HIT)
                        {
                            shotMap[y - 1, x - 1] = Map.MISSED;
                        }
                        if (ship.Position[y - 1, x] != Map.HIT)
                        {
                            shotMap[y - 1, x] = Map.MISSED;
                        }
                        if (ship.Position[y - 1, x + 1] != Map.HIT)
                        {
                            shotMap[y - 1, x + 1] = Map.MISSED;
                        }
                    }
                }
            }
        }

        void ShipClear(IObserver ship) {
            for (int y = 0; y < Map.MAPSIZE; y++)
                for (int x = 0; x < Map.MAPSIZE; x++)
                    ship.Position[y, x] = '\0';
        }
    }
}
