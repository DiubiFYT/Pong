using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    internal partial class Notification : Form
    {
        internal Notification()
        {
            InitializeComponent();
        }

        internal enum enmAction
        {
            wait,
            start,
            close
        }

        internal enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private enmAction action;
        private enmType type;

        private int x, y;

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 200; i++)
            {
                fname = "alert" + i.ToString();
                Notification frm = (Notification)Application.OpenForms[fname];

                if (frm != null && this.Location.Y > frm.Location.Y)
                {
                    frm.Name = "alert" + (i - 1).ToString();
                    frm.y += this.Height + 5;
                    frm.Location = new Point(frm.x, frm.y);
                }
            }
        }

        private void timerNotification_Tick(object sender, System.EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    if (type == enmType.Error)
                    {
                        timerNotification.Interval = 999999999;
                        action = enmAction.close;
                    }
                    else
                    {
                        timerNotification.Interval = 5000;
                        action = enmAction.close;
                    }
                    break;

                case Notification.enmAction.start:
                    this.timerNotification.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Notification.enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timerNotification.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pxBxClose_Click(object sender, System.EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timerNotification.Interval = 5000;
                    action = enmAction.close;
                    break;

                case Notification.enmAction.start:
                    this.timerNotification.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Notification.enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timerNotification.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        internal void Show(string msg, enmType type)
        {
            TopMost = true;

            this.TopMost = true;
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            pxBxClose.Image = Resources.delete_icon;

            for (int i = 1; i < 200; i++)
            {
                fname = "alert" + i.ToString();
                Notification frm = (Notification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pxBxNotificationIcon.Image = Resources.success_icon;
                    this.BackColor = Color.SeaGreen;
                    break;

                case enmType.Error:
                    this.pxBxNotificationIcon.Image = Resources.delete_icon;
                    this.BackColor = Color.DarkRed;
                    break;

                case enmType.Info:
                    this.pxBxNotificationIcon.Image = Resources.info_icon;
                    this.BackColor = Color.RoyalBlue;
                    break;

                case enmType.Warning:
                    this.pxBxNotificationIcon.Image = Resources.exclamation_icon;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.lblMsg.Text = msg;

            this.Show();
            this.action = enmAction.start;
            this.timerNotification.Interval = 1;
            this.timerNotification.Start();

            //switch (this.action)
            //{
            //    case enmAction.wait:
            //        timerNotification.Interval = 5000;
            //        action = enmAction.close;
            //        break;

            //    case Notification.enmAction.start:
            //        this.timerNotification.Interval = 1;
            //        this.Opacity += 0.1;
            //        if (this.x < this.Location.X)
            //        {
            //            this.Left--;
            //        }
            //        else
            //        {
            //            if (this.Opacity == 1.0)
            //            {
            //                action = Notification.enmAction.wait;
            //            }
            //        }
            //        break;

            //    case enmAction.close:
            //        timerNotification.Interval = 1;
            //        this.Opacity -= 0.1;

            //        this.Left -= 3;
            //        if (base.Opacity == 0.0)
            //        {
            //            base.Close();
            //        }
            //        break;
            //}
        }
    }
}