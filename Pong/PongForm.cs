using Newtonsoft.Json;
using Open.Nat;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public enum ConnectionLabelStyle
    {
        Success,
        RequestSent,
        Failed
    }

    public partial class PongForm : Form
    {
        private Random r = new Random();

        readonly public static int defaultPort = 52000;

        private UdpClient udpClient;
        internal static UdpClient listener;

        private NatDevice device;
        private Mapping mapping;

        internal static PrivateFontCollection pfc = new PrivateFontCollection();

        private System.Windows.Forms.Timer timerLblConnecting = new System.Windows.Forms.Timer()
        {
            Interval = 3000
        };

        public PongForm()
        {
            InitializeComponent();
        }

        private void ApplyPixeledFont()
        {
            pfc.AddFontFile("Resources\\Pixeled.ttf");

            foreach (Control c in panelLobby.Controls)
            {
                foreach (Control x in c.Controls)
                {
                    x.Font = new Font(pfc.Families[0], x.Font.Size);

                    if (x.Tag is not "noCenter")
                    {
                        x.Location = new Point((panelLobby.Width / 2) - (x.Width / 2), x.Location.Y);
                    }
                }
            }
        }

        private async void PongForm_Load(object sender, EventArgs e)
        {
            Notification notification = new Notification();

            ApplyPixeledFont();

            NatDiscoverer discoverer = new();
            CancellationTokenSource cts = new CancellationTokenSource(1500);
            try
            {
                device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp, cts);
                mapping = new Mapping(Protocol.Udp, defaultPort, defaultPort, "Open ports");
                await device.CreatePortMapAsync(mapping);
                btnMatchOnline.Enabled = true;
                btnMatchLAN.Enabled = true;
            }
            catch
            {
                notification.Show("Unable to open ports on the router. The game will work only in LAN.", Notification.enmType.Warning);
                btnMatchLAN.Enabled = true;
                btnMatchOnline.Enabled = false;
                btnMatchLAN.Width = txBxEnemyNickname.Width;
                btnMatchLAN.Left = txBxEnemyNickname.Left;
            }

            lblPrivateIP.Text = "Private IP: " + Methods.GetPrivateIP();
            lblPublicIP.Text = "Public IP: " + Methods.GetPublicIP();

            await Task.Run(() => { ListenForRequests(); });
        }

        private void btnMatchOnline_Click(object sender, EventArgs e)
        {
            Notification notification = new Notification();

            try
            {
                if (string.IsNullOrWhiteSpace(txBxEnemyNickname.Text))
                {
                    throw new Exception("Insert opponent's nickname.");
                }

                if (User.currentUser == null)
                {
                    throw new Exception("You must log in before matching.");
                }

                SwitchConnectionLabelStyle(ConnectionLabelStyle.RequestSent);
                lblConnecting.Visible = true;
                ApplyPixeledFont();

                User.RetrieveAccountFile(txBxEnemyNickname.Text.Trim());

                Enemy.currentEnemy = JsonConvert.DeserializeObject<Enemy>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"));

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");

                //string IPClass = GetIPClass(Methods.GetPrivateIP());
                //string IPEnemyClass = GetIPClass(Enemy..LANIP);

                IPAddress myIP = IPAddress.Parse(Methods.GetPublicIP());
                IPAddress enemyIP = IPAddress.Parse(Enemy.currentEnemy.IP);

                IPEndPoint endPoint = new IPEndPoint(enemyIP, defaultPort);

                udpClient = new UdpClient();
                udpClient.AllowNatTraversal(true);
                udpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Connect(endPoint);

                byte[] nickname = Encoding.ASCII.GetBytes(User.currentUser.Nickname);
                udpClient.Send(nickname, nickname.Length);
                byte[] IP = Encoding.ASCII.GetBytes(myIP.ToString());
                udpClient.Send(IP, IP.Length);
                udpClient.Close();
                udpClient.Dispose();
            }
            catch (Exception exc)
            {
                SwitchConnectionLabelStyle(ConnectionLabelStyle.Failed);
                lblConnecting.Visible = true;
                ApplyPixeledFont();

                notification.Show(exc.Message, Notification.enmType.Warning);
                lblConnecting.Visible = false;
            }
        }

        private void btnMatchLAN_Click(object sender, EventArgs e)
        {
            Notification notification = new Notification();

            try
            {
                if (string.IsNullOrWhiteSpace(txBxEnemyNickname.Text))
                {
                    throw new Exception("Insert opponent's nickname.");
                }

                if (User.currentUser == null)
                {
                    throw new Exception("You must log in before matching.");
                }

                User.RetrieveAccountFile(txBxEnemyNickname.Text.Trim());

                if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"))
                {
                    Enemy.currentEnemy = JsonConvert.DeserializeObject<Enemy>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"));

                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");

                    IPAddress myIP = IPAddress.Parse(Methods.GetPrivateIP());
                    IPAddress enemyIP = IPAddress.Parse(Enemy.currentEnemy.LANIP);
                    Enemy.currentEnemy.IP = enemyIP.ToString();

                    IPEndPoint endPoint = new IPEndPoint(enemyIP, defaultPort);

                    udpClient = new UdpClient();
                    udpClient.Connect(endPoint);

                    byte[] nickname = Encoding.ASCII.GetBytes(User.currentUser.Nickname);
                    udpClient.Send(nickname, nickname.Length);
                    byte[] IP = Encoding.ASCII.GetBytes(myIP.ToString());
                    udpClient.Send(IP, IP.Length);
                    udpClient.Close();
                    udpClient.Dispose();
                    SwitchConnectionLabelStyle(ConnectionLabelStyle.RequestSent);
                    lblConnecting.Visible = true;
                    ApplyPixeledFont();
                }
            }
            catch (Exception exc)
            {
                SwitchConnectionLabelStyle(ConnectionLabelStyle.Failed);
                lblConnecting.Visible = true;
                ApplyPixeledFont();

                notification.Show(exc.Message, Notification.enmType.Warning);
                lblConnecting.Visible = false;
            }
        }

        private void SwitchConnectionLabelStyle(ConnectionLabelStyle style)
        {
            switch (style)
            {
                case ConnectionLabelStyle.Success:
                    lblConnecting.ForeColor = Color.Green;
                    lblConnecting.Text = "Connection successful!";
                    timerLblConnecting.Tick += TimerLblConnecting_Tick;
                    timerLblConnecting.Enabled = true;
                    break;

                case ConnectionLabelStyle.RequestSent:
                    lblConnecting.ForeColor = Color.White;
                    lblConnecting.Text = "Request sent!";
                    timerLblConnecting.Tick += TimerLblConnecting_Tick;
                    timerLblConnecting.Enabled = true;
                    break;

                case ConnectionLabelStyle.Failed:
                    lblConnecting.ForeColor = Color.Red;
                    lblConnecting.Text = "Connection failed.";
                    timerLblConnecting.Tick += TimerLblConnecting_Tick;
                    timerLblConnecting.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void TimerLblConnecting_Tick(object sender, EventArgs e)
        {
            lblConnecting.Visible = false;
            timerLblConnecting.Tick -= TimerLblConnecting_Tick;
            timerLblConnecting.Enabled = false;
        }

        private void ListenForRequests()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, defaultPort);
            listener = new UdpClient(defaultPort);
            listener.AllowNatTraversal(true);
            listener.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            while (true)
            {
                byte[] bytes = new byte[20];
                bytes = listener.Receive(ref endPoint);

                if (Encoding.ASCII.GetString(bytes).Contains("Accept match"))
                {
                    Game.isHost = true;
                    Game.enemyIP = IPAddress.Parse(Enemy.currentEnemy.IP);

                    Game game = new Game();

                    Invoke(new Action(() =>
                    {
                        Controls.Add(game);
                        game.BringToFront();
                        game.Visible = true;
                    }));
                }
                else if(!Game.inGame)
                {
                    Enemy.currentEnemy.Nickname = Encoding.ASCII.GetString(bytes);

                    Invoke(new Action(() =>
                    {
                        lblIPEnemyDuel.Text = Enemy.currentEnemy.Nickname + " wants to duel!";
                        panelAcceptDuel.Visible = true;
                    }));

                    byte[] ip = new byte[100];
                    ip = listener.Receive(ref endPoint);
                    Enemy.currentEnemy.IP = Encoding.ASCII.GetString(ip);
                }
            }
        }

        private void btnAcceptDuel_Click(object sender, EventArgs e)
        {
            IPAddress enemyIP = IPAddress.Parse(Enemy.currentEnemy.IP);

            udpClient = new UdpClient();
            udpClient.AllowNatTraversal(true);
            udpClient.Client.SetIPProtectionLevel(IPProtectionLevel.Unrestricted);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Connect(enemyIP, defaultPort);

            byte[] response = Encoding.ASCII.GetBytes("Accept match");

            udpClient.Send(response, response.Length);

            Game.isHost = false;
            Game.enemyIP = enemyIP;

            udpClient.Close();
            udpClient.Dispose();

            Game game = new Game();

            Controls.Add(game);
            game.Visible = true;
            panelLobby.SendToBack();
            panelAcceptDuel.Visible = false;

            lblIPEnemyDuel.Text = "";
        }

        private void PongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device != null)
            {
                device.DeletePortMapAsync(mapping);
            }
            Application.Exit();
        }

        private void RefreshMenu()
        {
            if (User.currentUser != null)
            {
                lblCurrentUserNickname.Text = User.currentUser.Nickname;
                lblCurrentUserNickname.Visible = true;
                btnLogin.Visible = false;
                btnCreateAccount.Visible = false;
                llblLogOut.Visible = true;
            }
            else
            {
                lblCurrentUserNickname.Visible = false;
                lblCurrentUserNickname.Text = "currentUser.Nickname";
                btnLogin.Visible = true;
                btnCreateAccount.Visible = true;
                llblLogOut.Visible = false;
            }
        }

        private void btnConfirmLogin_Click(object sender, EventArgs e)
        {
            string nickname = txBxLoginNickname.Text.Trim();
            string password = txBxLoginPsw.Text.Trim();

            new User(nickname, password);

            panelLogin.Visible = false;
            panelLogin.SendToBack();

            txBxLoginNickname.Clear();
            txBxLoginPsw.Clear();

            RefreshMenu();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelMenu.SendToBack();

            panelLogin.Visible = true;
            panelLogin.BringToFront();
        }

        private void pxBxLoginBack_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelLogin.SendToBack();
        }

        private void llblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User.Logout();
            RefreshMenu();
            panelMenu.Visible = false;
            panelMenu.SendToBack();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://pongsignup.ddns.net")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void lblCurrentUserNickname_Click(object sender, EventArgs e)
        {
        }

        private void lblCurrentUserNickname_Click_1(object sender, EventArgs e)
        {
        }

        private void pxBxHamburgerMenu_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
            panelMenu.Visible = true;
        }

        private void pxBxBackPanelMenu_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelMenu.SendToBack();
        }

        private void panelMainMenu_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnRefuseDuel_Click(object sender, EventArgs e)
        {
            Enemy.currentEnemy = null;
            panelAcceptDuel.Visible = false;
        }

        private void panelLobby_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}