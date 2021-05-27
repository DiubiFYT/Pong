using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Pong
{
    internal class User
    {
        [JsonProperty]
        internal string Nickname { get; private set; }
        [JsonProperty]
        internal string Password { get; private set; }
        [JsonProperty]
        internal string IP { get; private set; }

        [JsonProperty]
        public static User currentUser { get; private set; }

        public User()
        {

        }

        public User(string nickname, string password)
        {
            if(Authenticate(nickname, password))
            {
                currentUser.Nickname = nickname;
                currentUser.Password = password;
                currentUser.IP = Methods.GetPublicIP();
                SendJSON();
            }
        }

        private bool RetrieveAccountFile(string nickname)
        {
            Notification notification = new Notification();

            try
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://pongsignup.ddns.net/accounts/" + nickname + ".json", AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                return true;
            }
            catch (Exception e)
            {
                notification.Show(e.Message, Notification.enmType.Error);
                return false;
            }
        }

        private bool Authenticate(string nickname, string password)
        {
            if (RetrieveAccountFile(nickname))
            {
                Notification notification = new Notification();

                currentUser = JsonConvert.DeserializeObject<User>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"));

                if (currentUser.Nickname == nickname && currentUser.Password == password)
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                    notification.Show("Authenticated!", Notification.enmType.Success);
                    return true;
                }
                else
                {
                    currentUser = null;
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                    notification.Show("Authentication failed. Check your credentials.", Notification.enmType.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void Logout()
        {
            Notification notification = new Notification();
            currentUser = null;
            notification.Show("Logged out successfully.", Notification.enmType.Success);
        }

        private void SendJSON()
        {
            try
            {
                string userData = JsonConvert.SerializeObject(currentUser, Formatting.None, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
                    
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                sw.Write(userData);

                File.Replace(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json", "https://pongsignup.ddns.net/accounts/" + currentUser.Nickname + ".json", null);

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
            }
            catch(Exception e)
            {
                Notification notification = new Notification();
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                notification.Show(e.Message, Notification.enmType.Error);
            }
        }
    }
}