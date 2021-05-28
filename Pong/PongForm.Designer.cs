
namespace Pong
{
    partial class PongForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.pxBxLoginBack = new System.Windows.Forms.PictureBox();
            this.btnConfirmLogin = new System.Windows.Forms.Button();
            this.lblLoginNickname = new System.Windows.Forms.Label();
            this.txBxLoginPsw = new System.Windows.Forms.TextBox();
            this.txBxLoginNickname = new System.Windows.Forms.TextBox();
            this.lblLoginPsw = new System.Windows.Forms.Label();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.pxBxBackPanelMenu = new System.Windows.Forms.PictureBox();
            this.llblLogOut = new System.Windows.Forms.LinkLabel();
            this.lblCurrentUserNickname = new System.Windows.Forms.Label();
            this.txBxEnemyNickname = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelAcceptDuel = new System.Windows.Forms.Panel();
            this.btnAcceptDuel = new System.Windows.Forms.Button();
            this.lblIPEnemyDuel = new System.Windows.Forms.Label();
            this.lblEnemyIP = new System.Windows.Forms.Label();
            this.lblPublicIP = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.lblPrivateIP = new System.Windows.Forms.Label();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.pxBxHamburgerMenu = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLobby = new System.Windows.Forms.Panel();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxLoginBack)).BeginInit();
            this.panelMainMenu.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxBackPanelMenu)).BeginInit();
            this.panelAcceptDuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxHamburgerMenu)).BeginInit();
            this.panelLobby.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Black;
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1232, 666);
            this.panelGame.TabIndex = 1;
            this.panelGame.Visible = false;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.pxBxLoginBack);
            this.panelLogin.Controls.Add(this.btnConfirmLogin);
            this.panelLogin.Controls.Add(this.lblLoginNickname);
            this.panelLogin.Controls.Add(this.txBxLoginPsw);
            this.panelLogin.Controls.Add(this.txBxLoginNickname);
            this.panelLogin.Controls.Add(this.lblLoginPsw);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(1232, 666);
            this.panelLogin.TabIndex = 16;
            this.panelLogin.Tag = "noCenter";
            this.panelLogin.Visible = false;
            // 
            // pxBxLoginBack
            // 
            this.pxBxLoginBack.Image = global::Pong.Resources.moveback;
            this.pxBxLoginBack.Location = new System.Drawing.Point(12, 13);
            this.pxBxLoginBack.Name = "pxBxLoginBack";
            this.pxBxLoginBack.Size = new System.Drawing.Size(67, 64);
            this.pxBxLoginBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pxBxLoginBack.TabIndex = 16;
            this.pxBxLoginBack.TabStop = false;
            this.pxBxLoginBack.Tag = "noCenter";
            this.pxBxLoginBack.Click += new System.EventHandler(this.pxBxLoginBack_Click);
            // 
            // btnConfirmLogin
            // 
            this.btnConfirmLogin.BackColor = System.Drawing.Color.Green;
            this.btnConfirmLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmLogin.Location = new System.Drawing.Point(270, 403);
            this.btnConfirmLogin.Name = "btnConfirmLogin";
            this.btnConfirmLogin.Size = new System.Drawing.Size(727, 84);
            this.btnConfirmLogin.TabIndex = 15;
            this.btnConfirmLogin.Tag = "";
            this.btnConfirmLogin.Text = "Confirm";
            this.btnConfirmLogin.UseVisualStyleBackColor = false;
            this.btnConfirmLogin.Click += new System.EventHandler(this.btnConfirmLogin_Click);
            // 
            // lblLoginNickname
            // 
            this.lblLoginNickname.AutoSize = true;
            this.lblLoginNickname.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLoginNickname.Location = new System.Drawing.Point(577, 108);
            this.lblLoginNickname.Name = "lblLoginNickname";
            this.lblLoginNickname.Size = new System.Drawing.Size(60, 15);
            this.lblLoginNickname.TabIndex = 11;
            this.lblLoginNickname.Tag = "";
            this.lblLoginNickname.Text = "Username";
            // 
            // txBxLoginPsw
            // 
            this.txBxLoginPsw.Location = new System.Drawing.Point(415, 302);
            this.txBxLoginPsw.Name = "txBxLoginPsw";
            this.txBxLoginPsw.Size = new System.Drawing.Size(432, 23);
            this.txBxLoginPsw.TabIndex = 14;
            this.txBxLoginPsw.Tag = "";
            this.txBxLoginPsw.UseSystemPasswordChar = true;
            // 
            // txBxLoginNickname
            // 
            this.txBxLoginNickname.Location = new System.Drawing.Point(415, 164);
            this.txBxLoginNickname.Name = "txBxLoginNickname";
            this.txBxLoginNickname.Size = new System.Drawing.Size(432, 23);
            this.txBxLoginNickname.TabIndex = 12;
            this.txBxLoginNickname.Tag = "";
            // 
            // lblLoginPsw
            // 
            this.lblLoginPsw.AutoSize = true;
            this.lblLoginPsw.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLoginPsw.Location = new System.Drawing.Point(580, 253);
            this.lblLoginPsw.Name = "lblLoginPsw";
            this.lblLoginPsw.Size = new System.Drawing.Size(57, 15);
            this.lblLoginPsw.TabIndex = 13;
            this.lblLoginPsw.Tag = "";
            this.lblLoginPsw.Text = "Password";
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.Controls.Add(this.panelMenu);
            this.panelMainMenu.Controls.Add(this.txBxEnemyNickname);
            this.panelMainMenu.Controls.Add(this.lblTitle);
            this.panelMainMenu.Controls.Add(this.panelAcceptDuel);
            this.panelMainMenu.Controls.Add(this.lblEnemyIP);
            this.panelMainMenu.Controls.Add(this.lblPublicIP);
            this.panelMainMenu.Controls.Add(this.btnMatch);
            this.panelMainMenu.Controls.Add(this.lblPrivateIP);
            this.panelMainMenu.Controls.Add(this.lblConnecting);
            this.panelMainMenu.Controls.Add(this.pxBxHamburgerMenu);
            this.panelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(1232, 666);
            this.panelMainMenu.TabIndex = 17;
            this.panelMainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMainMenu_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.btnCreateAccount);
            this.panelMenu.Controls.Add(this.pxBxBackPanelMenu);
            this.panelMenu.Controls.Add(this.llblLogOut);
            this.panelMenu.Controls.Add(this.lblCurrentUserNickname);
            this.panelMenu.Location = new System.Drawing.Point(974, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(258, 666);
            this.panelMenu.TabIndex = 11;
            this.panelMenu.Tag = "noCenter";
            this.panelMenu.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(10, 60);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(236, 64);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Tag = "noCenter";
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAccount.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Location = new System.Drawing.Point(10, 123);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(236, 64);
            this.btnCreateAccount.TabIndex = 8;
            this.btnCreateAccount.Tag = "noCenter";
            this.btnCreateAccount.Text = "Create an account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // pxBxBackPanelMenu
            // 
            this.pxBxBackPanelMenu.Image = global::Pong.Resources.moveback;
            this.pxBxBackPanelMenu.Location = new System.Drawing.Point(0, 2);
            this.pxBxBackPanelMenu.Name = "pxBxBackPanelMenu";
            this.pxBxBackPanelMenu.Size = new System.Drawing.Size(45, 49);
            this.pxBxBackPanelMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pxBxBackPanelMenu.TabIndex = 12;
            this.pxBxBackPanelMenu.TabStop = false;
            this.pxBxBackPanelMenu.Tag = "noCenter";
            this.pxBxBackPanelMenu.Click += new System.EventHandler(this.pxBxBackPanelMenu_Click);
            // 
            // llblLogOut
            // 
            this.llblLogOut.LinkColor = System.Drawing.Color.Red;
            this.llblLogOut.Location = new System.Drawing.Point(10, 608);
            this.llblLogOut.Name = "llblLogOut";
            this.llblLogOut.Size = new System.Drawing.Size(236, 49);
            this.llblLogOut.TabIndex = 7;
            this.llblLogOut.TabStop = true;
            this.llblLogOut.Tag = "noCenter";
            this.llblLogOut.Text = "Logout";
            this.llblLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblLogOut.Visible = false;
            this.llblLogOut.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // lblCurrentUserNickname
            // 
            this.lblCurrentUserNickname.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUserNickname.Location = new System.Drawing.Point(51, 2);
            this.lblCurrentUserNickname.Name = "lblCurrentUserNickname";
            this.lblCurrentUserNickname.Size = new System.Drawing.Size(207, 49);
            this.lblCurrentUserNickname.TabIndex = 8;
            this.lblCurrentUserNickname.Tag = "noCenter";
            this.lblCurrentUserNickname.Text = "currentUser.Nickname";
            this.lblCurrentUserNickname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurrentUserNickname.Visible = false;
            // 
            // txBxEnemyNickname
            // 
            this.txBxEnemyNickname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txBxEnemyNickname.Location = new System.Drawing.Point(418, 332);
            this.txBxEnemyNickname.Name = "txBxEnemyNickname";
            this.txBxEnemyNickname.Size = new System.Drawing.Size(432, 29);
            this.txBxEnemyNickname.TabIndex = 2;
            this.txBxEnemyNickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift Condensed", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(530, 73);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pong";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // panelAcceptDuel
            // 
            this.panelAcceptDuel.Controls.Add(this.btnAcceptDuel);
            this.panelAcceptDuel.Controls.Add(this.lblIPEnemyDuel);
            this.panelAcceptDuel.Location = new System.Drawing.Point(418, 528);
            this.panelAcceptDuel.Name = "panelAcceptDuel";
            this.panelAcceptDuel.Size = new System.Drawing.Size(432, 121);
            this.panelAcceptDuel.TabIndex = 9;
            this.panelAcceptDuel.Visible = false;
            // 
            // btnAcceptDuel
            // 
            this.btnAcceptDuel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptDuel.BackColor = System.Drawing.Color.Green;
            this.btnAcceptDuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptDuel.Location = new System.Drawing.Point(0, 68);
            this.btnAcceptDuel.Name = "btnAcceptDuel";
            this.btnAcceptDuel.Size = new System.Drawing.Size(432, 57);
            this.btnAcceptDuel.TabIndex = 10;
            this.btnAcceptDuel.Tag = "noCenter";
            this.btnAcceptDuel.Text = "Accept";
            this.btnAcceptDuel.UseVisualStyleBackColor = false;
            this.btnAcceptDuel.Click += new System.EventHandler(this.btnAcceptDuel_Click);
            // 
            // lblIPEnemyDuel
            // 
            this.lblIPEnemyDuel.ForeColor = System.Drawing.Color.White;
            this.lblIPEnemyDuel.Location = new System.Drawing.Point(0, 0);
            this.lblIPEnemyDuel.Name = "lblIPEnemyDuel";
            this.lblIPEnemyDuel.Size = new System.Drawing.Size(432, 65);
            this.lblIPEnemyDuel.TabIndex = 0;
            this.lblIPEnemyDuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnemyIP
            // 
            this.lblEnemyIP.AutoSize = true;
            this.lblEnemyIP.BackColor = System.Drawing.Color.Black;
            this.lblEnemyIP.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEnemyIP.ForeColor = System.Drawing.Color.White;
            this.lblEnemyIP.Location = new System.Drawing.Point(553, 241);
            this.lblEnemyIP.Name = "lblEnemyIP";
            this.lblEnemyIP.Size = new System.Drawing.Size(161, 30);
            this.lblEnemyIP.TabIndex = 1;
            this.lblEnemyIP.Text = "Enemy\'s Nickname";
            this.lblEnemyIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnemyIP.UseCompatibleTextRendering = true;
            // 
            // lblPublicIP
            // 
            this.lblPublicIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublicIP.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPublicIP.ForeColor = System.Drawing.Color.White;
            this.lblPublicIP.Location = new System.Drawing.Point(12, 37);
            this.lblPublicIP.Name = "lblPublicIP";
            this.lblPublicIP.Size = new System.Drawing.Size(226, 28);
            this.lblPublicIP.TabIndex = 8;
            this.lblPublicIP.Tag = "noCenter";
            this.lblPublicIP.Text = "Public IP:";
            this.lblPublicIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMatch
            // 
            this.btnMatch.BackColor = System.Drawing.Color.White;
            this.btnMatch.ForeColor = System.Drawing.Color.Black;
            this.btnMatch.Location = new System.Drawing.Point(472, 404);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(332, 50);
            this.btnMatch.TabIndex = 3;
            this.btnMatch.Text = "Search for the enemy";
            this.btnMatch.UseVisualStyleBackColor = false;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // lblPrivateIP
            // 
            this.lblPrivateIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrivateIP.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrivateIP.ForeColor = System.Drawing.Color.White;
            this.lblPrivateIP.Location = new System.Drawing.Point(12, 9);
            this.lblPrivateIP.Name = "lblPrivateIP";
            this.lblPrivateIP.Size = new System.Drawing.Size(226, 28);
            this.lblPrivateIP.TabIndex = 7;
            this.lblPrivateIP.Tag = "noCenter";
            this.lblPrivateIP.Text = "Private IP:";
            this.lblPrivateIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnecting
            // 
            this.lblConnecting.AutoSize = true;
            this.lblConnecting.BackColor = System.Drawing.Color.Black;
            this.lblConnecting.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnecting.ForeColor = System.Drawing.Color.White;
            this.lblConnecting.Location = new System.Drawing.Point(580, 495);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(112, 30);
            this.lblConnecting.TabIndex = 4;
            this.lblConnecting.Text = "Connecting...";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnecting.UseCompatibleTextRendering = true;
            this.lblConnecting.Visible = false;
            // 
            // pxBxHamburgerMenu
            // 
            this.pxBxHamburgerMenu.Image = global::Pong.Resources.Hamburger_menu_icon_white;
            this.pxBxHamburgerMenu.Location = new System.Drawing.Point(1172, 12);
            this.pxBxHamburgerMenu.Name = "pxBxHamburgerMenu";
            this.pxBxHamburgerMenu.Size = new System.Drawing.Size(48, 53);
            this.pxBxHamburgerMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pxBxHamburgerMenu.TabIndex = 11;
            this.pxBxHamburgerMenu.TabStop = false;
            this.pxBxHamburgerMenu.Tag = "noCenter";
            this.pxBxHamburgerMenu.Click += new System.EventHandler(this.pxBxHamburgerMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // panelLobby
            // 
            this.panelLobby.BackColor = System.Drawing.Color.Black;
            this.panelLobby.Controls.Add(this.label1);
            this.panelLobby.Controls.Add(this.panelMainMenu);
            this.panelLobby.Controls.Add(this.panelLogin);
            this.panelLobby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLobby.Location = new System.Drawing.Point(0, 0);
            this.panelLobby.Name = "panelLobby";
            this.panelLobby.Size = new System.Drawing.Size(1232, 666);
            this.panelLobby.TabIndex = 0;
            // 
            // PongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 666);
            this.Controls.Add(this.panelLobby);
            this.Controls.Add(this.panelGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1248, 705);
            this.Name = "PongForm";
            this.Text = "Pong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PongForm_FormClosing);
            this.Load += new System.EventHandler(this.PongForm_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxLoginBack)).EndInit();
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pxBxBackPanelMenu)).EndInit();
            this.panelAcceptDuel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pxBxHamburgerMenu)).EndInit();
            this.panelLobby.ResumeLayout(false);
            this.panelLobby.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pxBxLoginBack;
        private System.Windows.Forms.Button btnConfirmLogin;
        private System.Windows.Forms.Label lblLoginNickname;
        private System.Windows.Forms.TextBox txBxLoginPsw;
        private System.Windows.Forms.TextBox txBxLoginNickname;
        private System.Windows.Forms.Label lblLoginPsw;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.TextBox txBxEnemyNickname;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelAcceptDuel;
        private System.Windows.Forms.Button btnAcceptDuel;
        private System.Windows.Forms.Label lblIPEnemyDuel;
        private System.Windows.Forms.Label lblEnemyIP;
        private System.Windows.Forms.Label lblPublicIP;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Label lblPrivateIP;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLobby;
        private System.Windows.Forms.PictureBox pxBxHamburgerMenu;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.PictureBox pxBxBackPanelMenu;
        private System.Windows.Forms.LinkLabel llblLogOut;
        private System.Windows.Forms.Label lblCurrentUserNickname;
    }
}

