using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            PopulateList();
 
        }

        public void PopulateList()
        {
            string line;
            List<Score> scores = new List<Score>();

            System.IO.StreamReader file = new System.IO.StreamReader("highscores.bk");
            while ((line = file.ReadLine()) != null)
            {
                Score score = new Score(line.Substring(0, line.LastIndexOf(' ')), Int32.Parse(line.Substring(line.LastIndexOf(' '))));
                scores.Add(score);
            }

            
            for (int i = 0; i < scores.Count; i++)
            {
                for (int j =0 ; j < scores.Count ; j++)
                    if (scores[i].Points > scores[j].Points)
                {
                    Score tmp = scores[j];
                    scores[j] = scores[i];
                    scores[i] = tmp;
                }
            }
            foreach (Score s in scores)
            {
                lbHighScores.Items.Add(s.ToString());
            }
        }
    }
}
