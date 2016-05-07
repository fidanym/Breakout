using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout {
    public class Ball {
        public static readonly int RADIUS = 10;
        public Point Center { get; set; }
        public Color Color { get; set; }

        public double Velocity { get; set; }
        public double Angle { get; set; }

        public float velocityX;
        public float velocityY;

        public int Lives { get; set; }
        public bool CheckLife { get; set; }
        public bool IsColided { get; set; }
        public bool Flag { get; set; } = true;

        public Ball (Point center, Color color) {
            Center = center;
            Color = color;
            IsColided = false;
            Velocity = 8;
            Random r = new Random();
            Angle = (float)r.Next(366, 575) / 100;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);
            Lives = 3;

            
        }

        public void Draw(Graphics g) {
           // Brush brush = new SolidBrush(Color);
            Image newImage = Image.FromFile("Ball.png");

            g.DrawImage(newImage, Center.X - RADIUS, Center.Y- RADIUS, RADIUS*2, RADIUS*2);
           // g.FillEllipse(brush, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
           // brush.Dispose();
        }

        public void IsColiding(Block block) {
            bool collisionX = Center.X + RADIUS >= block.Corner.X && Center.X - RADIUS <= block.Corner.X + 50;
            bool collisionY = Center.Y + RADIUS >= block.Corner.Y && block.Corner.Y + 30 >= Center.Y - RADIUS;

            if (collisionX && collisionY && Flag)
            { 
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"pong.wav");
                float wy = 70 * (block.Corner.Y + 15 - Center.Y);
                float hx = 50 * (block.Corner.X + 25 - Center.X);
                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        /* top */
                        velocityY = velocityY * -1;
                        block.IsColided = true;
                       
                        sp.Play();
                    }
                    else
                    {
                        velocityX = velocityX * -1;
                        block.IsColided = true;
                        /* left */
                       // System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"pong.wav");
                        sp.Play();
                    }
                }
                else
                {
                    if (wy > -hx)
                    {
                        velocityX = velocityX * -1;
                        block.IsColided = true;
                        /* right */
                      //  System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"pong.wav");
                        sp.Play();
                    }
                    else
                    {
                        /* bottom */
                        velocityY = velocityY * -1;
                        block.IsColided = true;
                        // System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"pong.wav");
                    sp.Play();
                    }

                }
            }
        }

        public void IsColiding(FloorBlock block)
        {
            bool collisionX = Center.X + RADIUS >= block.Corner.X && block.Corner.X + block.Width >= Center.X - RADIUS;
            bool collisionY = Center.Y + RADIUS >= block.Corner.Y && block.Corner.Y + 20 >= Center.Y - RADIUS;
            if (collisionX && collisionY)
            {
                double otsecka = -velocityX * 50;
                if ((Center.X <= block.Corner.X + block.Width * 0.25) && (Center.X >= block.Corner.X))
                {

                    //  if (Center.X - otsecka < block.Corner.X + block.Width * 0.25)
                    //  {
                    velocityX = velocityX * -1;
                    velocityY = -velocityY;
                    //  }
                    /* else
                     {
                         velocityY = -velocityY;
                     }*/
                }
                else if ((Center.X <= block.Corner.X + block.Width) && (Center.X >= block.Corner.X + block.Width * 0.75))
                {
                    //  if (Center.X - otsecka > block.Corner.X + block.Width)
                    // {
                    velocityX = velocityX * -1;
                    velocityY = -velocityY;
                    /*  }
                      else
                      {
                          velocityY = -velocityY;
                      }
                      */
                }
                else
                {
                    velocityY = -velocityY;
                }
            }
        }

        public void Move(int left, int top, int width, int height) {
            float nextX = Center.X + velocityX;
            float nextY = Center.Y + velocityY;
            if (nextX - RADIUS <= left || nextX + RADIUS >= width + left) {
                velocityX = -velocityX;
            }
            if (nextY - RADIUS <= top) {
                velocityY = -velocityY;
            }
            if (nextY + RADIUS >= height + top)
            {
                velocityY = -velocityY;
                Lives--;
                CheckLife = true;
                Point p = new Point(400, 500);
                Center = p;
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
        }




        public void Reverse()
        {
           
            velocityY = -velocityY;
        }
    }
}
