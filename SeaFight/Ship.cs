using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Ship
    {
        public char[,] Posiztion { get; set; }
        private int size;
        public int live { get; set; }
        private bool horizont;
        public bool Horizont
        {
            get { return horizont; }
            set { horizont = value; }
        }
        public Ship(int size, bool horizont)
        {
            this.size = size;
            this.live = size;
            Posiztion = new char[Map.SIZE, Map.SIZE];
            this.horizont = horizont;
            clearShip();
        }
        public bool setPosition(int x, int y, Map map) // set x,y from 1 to 10
        {

            if (map.GetMap[y, x] != Map.SHIP && size != 1)
            {

                if (horizont)
                {
                    if ((x + size) < Map.SIZE - 1)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (scanAround(x + i, y, map) == false)
                            {
                                return false;
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                            Posiztion[y, x + i] = Map.SHIP;
                        }
                        map.setMap(this);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((y + size) < Map.SIZE - 1)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (scanAround(x, y + i, map) == false)
                            {
                                return false;
                            }
                        }

                        for (int i = 0; i < size; i++)
                        {
                            Posiztion[y + i, x] = Map.SHIP;
                        }
                        map.setMap(this);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (map.GetMap[y, x] != Map.SHIP && size == 1)
            {
                if (scanAround(x, y, map))
                {
                    Posiztion[y, x] = Map.SHIP;
                    map.setMap(this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        private bool scanAround(int x, int y, Map map)
        {
            if (
            map.GetMap[y, x + 1] != Map.SHIP && map.GetMap[y + 1, x + 1] != Map.SHIP &&
            map.GetMap[y + 1, x] != Map.SHIP && map.GetMap[y + 1, x - 1] != Map.SHIP &&
            map.GetMap[y, x - 1] != Map.SHIP && map.GetMap[y - 1, x - 1] != Map.SHIP &&
            map.GetMap[y - 1, x] != Map.SHIP && map.GetMap[y - 1, x + 1] != Map.SHIP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void clearShip()
        {
            for (int i = 0; i < Map.SIZE; i++)
            {
                for (int j = 0; j < Map.SIZE; j++)
                {
                    Posiztion[j, i] = Map.EMPTY;
                }
            }
        }

    }
}
