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
            height = 570;
        }
        private bool move { get; set; }
        void timer_Tick(object sender, EventArgs e)
        {

            if (move)
            {
                gameDoc.Ball.Move(leftX, topY, width, height);
                gameDoc.CheckColisions();
                Invalidate(true);
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
        }
    }
}
