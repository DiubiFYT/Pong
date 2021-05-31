using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

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
        internal string LANIP { get; private set; }

        [JsonProperty]
        public static User currentUser { get; private set; }

        //[JsonProperty]
        //public static User enemyUser { get; set; }

        public User()
        {
        }

        public User(string nickname, string password)
        {
            if (Authenticate(nickname, password))
            {
                currentUser.Nickname = nickname;
                currentUser.Password = password;
                currentUser.IP = Methods.GetPublicIP();
                currentUser.LANIP = Methods.GetPrivateIP();
                SendJSON();
            }
        }

        public static bool RetrieveAccountFile(string nickname)
        {
            Notification notification = new Notification();

            try
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://pongsignup.ddns.net/accounts/" + nickname + ".json", AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                return true;
            }
            catch
            {
                notification.Show("Account not found.", Notification.enmType.Error);
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
                sw.Close();

            Replace:
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"))
                {
                    WebClient wc = new WebClient();
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + @"\\currentAccount.json", AppDomain.CurrentDomain.BaseDirectory + @"\\" + currentUser.Nickname + ".json");
                    byte[] ciao = wc.UploadFile("https://pongsignup.ddns.net/update", AppDomain.CurrentDomain.BaseDirectory + "\\" + currentUser.Nickname + ".json");
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + currentUser.Nickname + ".json");
                }
                else
                {
                    RetrieveAccountFile(currentUser.Nickname);
                    goto Replace;
                }
            }
            catch (Exception e)
            {
                Notification notification = new Notification();

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\currentAccount.json");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + currentUser.Nickname + ".json"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + currentUser.Nickname + ".json");
                }

                notification.Show(e.Message, Notification.enmType.Error);
            }
        }
    }
}