using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            aiMap = new ButtonArray(this, new System.Drawing.Point(10, 0));
            imMap = new ButtonArray(this, new System.Drawing.Point(400, 0));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
