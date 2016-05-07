using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout {
    public partial class Form1 : Form {
        private GameDoc gameDoc;
        public Timer timer;
        private int leftX;
        private int topY;
        private int width;
        private int height;
        public int timeLeft=179;
        public Timer timer2;
        private bool move { get; set; }
        private Bitmap renderBmp;

        public Form1() {
            InitializeComponent();
            gameDoc = new GameDoc();
            this.DoubleBuffered = true;
            width = 780;
            height = 540;
            
            gameDoc.AddBlocks();
            timer = new Timer();
            timer.Interval = 13;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            leftX = 0;
            topY = 0;

            timer2 = new Timer();
            timer2.Interval = 50000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
            
                DrawHearts(3);
            Image img = Image.FromFile("bgr.png");
            BackgroundImage = img;
           
        }
       

        void timer2_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items.Clear();
            if (gameDoc.Ball.Lives <= 6)
            {
                gameDoc.Ball.Lives++;
            }
            DrawHearts(gameDoc.Ball.Lives);
            gameDoc.FBlock.Width = gameDoc.FBlock.Width - gameDoc.FBlock.Width * 0.25;
            Invalidate(true);
        }

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
        



        void timer_Tick(object sender, EventArgs e)
        {
            
            label1.Text = "Score: " + gameDoc.Score;
            
            
            //label2.Text = DateTime.Now.Second;
            if (move)
            {
                gameDoc.Ball.Move(leftX, topY, width, height);
                gameDoc.CheckColisions();
                gameDoc.checkFloorColisions();
                CheckMiss();
                Invalidate(true);
            }
        }

        private void DrawHearts(int a)
        {
            Image img = Image.FromFile("Heart.png");
            for (int i = 0; i < a; i++)
           {
            statusStrip1.Items.Add(img);
           }
        }
        private void CheckMiss()
        {
            if (gameDoc.Ball.Lives==0 || timeLeft==0 || gameDoc.Blocks.Count==0)
            {
                statusStrip1.Items.Clear();
                if (gameDoc.Ball.Lives == 0)
                {
                    pictureBox1.Visible = true;
                }
                timer.Stop();
                
                GameOverDialog form = new GameOverDialog(gameDoc.Score);
                
                
                form.Show();
               
                Timer t = new Timer();
                t.Interval = 5000;
                t.Tick += new System.EventHandler(this.t_Tick);
                t.Start();
            }
            else if (gameDoc.Ball.CheckLife == true)
            {
                statusStrip1.Items.Clear();
                DrawHearts(gameDoc.Ball.Lives);
                gameDoc.Ball.CheckLife = false;
                move = false;
            }
        }

       
       
        private void t_Tick(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gameDoc.Draw(e.Graphics);
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                move = true;
                timer1.Start();
            }
            else if (e.KeyCode == Keys.P)
            {
                move = false;
            }
            /*    if(e.KeyCode==Keys.Left)
                 {
                     gameDoc.FBlock.Move("left");

                 }
                 else if(e.KeyCode==Keys.Right)
                 {
                     gameDoc.FBlock.Move("right"); 
                 }*/
            if (e.KeyCode == Keys.Up)
            {
                gameDoc.Ball.velocityY = -2;
                gameDoc.Ball.velocityX = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                gameDoc.Ball.velocityY = 2;
                gameDoc.Ball.velocityX = 0;
            }
            if (e.KeyCode == Keys.Left)
            {
                gameDoc.Ball.velocityY = 0;
                gameDoc.Ball.velocityX = -2;
            }
            if (e.KeyCode == Keys.Right)
            {
                gameDoc.Ball.velocityY = 0;
                gameDoc.Ball.velocityX = 2;
            }


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            gameDoc.FBlock.Move(e.X);
        }
        
       void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                label2.Text = timeLeft.ToString()+" seconds";
                timeLeft = timeLeft - 1;
                
            }
            else
            {
               
                timer1.Stop();
                
            }
        }
    }
}
