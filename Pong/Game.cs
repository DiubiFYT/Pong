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

        IPEndPoint AnyIP = new IPEndPoint(IPAddress.Any, PongForm.defaultPort);
        IPEndPoint iPEndPoint;

        private int ballSpeedY = 0;
        private int ballSpeedX = -10;
        private int ballSpeedYIncrement = 4;
        //private int ballSpeedXIncrement = 4;

        private int playerSpeed = 5;

        public bool isGoingDown;
        public bool isGoingUp;

        private UdpClient udpClient;

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timerHost.Tick += TimerHost_Tick;
            timerGuest.Tick += TimerGuest_Tick;

            iPEndPoint = new IPEndPoint(enemyIP, PongForm.defaultPort);

            udpClient = new UdpClient(PongForm.defaultPort);
            udpClient.Connect(iPEndPoint);

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

        private void TimerHost_Tick(object sender, EventArgs e)
        {
            SendHostData();

            Ball.Left += ballSpeedX;
            Ball.Top += ballSpeedY;

            if (isGoingUp)
            {
                Player1.Top -= playerSpeed;
            }

            if (isGoingDown)
            {
                Player1.Top += playerSpeed;
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
                    ballSpeedY -= ballSpeedYIncrement;
                }
                else if (isGoingUp)
                {
                    ballSpeedY += ballSpeedYIncrement;
                }
                else
                {
                    ballSpeedY -= ballSpeedYIncrement;
                }
            }

            if (Player1.Top < TopBorder.Bottom)
            {
                Player1.Top = TopBorder.Bottom;
            }

            if (Player1.Bottom > BottomBorder.Top)
            {
                Player1.Location = new Point(Player1.Location.X, BottomBorder.Top - Player1.Height);
            }

            Player2.Location = new Point(Player2.Location.X, Ball.Location.Y);

            if (Player2.Top < TopBorder.Bottom)
            {
                Player2.Top = TopBorder.Bottom;
            }

            if (Player2.Bottom > BottomBorder.Top)
            {
                Player2.Location = new Point(Player2.Location.X, BottomBorder.Top - Player1.Height);
            }

            ReceiveGuestData();
        }

        private void TimerGuest_Tick(object sender, EventArgs e)
        {

            ReceiveHostData();

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
            PlayerData playerData = new PlayerData();
            playerData.Position = Player1.Location;

            string serialized = JsonConvert.SerializeObject(playerData);
            byte[] serializedData = Encoding.ASCII.GetBytes(serialized);

            udpClient.Send(serializedData, serializedData.Length);
        }

        private void ReceiveGuestData() //Received by host
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(Encoding.ASCII.GetString(udpClient.Receive(ref iPEndPoint)));

            Player2.Location = playerData.Position;
        }

        private void ReceiveHostData() //Received by guest
        {
            BallData ballData = JsonConvert.DeserializeObject<BallData>(Encoding.ASCII.GetString(udpClient.Receive(ref iPEndPoint)));

            ballSpeedX = -ballData.ballSpeedX;
            ballSpeedY = ballData.ballSpeedY;
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

        public struct PlayerData
        {
            public Point Position;
        }
    }
}