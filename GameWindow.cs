﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboGlide
{
    public partial class GameWindow : Form
    {
        bool goUpA;
        bool goDownA;
        bool goLeftA;
        bool goRightA;

        bool goUpB;
        bool goDownB;
        bool goLeftB;
        bool goRightB;

        int p1Speed = 10;
        int p2Speed = 10;
        int puckSpeedX= 8; 
        int puckSpeedY= 8;

        int PlayerAPoints = 0;
        int PlayerBPoints = 0;

        bool hitA = false;
        bool hitB = false;
        Random rnd = new Random();
        public int randomNum { get; set; }


        public GameWindow()
        {
            InitializeComponent();
            timer1.Start();
            DoubleBuffered = true;
            
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            pbPlayerA.Location = new Point(200, 65);
            pbPlayerB.Location = new Point(200, 638);
            pbPuck.Location = new Point(208, 357);
            pbGoalB.Location = new Point(171, 709);
            pbGoalA.Location = new Point(171, 30);
            randomNum = rnd.Next();
            Console.WriteLine(randomNum.ToString());
            lbPointsA.Text = "Plaeyr A: ";
            lbPointsB.Text = "Player B: ";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(goUpA == true && pbPlayerA.Top > 55)
            {
                pbPlayerA.Top -= p1Speed;
            }
            if(goDownA == true && pbPlayerA.Top < 315)
            {
                pbPlayerA.Top += p1Speed;
            }
            if(goLeftA == true && pbPlayerA.Left > 60)
            {
                pbPlayerA.Left -= p1Speed;
            }
            if(goRightA == true && pbPlayerA.Left < 340)
            {
                pbPlayerA.Left += p1Speed;
            }

            if (goUpB == true && pbPlayerB.Top > 388)
            {
                pbPlayerB.Top -= p2Speed;
            }
            if (goDownB == true && pbPlayerB.Top < 648)
            {
                pbPlayerB.Top += p2Speed;
            }
            if (goLeftB == true && pbPlayerB.Left > 60)
            {
                pbPlayerB.Left -= p2Speed;
            }
            if (goRightB == true && pbPlayerB.Left < 340)
            {
                pbPlayerB.Left += p2Speed;
            }
            //Puck slide at GameStart to avoid 2player 1puck collision
            if (randomNum % 2 == 0)
            {
                pbPuck.Top -= puckSpeedY;
                pbPuck.Left += puckSpeedX;

            }
            else
            {
                pbPuck.Top += puckSpeedY;
                pbPuck.Left += puckSpeedX;
            }
            if(pbPuck.Left < 60 || pbPuck.Left > 340)
            {
                puckSpeedX = -puckSpeedX;
            }
            if(pbPuck.Top < 55 || pbPuck.Top > 664)
            {
                puckSpeedY = -puckSpeedY;
                hitA = false;
                hitB = false;
            }
            if (!hitA)
            {
                if (pbPuck.Bounds.IntersectsWith(pbPlayerA.Bounds))
                {
                    //puckSpeedY = -puckSpeedY;
                    int speedBoost = 0;
                    int bounce = 1;
                    hitA = true;
                    hitB = false;
                    if (rnd.Next() % 2 == 0)
                    {
                        speedBoost++;
                        bounce = -1;
                    }
                    puckSpeedX = (8 + speedBoost) * bounce;
                    puckSpeedY = -8 + speedBoost;
                }
            }
            if (!hitB)
            {
                if (pbPuck.Bounds.IntersectsWith(pbPlayerB.Bounds))
                {
                    //puckSpeedY = -puckSpeedY;
                    int speedBoost = 0;
                    int bounce = 1;
                    hitB = true;
                    hitA = false;
                    if (rnd.Next() % 2 == 0)
                    {
                        speedBoost++;
                    }
                    if (rnd.Next() % 2 == 0)
                    { 
                        bounce = -1;
                    }
                    puckSpeedX = (-8 - speedBoost) * bounce;
                    puckSpeedY = 8 - speedBoost;
                }
            }
            if(pbPuck.Bounds.IntersectsWith(pbGoalA.Bounds))
            {
                PlayerBPoints+=1;
                pbPuck.Location = new Point(208, 225);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 638);
                lbPointsB.Text = "Player B: " +PlayerBPoints.ToString();
                hitA = false;
                hitB = false;
                puckSpeedX = 0;
                puckSpeedY = 0;
                     
            }
            if (pbPuck.Bounds.IntersectsWith(pbGoalB.Bounds))
            {
                PlayerAPoints += 1;
                pbPuck.Location = new Point(208, 494);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 638);
                lbPointsA.Text = "Player A: " + PlayerAPoints.ToString();
                hitA = false;
                hitB = false;
                puckSpeedX = 0;
                puckSpeedY = 0;

            }

        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                goUpA = true;
            }
            if (e.KeyCode == Keys.S)
            {
                goDownA = true;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeftA = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRightA = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUpB = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDownB = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeftB = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRightB = true;
            }

        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                goUpA = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDownA = false;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeftA = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRightA = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUpB = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDownB = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeftB = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRightB = false;
            }
        }
    }
}
