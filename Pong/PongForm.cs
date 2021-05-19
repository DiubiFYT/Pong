using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Open.Nat;

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

        readonly public static int defaultPort = 52000;

        private UdpClient udpClient;
        private UdpClient listener;

        private NatDevice device;
        private Mapping mapping;

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

            NatDiscoverer discoverer = new();
            CancellationTokenSource cts = new CancellationTokenSource(10000);
            device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp, cts);
            mapping = new Mapping(Protocol.Udp, defaultPort, defaultPort, "Open ports");
            await device.CreatePortMapAsync(mapping);

            lblPrivateIP.Text = "Private IP: " + Methods.GetPrivateIP();
            lblPublicIP.Text = "Public IP: " + Methods.GetPublicIP();

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
                IPAddress myIP = IPAddress.Parse(Methods.GetPublicIP());

                IPEndPoint endPoint = new IPEndPoint(enemyIP, defaultPort);

                udpClient = new UdpClient();
                udpClient.AllowNatTraversal(true);
                udpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Connect(endPoint);

                byte[] data = myIP.GetAddressBytes();
                udpClient.Send(data, data.Length);
                udpClient.Close();
                udpClient.Dispose();
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
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, defaultPort);
            listener = new UdpClient(defaultPort);
            listener.AllowNatTraversal(true);
            listener.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            byte[] bytes = new byte[20];
            bytes = listener.Receive(ref endPoint);

            if (Encoding.ASCII.GetString(bytes).Contains("Accept match"))
            {
                listener.Close();
                listener.Dispose();

                Game.isHost = true;
                Game.enemyIP = IPAddress.Parse(txBxEnemyIP.Text);

                Game game = new Game();

                Invoke(new Action(() =>
                {
                    panelGame.Visible = true;
                    panelGame.Controls.Add(game);
                    game.Visible = true;
                    panelLobby.Visible = false;
                }));
            }
            else
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (i != 3)
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

                Game.isHost = true;
            }
            listener.Close();
            listener.Dispose();
        }

        private void btnAcceptDuel_Click(object sender, EventArgs e)
        {
            IPAddress enemyIP = IPAddress.Parse(lblIPEnemyDuel.Text.Split(' ')[0]);

            if (udpClient == null || !udpClient.Client.Connected)
            {
                udpClient = new UdpClient();
                udpClient.AllowNatTraversal(true);
                udpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Connect(enemyIP, defaultPort);
            }

            byte[] response = Encoding.ASCII.GetBytes("Accept match");

            udpClient.Send(response, response.Length);

            Game.isHost = false;
            Game.enemyIP = enemyIP;

            udpClient.Close();
            udpClient.Dispose();

            Game game = new Game();

            panelGame.Visible = true;
            panelGame.Controls.Add(game);
            game.Visible = true;
            panelLobby.Visible = false;
        }

        private void PongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            device.DeletePortMapAsync(mapping);
            Application.Exit();
        }
    }
}