using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace Pong
{
    public partial class Game : UserControl
    {

        public Game()
        {
            InitializeComponent();
        }

        private void Game_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                StartGame();
            }
            else
            {

            }
        }

        private void StartGame()
        {
            
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                Player1.Location = new Point(Player1.Location.X, Player1.Location.Y + 1);
            }
        }
    }
}
