# TurboGlide
#### Еnglish / [Македонски](#изработено-од)
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
        int puckSpeedX = 10; 
        int puckSpeedY = 10;
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
            //Works similar to the if statement above but for horizontal walls 
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
#

### Изработено од:

Драган Голабоски, Виктор Бебек

## Опис

Нашиот проект е верзија на класичната аркадна игра "Air Hockey", адаптирана за два играчи. Модерниот дизајн на апликацијата заедно со елементи од ретро аркадни игри носат носталгично чувство на играње на класичен емулатор како **MAME**.

### Упатство

При клик на копчето со натпис **[RULES]** се отвара нов прозорец со листа од правила за играта. Прозорецот се затвора со притискање на копчето **[X]** од самиот прозорец или со **[ESC]** на тастатурата.

Копчето со слика од запчаник отвара нов прозорец каде корисниците можат да ги видат контролите за играта. Прозорецот се затвора со притискање на копчето **[X]** од самиот прозорец или со **[ESC]** на тастатурата.

Откако корисниците ќе се запознаат со правилата и контролите на играта, може да започнат нова игра со притискање на копчето со натпис [**[START GAME]**](#instructions), при што се отвара нов прозорец каде што играта започнува.

## Имплементација

Повеќето од променливите и логиката на програмата се состојат во класата ```GameWindow```. Останатите форми/класи се надлежни за позиционирање и стилизирање на елементите, како и отварање/затворање на други форми/самите себеси.

```
 public partial class GameWindow : Form
    {
    //Овие променливи го контролираат движењето на играчотА
        bool goUpA;
        bool goDownA;
        bool goLeftA;
        bool goRightA;
    //Овие променливи го контролираат движењето на играчотБ
        bool goUpB;
        bool goDownB;
        bool goLeftB;
        bool goRightB;
    //Променлива брзина на играчите и пакот
        int PlayerASpeed = 10;
        int PlayerBSpeed = 10;
        int puckSpeedX = 10; 
        int puckSpeedY = 10;
    //Поените освоени од страна на двајцата играчи
        int PlayerAPoints = 0;
        int PlayerBPoints = 0;
    //Овие променливи спречуваат авто-голови и држење на топката
        bool hitA = false;
        bool hitB = false;
    //Се користи за да се смени движењето на пакот по случаен агол   
        Random rnd = new Random();
    //Овозможуваат да се слушнат звучни ефекти кога ќе се постигне гол, при контакт со пакот и победа на еден играч
        SoundPlayer speakerIntersect = new SoundPlayer("hitSound.wav");
        SoundPlayer speakerGoal = new SoundPlayer("goalSound.wav");
        }
```
Главната функција во програмата се извршува не секое отчукување на тајмерот и овозможува движење на играчите, колизија, постигнување голови, пратење на поените и услови за победа.

```
private void timer1_Tick(object sender, EventArgs e)
        {
            //На секое отчукување, ако играшот притиска копче за движење, играчот ќе се движи во таа насока
            //сè додека е во дозволените граници
            //Граници на играчотА
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
            //Иста функција постои и за играчотБ
            
            //Го движи пакот на почетокот од играта
            pbPuck.Top += puckSpeedY;
            pbPuck.Left += puckSpeedX;
            //Граници на пакот
            //Кога пакот удира во вертикален ѕид, тој ја менува насоката на неговото движење,
            //со што "отскокнува" од ѕидот
            if(pbPuck.Left < 60 || pbPuck.Left > 340)
            {
                puckSpeedX = -puckSpeedX;
                speakerIntersect.Play();
            }
            //Работи на сличен начин како горната функција но за хоризонталната граница
            //променливата hitA/B го спречува држењето на топката од страна на играчот ,
            //дозволува само 1 удар при секое отскокнување
            if(pbPuck.Top < 55 || pbPuck.Top > 664)
            {
                puckSpeedY = -puckSpeedY;
                speakerIntersect.Play();
                hitA = false;
                hitB = false;
            }
            //Пакот го удира играчотА
            if (!hitA)
            {
            //Проверуваме дали пакот се судрил со играчотА
                if (pbPuck.Bounds.IntersectsWith(pbPlayerA.Bounds))
                {
                    //Звучен ефект
                    speakerIntersect.Play();
                    //Променливата bounce случајно го турка пакот лево или десно
                    //при колизија со играчот
                    int bounce = 1;
                    //Спречува играчотА да го држи пакот
                    hitA = true;
                    hitB = false;
                    if (rnd.Next() % 2 == 0)
                    {
                        bounce = -1;
                    }
                    //Го движи пакот при колизија со играчот
                    puckSpeedX = 10  * bounce;
                    puckSpeedY = 16 ;
                }
            }
            //Постои иста функција и за колизија на пакот со играчотБ
           
            //Пакот удира во голот на играчотБ
            //Проверуваме дали пакот се судрил со границите на голот на играчотБ
            if (pbPuck.Bounds.IntersectsWith(pbGoalB.Bounds))
            {
                //Додава поен на играчотА
                PlayerAPoints += 1;
                if (PlayerAPoints != 5)
                {
                //Звучен ефект се пушта ако играчот нема победено
                    speakerGoal.Play();
                }
                //Се ресетира позицијата на играчите,
                //а пакот е доделен на играчот кој примил гол
                pbPuck.Location = new Point(208, 494);
                pbPlayerA.Location = new Point(200, 65);
                pbPlayerB.Location = new Point(200, 637);
                //Овозможуваат пакот да може било кој од играчите да го удри
                hitA = false;
                hitB = false;
                //Ја правиме топката стационарна и 
                //ја доделуваме на половината на играчот кој што примил гол
                puckSpeedX = 0;
                puckSpeedY = 0;
                //Се променува позадината каде што е запишан резултатот
                RefreshBackground();
                //Проверуваме дали играчотА има доволно поени за победа
                if (PlayerAPoints == 5)
                {
                //Се затвора главниот прозорец
                //Отвара нов прозорец кој содржи порака за победникот
                //и овозможува да се започне нова игра кога ќе се затвори прозорот
                //Формата пушта победничка песна
                //Се ресетира резултатот за нова игра
                    this.Hide();
                    PWinForm w = new PWinForm();
                    w.BackgroundImage = global::TurboGlide.Properties.Resources.PinkTeamWin;
                    w.ShowDialog();
                    this.Close();
                    PlayerAPoints = 0;
                    PlayerBPoints = 0;
                }
            }
            //Постои иста функција и за судир со голот на играчотА
        }
```



