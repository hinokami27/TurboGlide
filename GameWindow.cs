using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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

        int PlayerASpeed = 10;
        int PlayerBSpeed = 10;
        int puckSpeedX= 10; 
        int puckSpeedY= 10;

        int PlayerAPoints = 0;
        int PlayerBPoints = 0;

        bool hitA = false;
        bool hitB = false;
        Random rnd = new Random();

        SoundPlayer speakerIntersect = new SoundPlayer("hitSound.wav");
        SoundPlayer speakerGoal = new SoundPlayer("goalSound.wav");

        public GameWindow()
        {
            InitializeComponent();
            timer1.Start();
            DoubleBuffered = true;
        }
        //Set positions for game start
        private void GameWindow_Load(object sender, EventArgs e)
        {
            pbPlayerA.Location = new Point(200, 65);
            pbPlayerB.Location = new Point(200, 637);
            pbPuck.Location = new Point(208, 357);
            pbGoalB.Location = new Point(171, 709);
            pbGoalA.Location = new Point(171, 30);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //PlayerA boundaries
            if(goUpA == true && pbPlayerA.Top > 55)
            {
                pbPlayerA.Top -= PlayerASpeed;
            }
            if(goDownA == true && pbPlayerA.Top < 315)
            {
                pbPlayerA.Top += PlayerASpeed;
            }
            if(goLeftA == true && pbPlayerA.Left > 70)
            {
                pbPlayerA.Left -= PlayerASpeed;
            }
            if(goRightA == true && pbPlayerA.Left < 330)
            {
                pbPlayerA.Left += PlayerASpeed;
            }
            //PlayerB boundaries
            if (goUpB == true && pbPlayerB.Top > 388)
            {
                pbPlayerB.Top -= PlayerBSpeed;
            }
            if (goDownB == true && pbPlayerB.Top < 648)
            {
                pbPlayerB.Top += PlayerBSpeed;
            }
            if (goLeftB == true && pbPlayerB.Left > 70)
            {
                pbPlayerB.Left -= PlayerBSpeed;
            }
            if (goRightB == true && pbPlayerB.Left < 330)
            {
                pbPlayerB.Left += PlayerBSpeed;
            }
            //Starting puck movement
            pbPuck.Top += puckSpeedY;
            pbPuck.Left += puckSpeedX;
            //Puck boundaries
            if(pbPuck.Left < 60 || pbPuck.Left > 340)
            {
                puckSpeedX = -puckSpeedX;
                speakerIntersect.Play();
            }
            if(pbPuck.Top < 55 || pbPuck.Top > 664)
            {
                puckSpeedY = -puckSpeedY;
                speakerIntersect.Play();
                hitA = false;
                hitB = false;
            }
            //Puck hits PlayerA
            if (!hitA)
            {
                if (pbPuck.Bounds.IntersectsWith(pbPlayerA.Bounds))
                {
                    speakerIntersect.Play();
                    int bounce = 1;
                    hitA = true;
                    hitB = false;
                    if (rnd.Next() % 2 == 0)
                    {
                        bounce = -1;
                    }
                    puckSpeedX = 10  * bounce;
                    puckSpeedY = 16 ;
                }
            }
            //Puck hits PlayerB
            if (!hitB)
            {
                if (pbPuck.Bounds.IntersectsWith(pbPlayerB.Bounds))
                {
                    speakerIntersect.Play();
                    int bounce = 1;
                    hitB = true;
                    hitA = false;                 
                    if (rnd.Next() % 2 == 0)
                    { 
                        bounce = -1;
                    }
                    puckSpeedX = -10  * bounce;
                    puckSpeedY = -16 ;
                }
            }
            //Puck hits PlayerA's goal
            if(pbPuck.Bounds.IntersectsWith(pbGoalA.Bounds))
            {
                PlayerBPoints += 1;
                if (PlayerBPoints != 5)
                {
                    speakerGoal.Play();
                }
                pbPuck.Location = new Point(208, 225);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 637);
                hitA = false;
                hitB = false;
                puckSpeedX = 0;
                puckSpeedY = 0;
                RefreshBackground();
                if (PlayerBPoints == 5)
                {
                    this.Hide();
                    PWinForm w = new PWinForm();
                    w.BackgroundImage = global::TurboGlide.Properties.Resources.BlueTeamWin;
                    w.ShowDialog();
                    this.Close();
                    PlayerAPoints = 0;
                    PlayerBPoints = 0;
                }
            }
            //Puck hits PlayerB's goal
            if (pbPuck.Bounds.IntersectsWith(pbGoalB.Bounds))
            {
                PlayerAPoints += 1;
                if (PlayerAPoints != 5)
                {
                    speakerGoal.Play();
                }
                pbPuck.Location = new Point(208, 494);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 637);
                hitA = false;
                hitB = false;
                puckSpeedX = 0;
                puckSpeedY = 0;
                RefreshBackground();
                if (PlayerAPoints == 5)
                {
                    this.Hide();
                    PWinForm w = new PWinForm();
                    w.BackgroundImage = global::TurboGlide.Properties.Resources.PinkTeamWin;
                    w.ShowDialog();
                    this.Close();
                    PlayerAPoints = 0;
                    PlayerBPoints = 0;
                }
            }
        }
        //Refresh the background to reflect the score
        public void RefreshBackground()
        {
            //0-X
            if (PlayerAPoints == 0 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard01;
            }
            if (PlayerAPoints == 0 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard02;
            }
            if (PlayerAPoints == 0 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard03;
            }
            if (PlayerAPoints == 0 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard04;
            }
            if (PlayerAPoints == 0 && PlayerBPoints == 5)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard05;
            }
            //1-X
            if (PlayerAPoints == 1 && PlayerBPoints == 0)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard10;
            }
            if (PlayerAPoints == 1 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard11;
            }
            if (PlayerAPoints == 1 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard12;
            }
            if (PlayerAPoints == 1 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard13;
            }
            if (PlayerAPoints == 1 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard14;
            }
            if (PlayerAPoints == 1 && PlayerBPoints == 5)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard15;
            }
            //2-X
            if (PlayerAPoints == 2 && PlayerBPoints == 0)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard20;
            }
            if (PlayerAPoints == 2 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard21;
            }
            if (PlayerAPoints == 2 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard22;
            }
            if (PlayerAPoints == 2 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard23;
            }
            if (PlayerAPoints == 2 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard24;
            }
            if (PlayerAPoints == 2 && PlayerBPoints == 5)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard25;
            }
            //3-X
            if (PlayerAPoints == 3 && PlayerBPoints == 0)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard30;
            }
            if (PlayerAPoints == 3 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard31;
            }
            if (PlayerAPoints == 3 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard32;
            }
            if (PlayerAPoints == 3 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard33;
            }
            if (PlayerAPoints == 3 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard34;
            }
            if (PlayerAPoints == 3 && PlayerBPoints == 5)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard35;
            }
            //4-X
            if (PlayerAPoints == 4 && PlayerBPoints == 0)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard40;
            }
            if (PlayerAPoints == 4 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard41;
            }
            if (PlayerAPoints == 4 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard42;
            }
            if (PlayerAPoints == 4 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard43;
            }
            if (PlayerAPoints == 4 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard44;
            }
            if (PlayerAPoints == 4 && PlayerBPoints == 5)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard45;
            }
            //5-X
            if (PlayerAPoints == 5 && PlayerBPoints == 0)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard50;
            }
            if (PlayerAPoints == 5 && PlayerBPoints == 1)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard51;
            }
            if (PlayerAPoints == 5 && PlayerBPoints == 2)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard52;
            }
            if (PlayerAPoints == 5 && PlayerBPoints == 3)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard53;
            }
            if (PlayerAPoints == 5 && PlayerBPoints == 4)
            {
                GameWindow.ActiveForm.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard54;
            }
        }
        //Move player on KeyDown
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
        //Stop player movement on KeyUp
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
