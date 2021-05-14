﻿using System;
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

        private TcpListener tcpListener = null;
        private TcpClient tcpClient;

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
                IPAddress myIP = IPAddress.Parse(Methods.GetPrivateIP());

                IPEndPoint endPoint = new IPEndPoint(enemyIP, defaultPort);

                tcpClient = new TcpClient();
                tcpClient.Connect(endPoint);

                Stream stm = tcpClient.GetStream();

                byte[] data = myIP.GetAddressBytes();
                stm.Write(data, 0, data.Length);
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
            tcpListener = new TcpListener(IPAddress.Any, defaultPort);
            tcpListener.Start();
            Socket sock = tcpListener.AcceptSocket();

            byte[] bytes = new byte[4];
            int k = sock.Receive(bytes);

            if (Encoding.ASCII.GetString(bytes).Contains("Accept match"))
            {

            }
            else
            {
                for (int i = 0; i < k; i++)
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
            }
            sock.Close();
            tcpListener.Stop();
        }

        private void btnAcceptDuel_Click(object sender, EventArgs e)
        {
            if(tcpClient == null || !tcpClient.Connected)
            {
                tcpClient = new TcpClient();
                IPAddress enemyIP = IPAddress.Parse(lblIPEnemyDuel.Text.Split(' ')[0]);
                tcpClient.Connect(enemyIP, defaultPort);
            }

            Stream stm = tcpClient.GetStream();

            byte[] response = Encoding.ASCII.GetBytes("Accept match");

            stm.Write(response, 0, response.Length);

            panelGame.Visible = true;
            panelLobby.Visible = false;
        }

        private void PongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}