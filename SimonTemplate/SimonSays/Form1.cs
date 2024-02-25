using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        //TODO: create a List to store the pattern. Must be accessable on other screens
        public static List<int> randomizerList = new List<int>();
        public static SoundPlayer greenGeuss = new SoundPlayer(Properties.Resources.green);
        public static SoundPlayer redGeuss = new SoundPlayer(Properties.Resources.red);
        public static SoundPlayer yellowGeuss = new SoundPlayer(Properties.Resources.yellow);
        public static SoundPlayer blueGeuss = new SoundPlayer(Properties.Resources.blue);
        public static SoundPlayer gameOver = new SoundPlayer(Properties.Resources.mistake);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();   

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);

            this.Controls.Add(ms);
        }
    }
}
