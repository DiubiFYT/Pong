using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Pong
{
    public partial class Game : UserControl
    {
        public static bool isHost;

        public static IPAddress enemyIP = IPAddress.Parse(Methods.GetPrivateIP()); //I can't set it as null because it throws an exception idk

        private Timer timerHost = new Timer()
        {
            Interval = 10
        };

        private Timer timerGuest = new Timer()
        {
            Interval = 10
        };

        private int ballSpeedY = 0;
        private int ballSpeedX = -10;

        public bool isGoingDown;
        public bool isGoingUp;

        //private Player Player1;
        //private Player Player2;

        private UdpClient udpClient = new UdpClient();

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timerHost.Tick += TimerHost_Tick;
            timerGuest.Tick += TimerGuest_Tick;
        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                StartGame();

                udpClient.Connect(enemyIP, PongForm.defaultPort);
                //sock = udpClient.Client;

                if (isHost)
                {
                    timerHost.Enabled = true;
                    timerGuest.Enabled = false;
                }
                else
                {
                    timerHost.Enabled = false;
                    timerGuest.Enabled = true;
                }
            }
            else
            {
            }
        }

        private void TimerHost_Tick(object sender, EventArgs e)
        {
            ReceiveGuestData();

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
                else if (isGoingUp)
                {
                    ballSpeedY += 2;
                }
                else
                {
                    ballSpeedY -= 2;
                }
            }

            Player2.Location = new Point(Player2.Location.X, Ball.Location.Y);

            SendHostData();
        }

        private void TimerGuest_Tick(object sender, EventArgs e)
        {
            ReceiveHostData();

            if (isGoingUp)
            {
                Player1.Top -= 5;
            }

            if (isGoingDown)
            {
                Player1.Top += 5;
            }

            SendGuestData();
        }

        private void SendHostData() //Sent from host
        {
            BallData ballData = new BallData();
            ballData.ballSpeedX = ballSpeedX;
            ballData.ballSpeedY = ballSpeedY;
            ballData.Location = Ball.Location;

            string serialized = JsonConvert.SerializeObject(ballData);
            byte[] serializedData = Encoding.ASCII.GetBytes(serialized);
            udpClient.Send(serializedData, serializedData.Length);
        }

        private void SendGuestData() //Sent from guest
        {
        }

        private void ReceiveGuestData() //Received by guest
        {
        }

        private void ReceiveHostData() //Received by host
        {
            Socket sock = udpClient.Client;
            EndPoint endPoint = sock.RemoteEndPoint;
            byte[] data = new byte[50];
            int k = sock.Receive(data);
            //BallData ballData = (BallData)JsonConvert.DeserializeObject(Encoding.ASCII.GetString(udpClient.Receive(ref endPoint)));

            //ballSpeedX = -ballData.ballSpeedX;
            //ballSpeedY = ballData.ballSpeedY;
            //Ball.Location = new Point(-ballData.Location.X, ballData.Location.Y);
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

        public struct BallData
        {
            public int ballSpeedY;
            public int ballSpeedX;
            public Point Location;
        }
    }
}