﻿using System;
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
    public partial class Start : Form
    {
       
        public Start()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
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
        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
           
            Form1 Formaa = new Form1();
            Formaa.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Изработиле:\n Илија Лазороски\n Фидан Јованов\n Стефан Кржовски\n");
        }

        private void btnHighscore_Click(object sender, EventArgs e)
        {
            
            HighScores form = new HighScores();
            form.Show();
        }
    }
}
