using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class Score
    {
        public string Player { get; set; }
        public int Points { get; set; } 

        public Score (string player, int points)
        {
            Player = player;
            Points = points;
        }

        public override string ToString()
        {
            return Player + " " + Points;
        }
    }
}
