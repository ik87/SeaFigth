using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class Ship : IObserver
    {
        private char[,] position;
        private int length;
        private bool horizont;
        private int current;

        public Ship(IObservable map, int length) {
            this.length = length;
            this.current = length;
            position = new char[Map.MAPSIZE, Map.MAPSIZE];
            this.horizont = true;
            map.AddObserver(this);
        }

        public char[,] Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public bool Horisont
        {
            get
            {
                return horizont;
            }

            set
            {
                horizont = value;
            }
        }

        public int CurrentLength
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

    }
}
