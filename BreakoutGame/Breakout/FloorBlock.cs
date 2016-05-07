using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    public class FloorBlock
    {
        public Point Corner { get; set; }
        public Color Color { get; set; }
        public double Width { get; set; }
        public static int height = 20;

        public bool IsColided { get; set; }

        public FloorBlock(Point corner, Color color)
        {
            Corner = corner;
            Color = color;
            IsColided = false;
            Width = 150;
        }

        public void Draw(Graphics g)
        {
           
            Image newImage = Image.FromFile("Dock.png");
           
            g.DrawImage(newImage,Corner.X,Corner.Y,(float)Width,height);
            
            
        }

        public void Move(string dir)
        {
            int posX = Corner.X;

            Point p;
            if(dir.Equals("left") && Corner.X>=20)
            {

                p = new Point(Corner.X - 55, Corner.Y);
                Corner = p;
            }
            else if(dir.Equals("right") && Corner.X <= 700)
            {
                p = new Point(Corner.X + 55, Corner.Y);
                Corner = p;
            }
            
        }
      public void Move(int possX)
        {
            Point p;
            p = new Point(possX-55, Corner.Y);
            Corner = p;
        } 


    }
}
