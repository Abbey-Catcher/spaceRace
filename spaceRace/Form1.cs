using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace spaceRace
{

    //Abbey Catcher
    //May 11, 2022
    //Space Race - Summative

    public partial class Form1 : Form
    {
        //2 players (WASD & ARROWS)
        //Astroids moving left and right
        //Timer
        //If player collids with astroid, reset player position
        //3 points
        //title screen and game over screen
        //Sounds

        Rectangle player1 = new Rectangle(250, 300, 50, 35);
        Rectangle player2 = new Rectangle(550, 300, 50, 35);
        int playerSpeed = 5;

        List<Rectangle> astroids = new List<Rectangle>();
        List<int> astroidSpeeds = new List<int>();
        int astroidSize = 8;

        bool upArrowDown = false;
        bool downArrowDown = false;

        bool wDown = false;
        bool sDown = false;

        int p1Score = 0;
        int p2Score = 0;

        SolidBrush blueBrush = new SolidBrush(Color.LightSteelBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";
            subTitleLabel.Text = "";
            p1ScoreLabel.Visible = true;
            p2ScoreLabel.Visible = true;

            //play beginning sound
            SoundPlayer beginningSound = new SoundPlayer(Properties.Resources.startGameSound);
            beginningSound.Play();

            //player locations set to bottom of screen
            player1.Location = new Point(250, this.Height - player1.Height);
            player2.Location = new Point(550, this.Height - player2.Height);

            gameTimer.Enabled = true;
            gameState = "running";

            //reset scores
            p1Score = 0;
            p2Score = 0;

            //reset astroids
            astroids.Clear();
            astroidSpeeds.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            //move astroids
            for (int i = 0; i < astroids.Count(); i++)
            {
                //find the new postion of x based on speed 
                int x = astroids[i].X + astroidSpeeds[i];

                //replace the rectangle in the list with updated one using new x 
                astroids[i] = new Rectangle(x, astroids[i].Y, 20, astroidSize);
            }

            //if player reaches top of screen, reset position, add point, and play pointSound
            if (player1.Y == 0)
            {
                player1.Y = this.Height - player1.Height;
                p1Score++;
                p1ScoreLabel.Text = $"{p1Score}";

                //play point sound
                SoundPlayer pointSound = new SoundPlayer(Properties.Resources.pointSound);
                pointSound.Play();
            }
            else if (player2.Y == 0)
            {
                player2.Y = this.Height - player2.Height;
                p2Score++;
                p2ScoreLabel.Text = $"{p2Score}";

                //play point sound
                SoundPlayer pointSound1 = new SoundPlayer(Properties.Resources.pointSound);
                pointSound1.Play();
            }

            //check to see if a new astroid should be created 
            randValue = randGen.Next(0, 101);
            
            if (randValue < 10) //astroids enter from left
            {
                int y = randGen.Next(15, this.Height - 40);
                astroids.Add(new Rectangle(-10, y, astroidSize, astroidSize));
                astroidSpeeds.Add(7);
            }
            else if (randValue < 20) //astroids enter from right
            {
                int y = randGen.Next(15, this.Height - 40);
                astroids.Add(new Rectangle(this.Width, y, astroidSize, astroidSize));
                astroidSpeeds.Add(-7);
            }

            //check if ball is below play area and remove it if it is 
            for (int i = 0; i < astroids.Count(); i++)
            {
                if (astroids[i].Y > this.Height - astroidSize)
                {
                    astroids.RemoveAt(i);
                    astroidSpeeds.RemoveAt(i);
                }
            }

            //check collision of astroids and player 
            for (int i = 0; i < astroids.Count(); i++)
            {
                if (player1.IntersectsWith(astroids[i]))
                {
                    player1.Y = this.Height - player1.Height;

                    //play death sound
                    SoundPlayer deathSound = new SoundPlayer(Properties.Resources.collisionSound);
                    deathSound.Play();
                }
                else if (player2.IntersectsWith(astroids[i]))
                {
                    player2.Y = this.Height - player2.Height;

                    //play death sound
                    SoundPlayer deathSound1 = new SoundPlayer(Properties.Resources.collisionSound);
                    deathSound1.Play();
                }
            }

            //if a player gets 3 points, game ends
            if (p1Score == 3 || p2Score == 3)
            {
                gameTimer.Enabled = false;
                SoundPlayer endSound = new SoundPlayer(Properties.Resources.endSound);
                endSound.Play();
                gameState = "over";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "SPACE RACE";
                subTitleLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                //update labels 
                p1ScoreLabel.Text = $"{p1Score}";
                p2ScoreLabel.Text = $"{p2Score}";

                //players visible
                e.Graphics.DrawImage(Properties.Resources.playerShip, player1);
                e.Graphics.DrawImage(Properties.Resources.playerShip, player2);

                //draw astroids 
                for (int i = 0; i < astroids.Count(); i++)
                {
                    e.Graphics.FillRectangle(blueBrush, astroids[i]);
                }

                //draw center line
                e.Graphics.FillRectangle(whiteBrush, 420, 0, 5, this.Height);
            }
            else if (gameState == "over")
            {
                //clears labels
                p1ScoreLabel.Text = "";
                p2ScoreLabel.Text = "";

                titleLabel.Text = "GAME OVER";

                //if player won, says player_ won
                if (p1Score == 3)
                {
                    subTitleLabel.Text = "Player 1 won!";
                }
                else if (p2Score == 3)
                {
                    subTitleLabel.Text = "Player 2 won!";
                }

                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
            }
        }
    }
}
