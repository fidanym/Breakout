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
        public FloorBlock FBlock { get; set; }
       // bool Remove { get; set; }
       public int Score { get; set; }
        Dictionary<int, string> boja = new Dictionary<int, string>();

        public GameDoc() {
            boja.Add(1, "MediumPurple");
            boja.Add(2, "MidnightBlue");
            boja.Add(3, "LimeGreen");
            boja.Add(4, "Gold");
            boja.Add(5, "Firebrick");
            Point ballCenter = new Point(400,500);
            Ball = new Ball(ballCenter, Color.Black);
            Point FloorPoint = new Point(400, 520);
            FBlock = new FloorBlock(FloorPoint, Color.Black);
            Blocks = new List<Block>();
            Score = 0;
        }

    
        public void AddBlocks() {
            int k = 1;
            for(int i = 10; i <= 150; i += 35) {
                for (int j = 10; j <= 750; j += 55) {
                  

                    Point p = new Point(j, i);
                    Block block = new Block(p, Color.FromName(boja[k]));
                    Blocks.Add(block);
                }
                k++;
            }
        }

        public void CheckColisions()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                Ball.IsColiding(Blocks[i]);
                if (Blocks[i].IsColided)
                {
                    Ball.Flag = false;
                    Score += Blocks[i].Value;
                }
            }
            
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].IsColided )
                {
                    
                        Blocks.RemoveAt(i);
                    
                }
            }
            Ball.Flag = true;
        }

        

        public void checkFloorColisions()
        {
            Ball.IsColiding(FBlock);
            
        }
        public void Draw(Graphics g)
        {
            Ball.Draw(g);
           foreach(Block b in Blocks)
            {
                b.Draw(g);
            }
            FBlock.Draw(g);
        }

    }
 
}
