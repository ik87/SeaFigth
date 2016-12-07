using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Game
    {
        public Map map { get; set; }
        private Ship[] ships;

       // public Map MAP { get { map}; set; }

        public Game() {
            map = new Map();
            createShips();
            positionShips();
        }

        private void createShips()
        {
            ships = new Ship[Map.SHIPS];
            Random rnd = new Random();
            for (int i = 0; i < Map.SHIPS; i++)
            {
                if (i == 0)
                {
                    ships[i] = new Ship(4, rnd.Next(2) > 0);
                }
                else if (i > 0 && i <= 2)
                {
                    ships[i] = new Ship(3, rnd.Next(2) > 0);
                }
                else if (i > 2 && i <= 5)
                {
                    ships[i] = new Ship(2, rnd.Next(2) > 0);
                }
                else if (i > 5 && i < 10)
                {
                    ships[i] = new Ship(1, rnd.Next(2) > 0);
                }
            }
        }
        private void positionShips()
        {
            Random rnd = new Random();
            for (int i = 0; i < Map.SHIPS;)
            {
                if (ships[i].setPosition(rnd.Next(1, 11), rnd.Next(1, 11), map))
                {
                    i++;
                }
            }
        }
        private void clearShips()
        {
            Random rnd = new Random();
            for (int i = 0; i < Map.SHIPS; i++)
            {
                ships[i].clearShip();
                ships[i].Horizont = (rnd.Next(2) > 0);
                ships[i].live = ships.Length;
            }
        }
        private void draw()
        {
            char a = 'А';
            for (int i = 0; i < Map.SIZE - 1; i++)
            {
                if (i != 10)
                    Console.Write("  " + i + " ");
                else
                    Console.Write(" " + i + " ");
                for (int j = 1; j < Map.SIZE - 1; j++)
                {
                    if (i == 0)
                    {
                        Console.Write(" " + a++ + " ");
                    }
                    else
                    {
                        if (map.GetMap[i, j] == Map.SHIP)
                            Console.Write(" o ");
                        else
                            Console.Write(" . ");
                    }
                }
                Console.WriteLine();

            }
        }
        private void WrapMissing(Ship ship)
        {
            for (int y = 1; y < Map.SIZE - 1; y++)
            {
                for (int x = 1; x < Map.SIZE - 1; x++)
                {
                    if (ship.Posiztion[y, x] == Map.SHIP)
                    {

                        if (ship.Posiztion[y, x + 1] != Map.SHIP)
                        {
                            map.GetMap[y, x + 1] = Map.MISSED;
                        }
                        if (ship.Posiztion[y + 1, x + 1] != Map.SHIP)
                        {
                            map.GetMap[y + 1, x + 1] = Map.MISSED;
                        }
                        if (ship.Posiztion[y + 1, x] != Map.SHIP)
                        {
                            map.GetMap[y + 1, x] = Map.MISSED;
                        }
                        if (ship.Posiztion[y + 1, x - 1] != Map.SHIP)
                        {
                            map.GetMap[y + 1, x - 1] = Map.MISSED;
                        }
                        if (ship.Posiztion[y, x - 1] != Map.SHIP)
                        {
                            map.GetMap[y, x - 1] = Map.MISSED;
                        }
                        if (ship.Posiztion[y - 1, x - 1] != Map.SHIP)
                        {
                            map.GetMap[y - 1, x - 1] = Map.MISSED;
                        }
                        if (ship.Posiztion[y - 1, x] != Map.SHIP)
                        {
                            map.GetMap[y - 1, x] = Map.MISSED;
                        }
                        if (ship.Posiztion[y - 1, x + 1] != Map.SHIP)
                        {
                            map.GetMap[y - 1, x + 1] = Map.MISSED;
                        }
                    }
                }
            }
        }
        public void DetectShip(Point point) {
            foreach (Ship ship in ships) {
                if (ship.Posiztion[point.Y, point.X] == Map.SHIP) {
                    if (ship.live > 0)
                        ship.live--;
                    if(ship.live == 0)    
                    WrapMissing(ship);
                    }
                }
            }
        
        public void reset()
        {
            map.clearMap();
            clearShips();
            positionShips();
        }
        /*public bool Shot(Point point) {
            if (map.GetMap[point.Y, point.X] == Map.SHIP)
            {
                map.GetMap[point.Y, point.X] = Map.HIT;
                //DetectShip(point);
                return true;
            }
            else if(map.GetMap[point.Y, point.X] != Map.HIT){
               map.GetMap[point.Y, point.X] = Map.MISSED;
                return false;
            }
            return false;
        }*/
        public void Shot(Point point)
        {
            if (map.GetMap[point.Y, point.X] == Map.SHIP)
            {
                map.GetMap[point.Y, point.X] = Map.HIT;
                //DetectShip(point);
            }
            else if (map.GetMap[point.Y, point.X] == Map.HIT) {
                
            }
            else
            {
                map.GetMap[point.Y, point.X] = Map.MISSED;
            }
        }


    }
}
