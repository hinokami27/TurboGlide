using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboGlide
{
    public partial class GameWindow : Form
    {
        bool goUp1;
        bool goDown1;
        bool goLeft1;
        bool goRight1;

        bool goUp2;
        bool goDown2;
        bool goLeft2;
        bool goRight2;

        int p1Speed = 5;
        int p2Speed = 5;

        public GameWindow()
        {
            InitializeComponent();
            timer1.Start();
            DoubleBuffered = true;
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(goUp1 == true)
            {
                pbPlayerA.Top -= p1Speed;
            }
            if(goDown1 == true)
            {
                pbPlayerA.Top += p1Speed;
            }
            if(goLeft1 == true)
            {
                pbPlayerA.Left -= p1Speed;
            }
            if(goRight1 == true)
            {
                pbPlayerA.Left += p1Speed;
            }

            if (goUp2 == true)
            {
                pbPlayerB.Top -= p2Speed;
            }
            if (goDown2 == true)
            {
                pbPlayerB.Top += p2Speed;
            }
            if (goLeft2 == true)
            {
                pbPlayerB.Left -= p2Speed;
            }
            if (goRight2 == true)
            {
                pbPlayerB.Left += p2Speed;
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                goUp1 = true;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown1 = true;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeft1 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight1 = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp2 = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown2 = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft2 = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight2 = true;
            }

        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                goUp1 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown1 = false;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeft1 = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight1 = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp2 = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown2 = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft2 = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight2 = false;
            }
        }
    }
}
