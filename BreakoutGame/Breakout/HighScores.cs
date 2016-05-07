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
            Image img = Image.FromFile("bgStart.png");
            this.BackgroundImage = img;
        }
        private Bitmap renderBmp;
        public override Image BackgroundImage
        {
            set
            {
                Image baseImage = value;
                renderBmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Graphics g = Graphics.FromImage(renderBmp);
                g.DrawImage(baseImage, 0, 0, Width, Height);
                g.Dispose();
            }
            get
            {
                return renderBmp;
            }
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
            int idm = 1;
            foreach (Score s in scores)
            {
                lbHighScores.Items.Add(idm+". "+s.ToString());
                idm++;
                
            }
        }
    }
}
