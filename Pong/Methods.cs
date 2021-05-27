using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Methods
    {
        internal static string GetPrivateIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        internal static string GetPublicIP()
        {
            try
            {
                string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();

                return externalIpString;
            }
            catch(Exception e)
            {
                Notification notification = new Notification();
                notification.Show(e.Message, Notification.enmType.Error);
                return null;
            }
        }
    }
}
