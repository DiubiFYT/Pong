using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

        private IPEndPoint iPEndPoint;

        private int ballSpeedY = 0;
        private int ballSpeedX = -12;
        private int ballSpeedYIncrement = 6;
        //private int ballSpeedXIncrement = 4;

        private int playerSpeed = 5;

        private int p1Score = 0;
        private int p2Score = 0;

        public bool isGoingDown;
        public bool isGoingUp;

        public static bool inGame;

        private UdpClient senderUdpClient;
        private UdpClient receiverUdpClient;

        public Game()
        {
            InitializeComponent();
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Font = new Font(PongForm.pfc.Families[0], c.Font.Size);
            }

            timerHost.Tick += TimerHost_Tick;
            timerGuest.Tick += TimerGuest_Tick;

            iPEndPoint = new IPEndPoint(enemyIP, PongForm.defaultPort + 10);

            receiverUdpClient = new UdpClient(PongForm.defaultPort + 10);
            receiverUdpClient.AllowNatTraversal(true);
            receiverUdpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
            receiverUdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            senderUdpClient = new UdpClient();
            senderUdpClient.AllowNatTraversal(true);
            senderUdpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
            senderUdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            senderUdpClient.Connect(iPEndPoint);

            Task.Run(() => ReceiveQuit());

            inGame = true;

            if (isHost)
            {
                timerHost.Enabled = true;
                timerGuest.Enabled = false;
            }
            else
            {
                timerGuest.Enabled = true;
                timerHost.Enabled = false;
            }
        }

        private void TimerHost_Tick(object sender, EventArgs e)
        {
            SendHostData();
            ReceiveGuestData();

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

            if (Ball.Bottom < Bottom)
            {
                ballSpeedY = -ballSpeedY;
            }

            if (Ball.Top > Top)
            {
                ballSpeedY = -ballSpeedY;
            }

            if (Ball.Right > Bounds.Right)
            {
                Ball.Location = new Point((Width / 2) - (Ball.Width / 2), (Height / 2) - (Ball.Height / 2));
                ballSpeedX = -12;
                ballSpeedY = 0;

                p1Score++;
                lblPlayer1Score.Text = p1Score.ToString();
            }

            if (Ball.Left < Bounds.Left)
            {
                Ball.Location = new Point((Width / 2) - (Ball.Width / 2), (Height / 2) - (Ball.Height / 2));
                ballSpeedX = 12;
                ballSpeedY = 0;

                p2Score++;
                lblPlayer2Score.Text = p2Score.ToString();
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

            if (Player1.Top < Top)
            {
                Player1.Top = Top;
            }

            if (Player1.Bottom > Bottom)
            {
                Player1.Location = new Point(Player1.Location.X, Bottom - Player1.Height);
            }
        }

        private void TimerGuest_Tick(object sender, EventArgs e)
        {
            SendGuestData();
            ReceiveHostData();

            if (isGoingUp)
            {
                Player1.Top -= playerSpeed;
            }

            if (isGoingDown)
            {
                Player1.Top += playerSpeed;
            }

            if (Player1.Top < Top)
            {
                Player1.Top = Top;
            }

            if (Player1.Bottom > Bottom)
            {
                Player1.Location = new Point(Player1.Location.X, Bottom - Player1.Height);
            }
        }

        private void SendHostData() //Sent from host
        {
            PlayerData playerData = new PlayerData();
            playerData.Position = Player1.Location;

            string serialized = JsonConvert.SerializeObject(playerData);
            byte[] serializedData = Encoding.ASCII.GetBytes(serialized);

            senderUdpClient.Send(serializedData, serializedData.Length);

            BallData ballData = new BallData();
            ballData.ballSpeedX = ballSpeedX;
            ballData.ballSpeedY = ballSpeedY;
            ballData.Location = Ball.Location;
            ballData.Left = Ball.Left;

            serialized = JsonConvert.SerializeObject(ballData);
            serializedData = Encoding.ASCII.GetBytes(serialized);

            senderUdpClient.Send(serializedData, serializedData.Length);

            Scores scores = new Scores();
            scores.P1Score = p1Score;
            scores.P2Score = p2Score;

            serialized = JsonConvert.SerializeObject(scores);
            serializedData = Encoding.ASCII.GetBytes(serialized);

            senderUdpClient.Send(serializedData, serializedData.Length);
        }

        private void SendGuestData() //Sent from guest
        {
            PlayerData playerData = new PlayerData();
            playerData.Position = Player1.Location;

            string serialized = JsonConvert.SerializeObject(playerData);
            byte[] serializedData = Encoding.ASCII.GetBytes(serialized);

            senderUdpClient.Send(serializedData, serializedData.Length);
        }

        private void ReceiveGuestData() //Received by host
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(Encoding.ASCII.GetString(receiverUdpClient.Receive(ref iPEndPoint)));
            Player2.Location = new Point(Player2.Location.X, playerData.Position.Y);
        }

        private void ReceiveHostData() //Received by guest
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(Encoding.ASCII.GetString(receiverUdpClient.Receive(ref iPEndPoint)));
            Player2.Location = new Point(Player2.Location.X, playerData.Position.Y);

            BallData ballData = JsonConvert.DeserializeObject<BallData>(Encoding.ASCII.GetString(receiverUdpClient.Receive(ref iPEndPoint)));
            Ball.Location = new Point(Width - (ballData.Left + Ball.Width), ballData.Location.Y);

            Scores scores = JsonConvert.DeserializeObject<Scores>(Encoding.ASCII.GetString(receiverUdpClient.Receive(ref iPEndPoint)));
            lblPlayer1Score.Text = scores.P2Score.ToString();
            lblPlayer2Score.Text = scores.P1Score.ToString();
        }

        private void ReceiveQuit()
        {
            UdpClient receiveQuit = new UdpClient(PongForm.defaultPort + 1);
            receiveQuit.Receive(ref iPEndPoint);
            timerGuest.Tick -= TimerGuest_Tick;
            timerHost.Tick -= TimerHost_Tick;
            timerGuest.Enabled = false;
            timerHost.Enabled = false;
            inGame = false;
            senderUdpClient.Close();
            receiverUdpClient.Close();
            this.Dispose();
        }

        private void SendQuit()
        {
            UdpClient sendQuit = new UdpClient();
            sendQuit.Connect(enemyIP, PongForm.defaultPort + 1);
            sendQuit.Send(new byte[100], 100);
            timerGuest.Tick -= TimerGuest_Tick;
            timerHost.Tick -= TimerHost_Tick;
            timerGuest.Enabled = false;
            timerHost.Enabled = false;
            inGame = false;
            senderUdpClient.Close();
            receiverUdpClient.Close();
            this.Dispose();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (Player1.Top > Top)
                {
                    isGoingUp = true;
                }
            }

            if (e.KeyCode == Keys.S)
            {
                if (Player1.Bottom < Bottom)
                {
                    isGoingDown = true;
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

            if(e.KeyCode == Keys.Escape)
            {
                SendQuit();
            }
        }

        public struct BallData
        {
            public int ballSpeedY;
            public int ballSpeedX;
            public Point Location;
            public int Left;
        }

        public struct PlayerData
        {
            public Point Position;
        }

        public struct Scores
        {
            public int P1Score;
            public int P2Score;
        }
    }
}