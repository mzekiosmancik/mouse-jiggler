using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool doJiggle;
        private Thread t1;
        decimal minute = 0;
        int jiggleCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            doJiggle = true;
            t1 = new System.Threading.Thread(DoTheJiggle);
            t1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doJiggle = false;
            jiggleCount = 0;
            label3.Text = "0";

        }

        private void DoTheJiggle()
        {   
            while (doJiggle)
            {
                jiggleCount++;
                Invoke(new Action(() =>
                {
                    label3.Text = Convert.ToString(jiggleCount);
                }));
                
                System.Drawing.Point pt = System.Windows.Forms.Cursor.Position;
                int moveUp = 0;
                Random rnd = new Random();
                int movement = rnd.Next(0, 3);
                switch (movement)
                {
                    case 0:
                        moveUp = -2;
                        break;
                    case 1:
                        //Move up
                        moveUp = -2;
                        break;
                    case 2:
                        //Move down
                        moveUp = 2;
                        break;
                    case 3:
                        //Move down
                        moveUp = 2;
                        break;
                }
                 pt.Y += moveUp;
                System.Windows.Forms.Cursor.Position = pt;
                mouse_event(MOUSEEVENTF_MOVE, 0, moveUp, 0, UIntPtr.Zero);
               

                System.Threading.Thread.Sleep(Convert.ToInt32(minute)*   // minutes to sleep
                                              60 *   // seconds to a minute
                                              1000);
            }
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);
        //private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_MOVE = 01;

        private void Form1_Load(object sender, EventArgs e)
        {
            minute = numericUpDown1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            minute = numericUpDown1.Value;
        }

    }
    

}
