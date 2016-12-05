using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight
{
    class ButtonArray
    {
        public ButtonArray(System.Windows.Forms.Form host)
        {
            
            HostForm = host;
            this.AddNewButton();
        }

        public NoFocusCuesButton[,] AddNewButton()
        {
            // Create a new instance of the Button class.
            buttons = new NoFocusCuesButton[Map.MAPSIZE, Map.MAPSIZE];
            // Add the button to the collection's internal list.
            for (int y = 1; y < Map.MAPSIZE - 1; y++) {
                for (int x = 1; x < Map.MAPSIZE - 1; x++) {
                    
                    buttons[y, x] = new NoFocusCuesButton();
                    buttons[y, x].ButtonIndex = new Point(y, x);
                    buttons[y, x].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    buttons[y, x].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    buttons[y, x].Size = new System.Drawing.Size(30, 30);
                    buttons[y, x].UseVisualStyleBackColor = false;
                    buttons[y, x].Location = new Point((12 + 18) * x, (12 + 18) * y);
                    buttons[y, x].NoSelectButton();
                    buttons[y, x].Click += new System.EventHandler(ClickHandler);
                    HostForm.Controls.Add(buttons[y, x]);
                }
                
            }
            // Add the button to the controls collection of the form 
            // referenced by the HostForm field.
            
            // Set intial properties for the button object.
          //  aButton.Top = Count * 25;
          //  aButton.Left = 100;
          //  aButton.Tag = this.Count;
           // aButton.Text = "Button " + this.Count.ToString();
          //  aButton.Click += new System.EventHandler(ClickHandler);


         //   this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
         //   this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         //   this.button1.Location = new System.Drawing.Point(12, 12);
         //   this.button1.Name = "button1";
          //  this.button1.Size = new System.Drawing.Size(30, 30);
          //  this.button1.TabIndex = 0;
         //   this.button1.TabStop = false;
         //   this.button1.UseVisualStyleBackColor = false;
        //    this.button1.Click += new System.EventHandler(this.button1_Click);


            return buttons;
        }

        public NoFocusCuesButton this[int y, int x]
        {
            get
            {
                return (NoFocusCuesButton)this.buttons[y, x];
            }
        }

 

        public void ClickHandler(Object sender, System.EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("You have clicked button " +
                ((NoFocusCuesButton)sender).ButtonIndex
                );
      
        }

        private readonly System.Windows.Forms.Form HostForm;
        private NoFocusCuesButton[,] buttons;
    }
}
