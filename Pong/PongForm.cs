using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public enum ConnectionLabelStyle
    {
        Success,
        Connecting,
        Failed
    }

    public partial class PongForm : Form
    {
        private Random r = new Random();

        readonly private static int defaultPort = 5000;
        readonly private static int listeningPort = 5000;

        private TcpListener tcpListener = null;
        private TcpClient tcpClient;

        private BackgroundWorker listener = new BackgroundWorker();

        private System.Windows.Forms.Timer timerStopTCPListener = new System.Windows.Forms.Timer()
        {
            Enabled = true,
            Interval = 10000
        };

        public PongForm()
        {
            InitializeComponent();
        }

        private void ApplyPixeledFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddFontFile("Resources\\Pixeled.ttf");

            foreach (Control c in panelLobby.Controls)
            {
                c.Font = new Font(pfc.Families[0], c.Font.Size);

                if (c.Tag is not "noCenter")
                {
                    c.Location = new Point((panelLobby.Width / 2) - (c.Width / 2), c.Location.Y);
                }
            }
        }

        private async void PongForm_Load(object sender, EventArgs e)
        {
            ApplyPixeledFont();

            lblPrivateIP.Text = "Private IP: " + GetPrivateIP();
            lblPublicIP.Text = "Public IP: " + GetPublicIP();

            await Task.Run(() => { ListenForRequests(); });
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchConnectionLabelStyle(ConnectionLabelStyle.Connecting);
                lblConnecting.Visible = true;
                ApplyPixeledFont();

                IPAddress enemyIP = IPAddress.Parse(txBxEnemyIP.Text);

                IPEndPoint endPoint = new IPEndPoint(enemyIP, defaultPort);

                tcpClient = new TcpClient();
                tcpClient.Connect(endPoint);

                Stream stm = tcpClient.GetStream();

                byte[] data = enemyIP.GetAddressBytes();
                stm.Write(data, 0, data.Length);

                byte[] response = new byte[100];
                int k = stm.Read(response, 0, response.Length);

                if (k.ToString() == "1")
                {
                    panelLobby.Visible = false;
                }
            }
            catch (Exception exc)
            {
                SwitchConnectionLabelStyle(ConnectionLabelStyle.Failed);
                lblConnecting.Visible = true;
                ApplyPixeledFont();

                DialogResult dr = MessageBox.Show(exc.Message);
                if (dr == DialogResult.OK)
                {
                    lblConnecting.Visible = false;
                }
            }
        }

        private void SwitchConnectionLabelStyle(ConnectionLabelStyle style)
        {
            switch (style)
            {
                case ConnectionLabelStyle.Success:
                    lblConnecting.ForeColor = Color.Green;
                    lblConnecting.Text = "Connection successful!";
                    break;

                case ConnectionLabelStyle.Connecting:
                    lblConnecting.ForeColor = Color.White;
                    lblConnecting.Text = "Connecting...";
                    break;

                case ConnectionLabelStyle.Failed:
                    lblConnecting.ForeColor = Color.Red;
                    lblConnecting.Text = "Connection failed.";
                    break;

                default:
                    break;
            }
        }

        private void ListenForRequests()
        {
            //timerStopTCPListener.Tick += StopTCPListener;
            //timerStopTCPListener.Start();

            //secondTimer.Tick += UpdateTimerLabel;
            //secondTimer.Start();

            tcpListener = new TcpListener(IPAddress.Any, defaultPort);
            tcpListener.Start();
            Socket sock = tcpListener.AcceptSocket();

            byte[] bytes = new byte[4];
            int k = sock.Receive(bytes);

            for (int i = 0; i < k; i++)
            {
                if(i != 3)
                {
                    Invoke(new Action(() => { lblIPEnemyDuel.Text += bytes[i] + "."; }));
                }
                else
                {
                    Invoke(new Action(() => { lblIPEnemyDuel.Text += bytes[i]; }));

                }
            }

            Invoke(new Action(() =>
            {
                lblIPEnemyDuel.Text += " wants to duel!";
                panelAcceptDuel.Visible = true;
            }));

            sock.Close();
            tcpListener.Stop();
        }

        //int seconds = 10;

        //private void UpdateTimerLabel(object sender, EventArgs e)
        //{
        //    lblTimerConnecting.Visible = true;

        //    string text = "Listening for " + seconds + " seconds";

        //    Invoke(new Action(() =>
        //    {
        //        lblTimerConnecting.Text = text;
        //    }));

        //    seconds--;

        //    if (seconds == 0)
        //    {
        //        Invoke(new Action(() =>
        //        {
        //            lblTimerConnecting.Visible = false;
        //        }));

        //        secondTimer.Stop();
        //        secondTimer.Tick -= UpdateTimerLabel;
        //        seconds = 8;
        //    }
        //}

        private static string GetPrivateIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static string GetPublicIP()
        {
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();

            return externalIpString;
        }

        private void btnAcceptDuel_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(lblEnemyIP.Text.Split(' ')[1], defaultPort);

            Stream stm = tcpClient.GetStream();

            byte[] response = new byte[] { 1 };

            stm.Write(response, 0, response.Length);
        }
    }
}