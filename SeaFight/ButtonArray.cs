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
        public ButtonArray(System.Windows.Forms.Form host, Point pos)
        {
            game = new SeaFight.Game();
            HostForm = host;
            AddNewButton(pos);
        }

        public ButtonArray(System.Windows.Forms.Form host)
        {
            game = new SeaFight.Game();
            HostForm = host;
            AddNewButton(new Point(0,0));
        }
        /*
                 static void draw(Map map) {
            char a = 'А';
            for (int i = 0; i < Map.SIZE - 1; i++)
            {   if(i != 10)
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
                        if (map.getMap()[i, j] == 'o')
                            Console.Write(" o ");
                        else
                            Console.Write(" . ");
                    }
                }
                Console.WriteLine();
                
            }
        }
             */

        public NoFocusCuesButton[,] AddNewButton(Point pos)
        {
            buttons = new NoFocusCuesButton[Map.SIZE, Map.SIZE];

            for (int y = 1; y < Map.SIZE - 1; y++) {
                
                HostForm.Controls.Add(setLabel(new Point(0, y), pos, 'y'));

                for (int x = 1; x < Map.SIZE - 1; x++) {

                    if (y == 1)
                    {
                        HostForm.Controls.Add(setLabel(new Point(x, 0), pos, 'x'));
                    }


                        buttons[y, x] = new NoFocusCuesButton();
                        buttons[y, x].ButtonIndex = new Point(x, y);
                        buttons[y, x].BackColor = System.Drawing.SystemColors.ActiveCaption;
                        buttons[y, x].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                        buttons[y, x].Size = new System.Drawing.Size(30, 30);
                        buttons[y, x].UseVisualStyleBackColor = false;
                        buttons[y, x].Left = pos.X + 32 * x;
                        buttons[y, x].Top = pos.Y + 32 * y;
                        buttons[y, x].NoSelectButton();
                        buttons[y, x].Click += new System.EventHandler(ClickHandler);
                        buttons[y, x].TabStop = false;
                        buttons[y, x].FlatStyle = FlatStyle.Flat;
                        buttons[y, x].FlatAppearance.BorderSize = 0;

                        HostForm.Controls.Add(buttons[y, x]);
                   
                }

            }
            // Add the button to the controls collection of the form 
            // referenced by the HostForm field.

            // Set intial properties for the button object.
            //  aButton.Top = Count * 25;
            //  aButton.Left = 100;
            //  aButton.Tag = Count;
            // aButton.Text = "Button " + Count.ToString();
            //  aButton.Click += new System.EventHandler(ClickHandler);


            //   button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            //   button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            //   button1.Location = new System.Drawing.Point(12, 12);
            //   button1.Name = "button1";
            //  button1.Size = new System.Drawing.Size(30, 30);
            //  button1.TabIndex = 0;
            //   button1.TabStop = false;
            //   button1.UseVisualStyleBackColor = false;
            //    button1.Click += new System.EventHandler(button1_Click);


            return buttons;
        }



        public NoFocusCuesButton this[int y, int x]
        {
            get
            {
                return (NoFocusCuesButton)buttons[y, x];
            }
        }



        public void ClickHandler(Object sender, System.EventArgs e)
        {

            game.Shot(((NoFocusCuesButton)sender).ButtonIndex);
            for (int y = 1; y < Map.SIZE - 1; y++)
            {
                for (int x = 1; x < Map.SIZE - 1; x++)
                {
                    if (game.map.GetMap[y, x] == Map.HIT)
                    {
                        buttons[y,x].BackColor = System.Drawing.SystemColors.ControlDark;
                    }
                    else if (game.map.GetMap[y, x] == Map.MISSED)
                    {
                        buttons[y, x].BackColor = System.Drawing.SystemColors.ButtonHighlight;
                    }
                }
            }

        }

        private System.Windows.Forms.Label setLabel(Point pos, Point offset, char xy) {
            System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
            
            if(pos.Y == 10)
            label1.Left = offset.X + (pos.X == 0 ? 0 : 32 * pos.X);
            else
            label1.Left = offset.X + (pos.X == 0 ? 7 : 32 * pos.X);
            label1.Top = offset.Y +  (pos.Y == 0 ? 7 : 32 * pos.Y);
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.ForeColor = System.Drawing.Color.Crimson;
            //label1.Location = pos;
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = (xy == 'x' ? ((char)('А' + pos.X - 1)).ToString() : pos.Y.ToString());
            label1.Size = new System.Drawing.Size(26, 29);
            label1.TabIndex = 0;
            label1.Text = (xy == 'x' ? ((char)('А' + pos.X - 1)).ToString() : pos.Y.ToString());
            label1.BackColor = System.Drawing.Color.Transparent;
            return label1;
        }

        private readonly System.Windows.Forms.Form HostForm;
        private NoFocusCuesButton[,] buttons;
        
        private Game game;
    }
}
