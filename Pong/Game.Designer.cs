using System;

namespace Pong
{
    partial class Game
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Invoke(new Action(() => { base.Dispose(disposing); }));
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player1 = new System.Windows.Forms.Panel();
            this.Player2 = new System.Windows.Forms.Panel();
            this.Ball = new System.Windows.Forms.Panel();
            this.lblPlayer1Score = new System.Windows.Forms.Label();
            this.lblPlayer2Score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQuit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.Color.White;
            this.Player1.Location = new System.Drawing.Point(20, 285);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(19, 96);
            this.Player1.TabIndex = 0;
            // 
            // Player2
            // 
            this.Player2.BackColor = System.Drawing.Color.White;
            this.Player2.Location = new System.Drawing.Point(1193, 285);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(19, 96);
            this.Player2.TabIndex = 1;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.White;
            this.Ball.Location = new System.Drawing.Point(607, 324);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(18, 18);
            this.Ball.TabIndex = 2;
            // 
            // lblPlayer1Score
            // 
            this.lblPlayer1Score.AutoSize = true;
            this.lblPlayer1Score.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayer1Score.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Score.Location = new System.Drawing.Point(288, 28);
            this.lblPlayer1Score.Name = "lblPlayer1Score";
            this.lblPlayer1Score.Size = new System.Drawing.Size(25, 30);
            this.lblPlayer1Score.TabIndex = 3;
            this.lblPlayer1Score.Text = "0";
            // 
            // lblPlayer2Score
            // 
            this.lblPlayer2Score.AutoSize = true;
            this.lblPlayer2Score.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayer2Score.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Score.Location = new System.Drawing.Point(893, 28);
            this.lblPlayer2Score.Name = "lblPlayer2Score";
            this.lblPlayer2Score.Size = new System.Drawing.Size(25, 30);
            this.lblPlayer2Score.TabIndex = 4;
            this.lblPlayer2Score.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-235, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // lblQuit
            // 
            this.lblQuit.AutoSize = true;
            this.lblQuit.ForeColor = System.Drawing.Color.White;
            this.lblQuit.Location = new System.Drawing.Point(20, 632);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(155, 15);
            this.lblQuit.TabIndex = 7;
            this.lblQuit.Text = "Press ESC to quit the match.";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblQuit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPlayer2Score);
            this.Controls.Add(this.lblPlayer1Score);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(1232, 666);
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Player1;
        private System.Windows.Forms.Panel Player2;
        private System.Windows.Forms.Panel Ball;
        private System.Windows.Forms.Label lblPlayer1Score;
        private System.Windows.Forms.Label lblPlayer2Score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQuit;
    }
}
