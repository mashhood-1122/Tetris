using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris1212
{
    public class Block
    {
        private const int maxWidht = 4;
        private const int maxHeight = 4;

        private int[,] blocks = new int[maxWidht, maxHeight];

        public int[,] BlockObj { get { return blocks;}  set { blocks = value; } }
         
        public Block()
        {
 
        }

        
    }
}
