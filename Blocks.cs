using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Blocks
    {
        public int x;
        public int y;
        public int[,] Shapes;

        public Blocks(int _x, int _y)
        {
            x = _x;
            y = _y;

            Shapes = new int[3, 4]
            {
                {0,1,0,0},
                {0,1,1,0},
                {0,0,1,0}
            };
        }

        public void MoveDown()
        {
            y++;
        }

        public void MoveRight()
        {
            x++;
        }
        public void MoveLeft()
        {
            x--;
        }

    
    }
}
