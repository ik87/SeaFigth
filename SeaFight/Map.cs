using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{

    class Map : IObservable
    {
        public static int MAPSIZE = 12;
        private List<IObserver> observers;
        int[,] map;

        public Map() {
            observers = new List<IObserver>();
        }
        

        public void AddObserver(IObserver o)
        {
            
            observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach(IObserver ob in observers) {
                ob.Update();
            }
        }

        public void RemoveObserver(IObserver o)
        {
        }
    }
}
