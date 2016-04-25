using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout {
    public class Block {
        public Point Corner { get; set; }
        public Color Color { get; set; }
        public static int width = 50;
        public static int height = 30;

        public bool IsColided { get; set; }

        public Block(Point corner, Color color) {
            Corner = corner;
            Color = color;
            IsColided = false;
        }

        public void Draw(Graphics g) {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, Corner.X, Corner.Y, width, height);
            Pen p = new Pen(Color.Black);
            g.DrawRectangle(p, Corner.X, Corner.Y, width, height);
            brush.Dispose();
        }
    }
}
