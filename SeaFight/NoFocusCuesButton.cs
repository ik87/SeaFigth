using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SeaFight
{
    
    class NoFocusCuesButton : Button
    {
        private Point buttonIndex; 
        public Point ButtonIndex {
            get{ return buttonIndex; }
            set { buttonIndex = value; }
        }

        public void NoSelectButton()
        {

            SetStyle(ControlStyles.Selectable, false);

        }
    }
}
