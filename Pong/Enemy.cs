using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Enemy
    {
        public string Nickname { get; set; }
        public string IP { get; set; }
        public string LANIP { get; set; }

        public static Enemy currentEnemy { get; set; } = new Enemy();

        public Enemy()
        {

        }

        public Enemy(string nickname, string ip)
        {
            Nickname = nickname;
            IP = ip;
        }
    }
}
