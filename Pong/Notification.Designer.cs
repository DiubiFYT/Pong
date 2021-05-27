
namespace Pong
{
    partial class Notification
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerNotification = new System.Windows.Forms.Timer(this.components);
            this.pxBxNotificationIcon = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pxBxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxNotificationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // timerNotification
            // 
            this.timerNotification.Tick += new System.EventHandler(this.timerNotification_Tick);
            // 
            // pxBxNotificationIcon
            // 
            this.pxBxNotificationIcon.Location = new System.Drawing.Point(13, 13);
            this.pxBxNotificationIcon.Name = "pxBxNotificationIcon";
            this.pxBxNotificationIcon.Size = new System.Drawing.Size(91, 85);
            this.pxBxNotificationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pxBxNotificationIcon.TabIndex = 0;
            this.pxBxNotificationIcon.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("NanumBarunGothic UltraLight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(110, 13);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(384, 85);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "notificationText";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pxBxClose
            // 
            this.pxBxClose.Location = new System.Drawing.Point(500, 12);
            this.pxBxClose.Name = "pxBxClose";
            this.pxBxClose.Size = new System.Drawing.Size(39, 35);
            this.pxBxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pxBxClose.TabIndex = 2;
            this.pxBxClose.TabStop = false;
            this.pxBxClose.Click += new System.EventHandler(this.pxBxClose_Click);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 110);
            this.Controls.Add(this.pxBxClose);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pxBxNotificationIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.ShowInTaskbar = false;
            this.Text = "Notification";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notification_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pxBxNotificationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxBxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerNotification;
        private System.Windows.Forms.PictureBox pxBxNotificationIcon;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox pxBxClose;
    }
}