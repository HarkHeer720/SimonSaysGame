using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int geuss;
        Random randGen = new Random();
        int randNum;
        int delayTime = 300;

        string greenText = "Green\nGreen\nGreen";
        string redText = "Red\nRed\nRed";
        string yellowText = "Yellow\nYellow\nYellow";
        string blueText = "Blue\nBlue\nBlue";
        FontFamily family = new FontFamily("NSimSun");
        int fontStyle = (int)FontStyle.Bold; 
        int emSize = 30;
        Point origin = new Point(0, 0);
        StringFormat format = StringFormat.GenericDefault;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Form1.randomizerList.Clear();

            //Turning the buttons into text
            GraphicsPath greenTextPath = new GraphicsPath();
            GraphicsPath redTextPath = new GraphicsPath();
            GraphicsPath yellowTextPath = new GraphicsPath();
            GraphicsPath blueTextPath = new GraphicsPath();

            greenTextPath.AddString(greenText, family, fontStyle, emSize, origin, format);
            redTextPath.AddString(redText, family, fontStyle, emSize, origin, format);
            yellowTextPath.AddString(yellowText, family, fontStyle, emSize, origin, format);
            blueTextPath.AddString(blueText, family, fontStyle, emSize, origin, format);

            Region green = new Region(greenTextPath);
            Region red = new Region(redTextPath);
            Region yellow = new Region(yellowTextPath);
            Region blue = new Region(blueTextPath);

            greenButton.Region = yellow;
            redButton.Region = green;
            yellowButton.Region = blue;
            blueButton.Region = red;

            ComputerTurn();
            Refresh();
            Thread.Sleep(delayTime);
        }

        private void ComputerTurn()
        {
            randNum = randGen.Next(0, 4);
            Form1.randomizerList.Add(randNum);

            greenButton.Enabled = false;
            redButton.Enabled = false;
            yellowButton.Enabled = false;
            blueButton.Enabled = false;

            //Turning the buttons into text
            GraphicsPath greenTextPath = new GraphicsPath();
            GraphicsPath redTextPath = new GraphicsPath();
            GraphicsPath yellowTextPath = new GraphicsPath();
            GraphicsPath blueTextPath = new GraphicsPath();

            greenTextPath.AddString(greenText, family, fontStyle, emSize, origin, format);
            redTextPath.AddString(redText, family, fontStyle, emSize, origin, format);
            yellowTextPath.AddString(yellowText, family, fontStyle, emSize, origin, format);
            blueTextPath.AddString(blueText, family, fontStyle, emSize, origin, format);

            Region green = new Region(greenTextPath);
            Region red = new Region(redTextPath);
            Region yellow = new Region(yellowTextPath);
            Region blue = new Region(blueTextPath);

            //green is 0, red is 1, yellow is 2, blue is 3
            for (int i = 0; i < Form1.randomizerList.Count; i++)
            {
                if (Form1.randomizerList[i] == 0)
                {
                    GameLogic(greenButton);
                }
                else if (Form1.randomizerList[i] == 1)
                {
                    GameLogic(redButton);
                }
                else if (Form1.randomizerList[i] == 2)
                {
                    GameLogic(yellowButton);
                }
                else
                {
                    GameLogic(blueButton);
                }
            }
            geuss = 0;

            //randomizing the words on each button
            randNum = randGen.Next(1, 4);
            if (randNum == 1)
            {
                greenButton.Region = yellow;
                redButton.Region = green;
                yellowButton.Region = blue;
                blueButton.Region = red;
            }
            if (randNum == 2)
            {
                greenButton.Region = blue;
                redButton.Region = yellow;
                yellowButton.Region = red;
                blueButton.Region = green;
            }
            if (randNum == 3)
            {
                greenButton.Region = red;
                redButton.Region = blue;
                yellowButton.Region = green;
                blueButton.Region = yellow;
            }

            greenButton.Enabled = true;
            redButton.Enabled = true;
            yellowButton.Enabled = true;
            blueButton.Enabled = true; 
        }

        //button logic upon presses
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.randomizerList[geuss] == 0)
            {
                GameLogic(greenButton);
            }
            else
            {
                Thread.Sleep(delayTime);
                GameOver();
            }
            if (Form1.randomizerList.Count == geuss)
            {
                Thread.Sleep(delayTime);
                Refresh();
                ComputerTurn();
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.randomizerList[geuss] == 1)
            {
                GameLogic(redButton);
            }
            else
            {
                Thread.Sleep(delayTime);
                GameOver();
            }
            if (Form1.randomizerList.Count == geuss)
            {
                Thread.Sleep(delayTime);
                ComputerTurn();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.randomizerList[geuss] == 2)
            {
                GameLogic(yellowButton);
            }
            else
            {
                Thread.Sleep(delayTime);
                GameOver();
            }
            if (Form1.randomizerList.Count == geuss)
            {
                Thread.Sleep(delayTime);
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.randomizerList[geuss] == 3)
            {
                GameLogic(blueButton);
            }
            else
            {
                Thread.Sleep(delayTime);
                GameOver();
            }
            if (Form1.randomizerList.Count == geuss)
            {
                Thread.Sleep(delayTime);
                ComputerTurn();
            }
        }

        //game over method
        public void GameOver()
        {
            Form1.gameOver.Play();
            Thread.Sleep(delayTime);

            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameOverScreen go = new GameOverScreen();
            f.Controls.Add(go);
        }

        //runs game logic based on which button is sent
        public void GameLogic(Button button)
        {
            if (button == greenButton)
            {
                button.BackColor = Color.Lime;
                Form1.blueGeuss.Play();
                Refresh();
                Thread.Sleep(delayTime);
                button.BackColor = Color.ForestGreen;
                Refresh();
                Thread.Sleep(delayTime);
                geuss++;
            }
            else if (button == redButton)
            {
                button.BackColor = Color.Red;
                Form1.blueGeuss.Play();
                Refresh();
                Thread.Sleep(delayTime);
                button.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(delayTime);
                geuss++;
            }
            else if (button == yellowButton)
            {
                button.BackColor = Color.LightYellow;
                Form1.blueGeuss.Play();
                Refresh();
                Thread.Sleep(delayTime);
                button.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(delayTime);
                geuss++;
            }
            else
            {
                button.BackColor = Color.Blue;
                Form1.blueGeuss.Play();
                Refresh();
                Thread.Sleep(delayTime);
                button.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(delayTime);
                geuss++;
            }
        }
    }
}