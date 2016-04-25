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

        private float velocityX;
        private float velocityY;

        public bool IsColided { get; set; }

        public Ball (Point center, Color color) {
            Center = center;
            Color = color;
            IsColided = false;
            Velocity = 8;
            Random r = new Random();
            Angle = r.Next(180, 183);
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);
        }

        public void Draw(Graphics g) {
           // Brush brush = new SolidBrush(Color);
            Image newImage = Image.FromFile("Ball.png");

            g.DrawImage(newImage, Center.X - RADIUS, Center.Y- RADIUS, RADIUS*2, RADIUS*2);
           // g.FillEllipse(brush, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
           // brush.Dispose();
        }

        public bool IsColiding(Block block) {
            bool collisionX = Center.X + RADIUS >= block.Corner.X && block.Corner.X + 50 >= Center.X - RADIUS;
            bool collisionY = Center.Y + RADIUS >= block.Corner.Y && block.Corner.Y + 30 >= Center.Y - RADIUS;
            return collisionX && collisionY;
        }

        public bool IsColiding(FloorBlock block)
        {
            bool collisionX = Center.X + RADIUS >= block.Corner.X && block.Corner.X + 100 >= Center.X - RADIUS;
            bool collisionY = Center.Y + RADIUS >= block.Corner.Y && block.Corner.Y + 20 >= Center.Y - RADIUS;
            return collisionX && collisionY;
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
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
        }




        public void Reverse()
        {
           
            velocityY = -velocityY;
        }
    }
}
