using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris1212
{
    public class BlockCombo
    {
        public List<Block> Combo;
        public int color = 0;
        public int PosX { get; set; }
        public int PosY { get; set; }

        public int _currentBlock;

        public BlockCombo()
        {
            Combo = new List<Block>();
        }

        public void prevBlock()
        {
            _currentBlock += -1;
            if (_currentBlock < 0)
                _currentBlock = Combo.Count-1;
        }

        public void nextBlock()
        {
            _currentBlock += 1;
            if ( _currentBlock >= Combo.Count )
                _currentBlock = 0;
        }

        public Block GetCurrent()
        {
            return Combo[_currentBlock]; 
        }
        /*
        public Block FindById(int Id)
        { 
            Block obj = new Block();

            return obj;
        }*/



    }

    public class BlockI : BlockCombo
    {
        public BlockI() : base()
        {
            base.color = 1;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,1,0},
                                           {0,0,1,0},
                                           {0,0,1,0},
                                           {0,0,1,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {1,1,1,1},
                                           {0,0,0,0},
                                           {0,0,0,0}};

            Combo.Add(block);
        }
    }

    public class BlockJ : BlockCombo
    {
        public BlockJ()
            : base()
        {
            base.color = 2;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,1,0,0},
                                           {0,1,0,0},
                                           {0,1,0,0},
                                           {0,1,1,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,0,0,1},
                                           {1,1,1,1},
                                           {0,0,0,0}};

            Combo.Add(block);

            block = new Block(); 
            block.BlockObj = new int[4, 4] {{0,1,1,0},
                                           {0,0,1,0},
                                           {0,0,1,0},
                                           {0,0,1,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {1,1,1,1},
                                           {1,0,0,0},
                                           {0,0,0,0}};

            Combo.Add(block);
        }
    }

    public class BlockL : BlockCombo
    {
        public BlockL()
            : base()
        {
            base.color = 3;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,1,0},
                                           {0,0,1,0},
                                           {0,0,1,0},
                                           {0,1,1,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {1,0,0,0},
                                           {1,1,1,1},
                                           {0,0,0,0}};

            Combo.Add(block);


            block = new Block();
            block.BlockObj = new int[4, 4] {{0,1,1,0},
                                           {0,1,0,0},
                                           {0,1,0,0},
                                           {0,1,0,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {1,1,1,1},
                                           {0,0,0,1},
                                           {0,0,0,0}};

            Combo.Add(block);
        }

    }

    public class BlockO : BlockCombo
    {
        public BlockO()
            : base()
        {
            base.color = 4;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,1,1,0},
                                           {0,1,1,0},
                                           {0,0,0,0}};
            Combo.Add(block);

        }
    }


    public class BlockS : BlockCombo
    {
        public BlockS()
            : base()
        {
            base.color = 5;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,0,1,1},
                                           {0,1,1,0},
                                           {0,0,0,0}};
            Combo.Add(block);

            block = new Block(); 
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,0,1,0},
                                           {0,1,1,0},
                                           {0,1,0,0}};
            


            Combo.Add(block);
        }
    }


    public class BlockT : BlockCombo
    {
        public BlockT()
            : base()
        {
            base.color = 2;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,1,0,0},
                                           {1,1,1,0},
                                           {0,0,0,0}};
            Combo.Add(block);


            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,1,0,0},
                                           {0,1,1,0},
                                           {0,1,0,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,0,0,0},
                                           {1,1,1,0},
                                           {0,1,0,0}};
            Combo.Add(block);

        }
    }


    public class BlockZ : BlockCombo
    {
        public BlockZ()
            : base()
        {
            base.color = 3;
            var block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {1,1,0,0},
                                           {0,1,1,0},
                                           {0,0,0,0}};
            Combo.Add(block);

            block = new Block();
            block.BlockObj = new int[4, 4] {{0,0,0,0},
                                           {0,0,1,0},
                                           {0,1,1,0},
                                           {0,1,0,0}};
            Combo.Add(block);

        }
    }
}


