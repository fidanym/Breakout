using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class GameOverDialog : Form
    {
       
        public GameOverDialog(int score)
        {
            InitializeComponent();
            textBox2.Text = score.ToString();
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            Start form = new Start();
           
           
            form.Show();
            string score = textBox1.Text + " " +textBox2.Text;
            using (FileStream fs = new FileStream("highscores.bk", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(score);
            }
                

            
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Empty name!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
                e.Cancel = false;
            }
        }

        private void GameOverDialog_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"GameOver.wav");
            sp.Play();
        }
    }
}
