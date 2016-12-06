using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{

    static class Program
    {
        public static Map map;
        public static Ship[] ship;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            map = new Map();
            ship = new Ship[10];
            ship[0] = new Ship(map, 4);
            ship[1] = new Ship(map, 3);
            ship[2] = new Ship(map, 3);
            ship[3] = new Ship(map, 2);
            ship[4] = new Ship(map, 2);
            ship[5] = new Ship(map, 2);
            ship[6] = new Ship(map, 1);
            ship[7] = new Ship(map, 1);
            ship[8] = new Ship(map, 1);
            ship[9] = new Ship(map, 1);
            map.FillMap(new System.Random());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
