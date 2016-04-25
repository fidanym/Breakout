using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Breakout {
    public partial class Form1 : Form {
        private GameDoc gameDoc;
        private Timer timer;
        private int leftX;
        private int topY;
        private int width;
        private int height;
      

        public Form1() {
            InitializeComponent();
            gameDoc = new GameDoc();
            this.DoubleBuffered = true;
            gameDoc.AddBlocks();
            timer = new Timer();
            timer.Interval = 13;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            leftX = 0;
            topY = 0;
            width = 780;
            height = 540;
            
        }
        private bool move { get; set; }
        void timer_Tick(object sender, EventArgs e)
        {
           
            if (move)
            {
                gameDoc.Ball.Move(leftX, topY, width, height);
                gameDoc.CheckColisions();
                gameDoc.checkFloorColisions();
                DrawHearts();
                Invalidate(true);
            }
        }

        private void DrawHearts()
        {
            Image img = Image.FromFile("Heart.png");
            if (gameDoc.Ball.Lives == 3)
            {
                statusStrip1.Items.Clear();
                for (int i = 0; i < 3; i++)
                {
                    statusStrip1.Items.Add(img);
                }
                
               
            }
            else if(gameDoc.Ball.Lives==2)
            {
                statusStrip1.Items.Clear();
                for (int i = 0; i < 2; i++)
                {
                    statusStrip1.Items.Add(img);
                }
                move = false;
                
            }
            else if(gameDoc.Ball.Lives==1)
            {
                statusStrip1.Items.Clear();
                
                    statusStrip1.Items.Add(img);
            }
            else if(gameDoc.Ball.Lives == 0)
            {
                move = false;
                statusStrip1.Items.Clear();
                timer.Stop();
                MessageBox.Show("izgubi");

            }
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
            
            if(e.KeyCode == Keys.Space)
            {
                
                move = true;
            }
            else if(e.KeyCode== Keys.P)
            {
                move = false;
            }
            if(e.KeyCode==Keys.Left)
            {
                gameDoc.FBlock.Move("left");
            }else if(e.KeyCode==Keys.Right)
            {
                gameDoc.FBlock.Move("right");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label1.Text = "Преостанато време:"+timer.Interval.ToString();
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            gameDoc.FBlock.Move(e.X);
        }
    }
}
