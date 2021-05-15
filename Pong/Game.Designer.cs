
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
            base.Dispose(disposing);
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
            this.TopBorder = new System.Windows.Forms.Panel();
            this.BottomBorder = new System.Windows.Forms.Panel();
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
            // TopBorder
            // 
            this.TopBorder.BackColor = System.Drawing.Color.DimGray;
            this.TopBorder.Location = new System.Drawing.Point(0, 0);
            this.TopBorder.Name = "TopBorder";
            this.TopBorder.Size = new System.Drawing.Size(1232, 46);
            this.TopBorder.TabIndex = 3;
            // 
            // BottomBorder
            // 
            this.BottomBorder.BackColor = System.Drawing.Color.DimGray;
            this.BottomBorder.Location = new System.Drawing.Point(0, 620);
            this.BottomBorder.Name = "BottomBorder";
            this.BottomBorder.Size = new System.Drawing.Size(1232, 46);
            this.BottomBorder.TabIndex = 4;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.BottomBorder);
            this.Controls.Add(this.TopBorder);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(1232, 666);
            this.VisibleChanged += new System.EventHandler(this.Game_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Player1;
        private System.Windows.Forms.Panel Player2;
        private System.Windows.Forms.Panel Ball;
        private System.Windows.Forms.Panel TopBorder;
        private System.Windows.Forms.Panel BottomBorder;
    }
}
