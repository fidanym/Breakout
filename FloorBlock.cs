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
        public static int width = 100;
        public static int height = 20;

        public bool IsColided { get; set; }

        public FloorBlock(Point corner, Color color)
        {
            Corner = corner;
            Color = color;
            IsColided = false;
        }

        public void Draw(Graphics g)
        {
           
            Image newImage = Image.FromFile("Dock.png");
           
            g.DrawImage(newImage,Corner.X,Corner.Y,width,height);
            
            
        }

        public void Move(string dir)
        {
            int posX = Corner.X;

            Point p;
            if(dir.Equals("left") && Corner.X>=0)
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



    }
}
