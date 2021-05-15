using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Pong
{
    public partial class Game : UserControl
    {
        public static bool isHost;

        public static IPAddress enemyIP;

        private Timer timerHost = new Timer()
        {
            Interval = 10
        };

        private int ballSpeedY = 0;
        private int ballSpeedX = -10;

        public bool isGoingDown;
        public bool isGoingUp;

        //private Player Player1;
        //private Player Player2;

        UdpClient udpClient;
        Socket sock;

        public Game()
        {
            InitializeComponent();
            timerHost.Tick += TimerHost_Tick;
        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                StartGame();

                udpClient = new UdpClient();
                udpClient.Connect(enemyIP, PongForm.defaultPort);
                sock = udpClient.Client;

                if (isHost)
                {
                    timerHost.Enabled = true;
                }
                else
                {
                    if (timerHost.Enabled)
                    {
                        timerHost.Enabled = false;
                    }
                }
            }
            else
            {
            }
        }

        private void TimerHost_Tick(object sender, EventArgs e)
        {
            Ball.Left += ballSpeedX;
            Ball.Top += ballSpeedY;

            if (isGoingUp)
            {
                Player1.Top -= 5;
            }

            if (isGoingDown)
            {
                Player1.Top += 5;
            }

            if (Ball.Bottom < BottomBorder.Top)
            {
                ballSpeedY = -ballSpeedY;
            }

            if (Ball.Top > TopBorder.Bottom)
            {
                ballSpeedY = -ballSpeedY;
            }

            if (Ball.Right > Bounds.Right || Ball.Left < Bounds.Left)
            {
                Ball.Location = new Point((Width / 2) - (Ball.Width / 2), (Height / 2) - (Ball.Height / 2));
                ballSpeedX = -10;
                ballSpeedY = 0;
            }

            if (Ball.Bounds.IntersectsWith(Player1.Bounds) || Ball.Bounds.IntersectsWith(Player2.Bounds))
            {
                ballSpeedX = -ballSpeedX;

                if (isGoingDown)
                {
                    ballSpeedY -= 2;
                }
                else if(isGoingUp)
                {
                    ballSpeedY += 2;
                }
                else
                {
                    ballSpeedY -= 2;
                }
            }

            Player2.Location = new Point(Player2.Location.X, Ball.Location.Y);
        }

        private void SendData()
        {

        }

        private void StartGame()
        {
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (Player1.Top > TopBorder.Bottom)
                {
                    isGoingUp = true;
                }
                else
                {
                    isGoingUp = false;
                }
            }

            if (e.KeyCode == Keys.S)
            {
                if (Player1.Bottom < BottomBorder.Top)
                {
                    isGoingDown = true;
                }
                else
                {
                    isGoingDown = false;
                }
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                isGoingUp = false;
            }

            if (e.KeyCode == Keys.S)
            {
                isGoingDown = false;
            }
        }
    }
}