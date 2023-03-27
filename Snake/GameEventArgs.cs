using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameEventArgs : EventArgs
    {
        public int Score { get; }

        public GameEventArgs(int score)
        {
            Score = score;
        }
    }
}
