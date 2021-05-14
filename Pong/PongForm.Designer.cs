
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
            this.components = new System.ComponentModel.Container();
            this.panelLobby = new System.Windows.Forms.Panel();
            this.panelAcceptDuel = new System.Windows.Forms.Panel();
            this.btnAcceptDuel = new System.Windows.Forms.Button();
            this.lblIPEnemyDuel = new System.Windows.Forms.Label();
            this.lblPublicIP = new System.Windows.Forms.Label();
            this.lblPrivateIP = new System.Windows.Forms.Label();
            this.lblTimerConnecting = new System.Windows.Forms.Label();
            this.btnHostLobby = new System.Windows.Forms.Button();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.txBxEnemyIP = new System.Windows.Forms.TextBox();
            this.lblEnemyIP = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelGame = new System.Windows.Forms.Panel();
            this.secondTimer = new System.Windows.Forms.Timer(this.components);
            this.panelLobby.SuspendLayout();
            this.panelAcceptDuel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLobby
            // 
            this.panelLobby.BackColor = System.Drawing.Color.Black;
            this.panelLobby.Controls.Add(this.panelAcceptDuel);
            this.panelLobby.Controls.Add(this.lblPublicIP);
            this.panelLobby.Controls.Add(this.lblPrivateIP);
            this.panelLobby.Controls.Add(this.lblTimerConnecting);
            this.panelLobby.Controls.Add(this.btnHostLobby);
            this.panelLobby.Controls.Add(this.lblConnecting);
            this.panelLobby.Controls.Add(this.btnMatch);
            this.panelLobby.Controls.Add(this.txBxEnemyIP);
            this.panelLobby.Controls.Add(this.lblEnemyIP);
            this.panelLobby.Controls.Add(this.lblTitle);
            this.panelLobby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLobby.Location = new System.Drawing.Point(0, 0);
            this.panelLobby.Name = "panelLobby";
            this.panelLobby.Size = new System.Drawing.Size(1232, 666);
            this.panelLobby.TabIndex = 0;
            // 
            // panelAcceptDuel
            // 
            this.panelAcceptDuel.Controls.Add(this.btnAcceptDuel);
            this.panelAcceptDuel.Controls.Add(this.lblIPEnemyDuel);
            this.panelAcceptDuel.Location = new System.Drawing.Point(415, 513);
            this.panelAcceptDuel.Name = "panelAcceptDuel";
            this.panelAcceptDuel.Size = new System.Drawing.Size(432, 125);
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
            // lblTimerConnecting
            // 
            this.lblTimerConnecting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerConnecting.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimerConnecting.ForeColor = System.Drawing.Color.White;
            this.lblTimerConnecting.Location = new System.Drawing.Point(994, 80);
            this.lblTimerConnecting.Name = "lblTimerConnecting";
            this.lblTimerConnecting.Size = new System.Drawing.Size(226, 28);
            this.lblTimerConnecting.TabIndex = 6;
            this.lblTimerConnecting.Tag = "noCenter";
            this.lblTimerConnecting.Text = "Listening for 30 seconds";
            this.lblTimerConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimerConnecting.Visible = false;
            // 
            // btnHostLobby
            // 
            this.btnHostLobby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHostLobby.BackColor = System.Drawing.Color.Green;
            this.btnHostLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHostLobby.Location = new System.Drawing.Point(994, 13);
            this.btnHostLobby.Name = "btnHostLobby";
            this.btnHostLobby.Size = new System.Drawing.Size(226, 64);
            this.btnHostLobby.TabIndex = 5;
            this.btnHostLobby.Tag = "noCenter";
            this.btnHostLobby.Text = "Host a lobby";
            this.btnHostLobby.UseVisualStyleBackColor = false;
            this.btnHostLobby.Visible = false;
            // 
            // lblConnecting
            // 
            this.lblConnecting.AutoSize = true;
            this.lblConnecting.BackColor = System.Drawing.Color.Black;
            this.lblConnecting.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConnecting.ForeColor = System.Drawing.Color.White;
            this.lblConnecting.Location = new System.Drawing.Point(577, 494);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(112, 30);
            this.lblConnecting.TabIndex = 4;
            this.lblConnecting.Text = "Connecting...";
            this.lblConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnecting.UseCompatibleTextRendering = true;
            this.lblConnecting.Visible = false;
            // 
            // btnMatch
            // 
            this.btnMatch.BackColor = System.Drawing.Color.White;
            this.btnMatch.ForeColor = System.Drawing.Color.Black;
            this.btnMatch.Location = new System.Drawing.Point(469, 403);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(332, 50);
            this.btnMatch.TabIndex = 3;
            this.btnMatch.Text = "Search for the enemy";
            this.btnMatch.UseVisualStyleBackColor = false;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // txBxEnemyIP
            // 
            this.txBxEnemyIP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txBxEnemyIP.Location = new System.Drawing.Point(415, 331);
            this.txBxEnemyIP.Name = "txBxEnemyIP";
            this.txBxEnemyIP.Size = new System.Drawing.Size(432, 29);
            this.txBxEnemyIP.TabIndex = 2;
            this.txBxEnemyIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEnemyIP
            // 
            this.lblEnemyIP.AutoSize = true;
            this.lblEnemyIP.BackColor = System.Drawing.Color.Black;
            this.lblEnemyIP.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEnemyIP.ForeColor = System.Drawing.Color.White;
            this.lblEnemyIP.Location = new System.Drawing.Point(577, 240);
            this.lblEnemyIP.Name = "lblEnemyIP";
            this.lblEnemyIP.Size = new System.Drawing.Size(95, 30);
            this.lblEnemyIP.TabIndex = 1;
            this.lblEnemyIP.Text = "Enemy\'s IP";
            this.lblEnemyIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnemyIP.UseCompatibleTextRendering = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift Condensed", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(527, 72);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pong";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Black;
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1232, 666);
            this.panelGame.TabIndex = 1;
            // 
            // secondTimer
            // 
            this.secondTimer.Enabled = true;
            this.secondTimer.Interval = 1000;
            // 
            // PongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 666);
            this.Controls.Add(this.panelLobby);
            this.Controls.Add(this.panelGame);
            this.Name = "PongForm";
            this.Text = "Pong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PongForm_FormClosing);
            this.Load += new System.EventHandler(this.PongForm_Load);
            this.panelLobby.ResumeLayout(false);
            this.panelLobby.PerformLayout();
            this.panelAcceptDuel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLobby;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEnemyIP;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.TextBox txBxEnemyIP;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Button btnHostLobby;
        private System.Windows.Forms.Label lblTimerConnecting;
        private System.Windows.Forms.Timer secondTimer;
        private System.Windows.Forms.Label lblPublicIP;
        private System.Windows.Forms.Label lblPrivateIP;
        private System.Windows.Forms.Panel panelAcceptDuel;
        private System.Windows.Forms.Button btnAcceptDuel;
        private System.Windows.Forms.Label lblIPEnemyDuel;
    }
}

