using Open.Nat;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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

        readonly public static int defaultPort = 52000;

        private UdpClient udpClient;
        private UdpClient listener;

        private NatDevice device;
        private Mapping mapping;

        Notification notification = new Notification();

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
                foreach(Control x in c.Controls)
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
            ApplyPixeledFont();

            NatDiscoverer discoverer = new();
            CancellationTokenSource cts = new CancellationTokenSource(10000);
            try
            {
                device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp, cts);
                mapping = new Mapping(Protocol.Udp, defaultPort, defaultPort, "Open ports");
                await device.CreatePortMapAsync(mapping);
            }
            catch(Exception exc)
            {
                notification.Show(exc.Message, Notification.enmType.Warning);
            }

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

        private void RefreshMenu()
        {
            if(User.currentUser != new User() && User.currentUser != null)
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
    }
}