using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout {
    class GameDoc {
        public Ball Ball { get; set; }
        public List<Block> Blocks { get; set; }

        public GameDoc() {
            Point ballCenter = new Point(400,550);
            Ball = new Ball(ballCenter, Color.Black);
            Blocks = new List<Block>();
        }

        public void AddBlocks() {
            Color color = Color.Blue;
            for(int i = 0; i <= 60; i += 20) {
                for(int j = 0; j <= 720; j += 80) {
                    Point p = new Point(j, i);
                    Block block = new Block(p, color);
                    Blocks.Add(block);
                }
            }
        }

        public void CheckColisions()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Ball.IsColiding(Blocks[i]))
                {
                    Blocks[i].IsColided = true;
                    Ball.Color = Color.Red;
                    Ball.Reverse();
                }
            }

            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].IsColided)
                    Blocks.RemoveAt(i);
            }
        }

        public void Draw(Graphics g)
        {
            Ball.Draw(g);
           foreach(Block b in Blocks)
            {
                b.Draw(g);
            }
        }

    }
}
