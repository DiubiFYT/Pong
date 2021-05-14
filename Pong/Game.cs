using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Pong
{
    public partial class Game : UserControl
    {
        private bool isHost;

        private Timer timer = new Timer()
        {
            Interval = 50
        };

        private int ballSpeedY = 0;
        private int ballSpeedX = 2;

        public Game()
        {
            InitializeComponent();
        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                StartGame();

                if (isHost)
                {
                    timer.Enabled = true;
                    timer.Tick += Timer_Tick;
                }
            }
            else
            {

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Ball.Left += ballSpeedX;
            Ball.Top += ballSpeedY;
        }

        private void SendData()
        {

        }

        private void StartGame()
        {
            
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                if(Player1.Top != TopBorder.Bottom)
                {
                    Player1.Top -= 8;
                }
            }
            
            if(e.KeyCode == Keys.S)
            {
                if(Player1.Bottom != BottomBorder.Top)
                {
                    Player1.Top += 8;
                }
            }
        }
    }
}
