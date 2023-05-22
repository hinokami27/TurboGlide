# TurboGlide
### Developed by : 
Dragan Golaboski, Viktor Bebek
## Description
Our project is a local multiplayer implementation of the classic Air Hockey arcade game. We've incorporated a modern design alongside retro gaming elements that enhance the competitive features of a *1 keyboard 2 players* style game, which also brings out the nostalgic feeling of playing on a classic arcade game emulator like **MAME**.
### Instructions

![mainWindow](https://github.com/hinokami27/TurboGlide/assets/106191814/44ee39e7-1565-4b86-8512-2f82699e01d9)

Clicking the bottom button labeled **[RULES]** opens a new form that contains a list of rules and objectives of the game. The users can close this form by pressing the **[X]** in the top right corner or the **ESC** key on the keyboard.

The bottom button which shows a gear/cog icon opens another form which contains the keyboard controls for both players. The user can close this form by pressing the **[X]** in the top right corner or the **ESC** key on the keyboard as well.

Once the users are familiar with the rules and controls of the game, they can start the game by clicking the top button labeled **[START GAME]** which opens a new window where the game is played.

## Solution / Implementation
The majority of the variables and logic of the application are contained within the ```GameWindow``` class. The other forms/classes mostly handle the positioning and styling of elements within the same forms, or opening/closing other forms/themselves.
```csharp
 public partial class GameWindow : Form
    {
    //Depending on which keys the users click, these variables control the movement of playerA
        bool goUpA;
        bool goDownA;
        bool goLeftA;
        bool goRightA;
    //Depending on which keys the users click, these variables control the movement of playerB
        bool goUpB;
        bool goDownB;
        bool goLeftB;
        bool goRightB;
    //Adjustable speed of the puck and players
        int PlayerASpeed = 10;
        int PlayerBSpeed = 10;
        int puckSpeedX= 10; 
        int puckSpeedY= 10;
    //The points/goals the players have scored so far
        int PlayerAPoints = 0;
        int PlayerBPoints = 0;
    //These variables prevent ball hogging and accidental own goals
        bool hitA = false;
        bool hitB = false;
    //Used to randomize the direction of the puck after a player hits it    
        Random rnd = new Random();
    //The SoundPlayers allow a sound effect to be played after an event (goal score, collision, player victory)
        SoundPlayer speakerIntersect = new SoundPlayer("hitSound.wav");
        SoundPlayer speakerGoal = new SoundPlayer("goalSound.wav");
        }
```
This is the main function that executes on every timer tick, enabling player movement,
player-puck collision, goal scoring, score keeping and win conditions.
```csharp
private void timer1_Tick(object sender, EventArgs e)
        {
            //At every timer tick, if the player is within his boundaries and is pressing a movement key,
            //they will move towards that direction 10 pixels (== PlayerASpeed)
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
            //Same function exists for PlayerB's boundaries
            
            //Starting puck movement to avoid collision at the start between the two players and the puck
            pbPuck.Top += puckSpeedY;
            pbPuck.Left += puckSpeedX;
            //Puck boundaries
            //When the puck hits a vertical wall, it reverses the direction of its movement,
            //effectively "bouncing off" the wall, also plays a colliding sound effect
            if(pbPuck.Left < 60 || pbPuck.Left > 340)
            {
                puckSpeedX = -puckSpeedX;
                speakerIntersect.Play();
            }
            //Work similar as the if statement above but for horizontal walls 
            //and the hitA/B variables prevent a player from hogging the ball,
            //allowing the player 1 hit per bounce
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
            //Checks if the hitbox of the puck has collided with the hitbox of PlayerA
                if (pbPuck.Bounds.IntersectsWith(pbPlayerA.Bounds))
                {
                    //Sound effect is played
                    speakerIntersect.Play();
                    //the bounce variable allows the puck to have a 50/50 chance at going left or right
                    //after a collision with a player
                    int bounce = 1;
                    //Prevents PlayerA from ball hogging
                    hitA = true;
                    hitB = false;
                    if (rnd.Next() % 2 == 0)
                    {
                        bounce = -1;
                    }
                    //Moves the puck after it bounces off of PlayerA
                    puckSpeedX = 10  * bounce;
                    puckSpeedY = 16 ;
                }
            }
            //Same function exists for when the puck hits PlayerB
           
            //Puck hits PlayerB's goal
            //Checks if the puck's hitbox has collided with PlayerB's goal hitbox
            if (pbPuck.Bounds.IntersectsWith(pbGoalB.Bounds))
            {
                //A point is added to PlayerA's score
                PlayerAPoints += 1;
                if (PlayerAPoints != 5)
                {
                //Plays a sound if it isn't a winning goal
                    speakerGoal.Play();
                }
                //Resetting the positions of the players,
                //giving the puck to the player who conceded a goal
                pbPuck.Location = new Point(208, 494);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 637);
                //Enables both players to be able to hit since no one can ball hog
                hitA = false;
                hitB = false;
                //Makes the ball stationary, favoring the player who conceded
                puckSpeedX = 0;
                puckSpeedY = 0;
                //Changes the background to reflect the current game score
                RefreshBackground();
                //Check if PlayerA's goal is a winning goal
                if (PlayerAPoints == 5)
                {
                //Hides the GameWindow form
                //Opens a new form which has a PlayerA victory image
                //and enables the users to start a new game when closed
                //The new form plays a victory jingle
                //Resets the score of the players, in case they start a new game
                    this.Hide();
                    PWinForm w = new PWinForm();
                    w.BackgroundImage = global::TurboGlide.Properties.Resources.PinkTeamWin;
                    w.ShowDialog();
                    this.Close();
                    PlayerAPoints = 0;
                    PlayerBPoints = 0;
                }
            }
            //Same function exists for when the puck hits PlayerA's goal
        }
```    
