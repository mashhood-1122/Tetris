using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris1212
{
    public class BlocksManager
    {
        List<BlockCombo> _availableBlocks;
        const int MaxWidth = 10;
        const int MaxHeight = 20;
        const int MaxHeightX = 24;
        public int[,] _Grid;
        public int linesClear = 0;

        public BlockCombo _currentBlock;
        int _interval = 500;
        public int Level = 1;
        int _timeSinceLastUpdate = 0;

        bool over = true;

                public BlocksManager()
        { 
            _availableBlocks = new List<BlockCombo>();
           
            _availableBlocks.Add( new BlockI());
            _availableBlocks.Add(new BlockL());
            _availableBlocks.Add(new BlockJ());
            _availableBlocks.Add(new BlockO());
            _availableBlocks.Add(new BlockT());
            _availableBlocks.Add(new BlockZ());
            _availableBlocks.Add(new BlockS());

            _Grid = new int[MaxWidth, MaxHeightX];

            _currentBlock = _availableBlocks[0];
            _currentBlock.PosX = 4;
        }

        public void Update(GameTime gameTime)
        {
           
                int delta = gameTime.ElapsedGameTime.Milliseconds;
                _timeSinceLastUpdate += delta;
                if (_timeSinceLastUpdate > _interval)
                {

                    constrainBlock();
                    if (TestBlock())
                    {
                        AddCurrentBlock();
                        ResetWithNewBlock();
                    }
                    else
                    {
                        _currentBlock.PosY += 1;
                    }
                    _timeSinceLastUpdate = 0;
                }
            
        }


        public int CurrentBlockYPosition()
        {
            return _currentBlock.PosY;
        }

        public bool gameEnd() 
        {
            return over;
        }

        public bool constrainBlock()
        {
            var blockObj = _currentBlock;
            var blockRaw = blockObj.GetCurrent().BlockObj;

            for (int bx = 0; bx < 4; bx++)
            {
                for (int by = 0; by < 4; by++)
                {
                    int pointX = blockObj.PosX + bx;
                    int pointY = blockObj.PosY + by;
                    int pointIs = blockRaw[bx, by];

                    if (pointX >= MaxWidth && pointIs > 0)
                        return true;

                    if (pointX < 0 && pointIs > 0)
                        return true;

                    if (pointX < MaxWidth && pointY < MaxHeightX && pointIs > 0)
                    {
                        int gridPoint = _Grid[pointX, pointY];
                        if (gridPoint > 0 && pointIs > 0)
                            return true;
                    }
                }
            }

            return false;
        }

        public void MoveRight()
        {
            _currentBlock.PosX += 1;
            if (constrainBlock())
                _currentBlock.PosX -= 1;
        }
        public void MoveLeft()
        {
            _currentBlock.PosX -= 1;
            if (constrainBlock())
                _currentBlock.PosX += 1;
        }

        public void switchRotation()
        {
            _currentBlock.prevBlock();
            if (constrainBlock())
                _currentBlock.nextBlock();
        }

        public bool TestBlock()
        {

            var blockObj = _currentBlock;
            var blockRaw = blockObj.GetCurrent().BlockObj;

            for (int bx = 0; bx < 4; bx++)
            {
                for (int by = 0; by < 4; by++)
                {
                    int pointX = blockObj.PosX + bx;
                    int pointY = blockObj.PosY + by + 1;
                    int pointIs = blockRaw[bx, by];

                    if (pointY >= MaxHeightX && pointIs > 0)
                        return true;

                    if (pointX < MaxWidth && pointY < MaxHeightX && pointIs > 0)
                    {
                        int gridPoint = _Grid[pointX, pointY];
                        if (gridPoint > 0 && pointIs > 0)
                            return true;
                    }
                }
            }

            return false;
        }

        public void AddCurrentBlock()
        {
            var blockObj = _currentBlock;
            var blockRaw = blockObj.GetCurrent().BlockObj;

            for (int bx = 0; bx < 4; bx++)
            {
                for (int by = 0; by < 4; by++)
                {
                    int pointX = blockObj.PosX + bx;
                    int pointY = blockObj.PosY + by;
                    int pointIs = blockRaw[bx, by];

                    if (pointIs > 0 && pointY < MaxHeightX)
                        _Grid[pointX, pointY] = _currentBlock.color;
                }
            }

        }

        public void LineClear()
        {
            //int totalLinesToClear = 0;
            int[,] _Grid1 = new int[MaxWidth, MaxHeightX];

            for (int y = MaxHeightX-1; y >= 4; y--)
            {
                if(_Grid[0,y] != 0 &&_Grid[1,y] !=0 && _Grid[2,y] !=0 && _Grid[3,y] != 0 && _Grid[4,y] != 0 &&_Grid[5,y] != 0 &&_Grid[6,y] != 0 &&_Grid[7,y] != 0 &&_Grid[8,y] != 0 &&_Grid[9,y] != 0)
                {
                    for (int x=y ;x>=4;x--)
                    {
                        _Grid1[0, x] = _Grid[0, x - 1];
                        _Grid1[1, x] = _Grid[1, x - 1];
                        _Grid1[2, x] = _Grid[2, x - 1];
                        _Grid1[3, x] = _Grid[3, x - 1];
                        _Grid1[4, x] = _Grid[4, x - 1];
                        _Grid1[5, x] = _Grid[5, x - 1];
                        _Grid1[6, x] = _Grid[6, x - 1];
                        _Grid1[7, x] = _Grid[7, x - 1];
                        _Grid1[8, x] = _Grid[8, x - 1];
                        _Grid1[9, x] = _Grid[9, x - 1];
                    }
                    this._Grid = _Grid1;
                    y = MaxHeightX - 1; 
                }
                else
                {
                    _Grid1[0, y] = _Grid[0, y];
                    _Grid1[1, y] = _Grid[1, y];
                    _Grid1[2, y] = _Grid[2, y];
                    _Grid1[3, y] = _Grid[3, y];
                    _Grid1[4, y] = _Grid[4, y];
                    _Grid1[5, y] = _Grid[5, y];
                    _Grid1[6, y] = _Grid[6, y];
                    _Grid1[7, y] = _Grid[7, y];
                    _Grid1[8, y] = _Grid[8, y];
                    _Grid1[9, y] = _Grid[9, y];
                }
            }

            this._Grid=_Grid1;

            //List<int> linesToClear = new List<int>();

            //for (int j=MaxHeightX-1; j>=0; j--)
            //{
            //    bool lineClearFlag = true;
            //    for (int i=MaxWidth-1; i>=0; i--)
            //    {
            //        if (_Grid[i,j] == 0)
            //        {
            //            lineClearFlag = false;
            //            break;
            //        }
            //    }
            //    if (lineClearFlag)
            //    {
            //        linesToClear.Add( j );
            //    }
            //}

            ////for (int x = MaxHeightX - 1; x >= MaxHeightX - 1 - totalLinesToClear; x--)
            //foreach(int x in linesToClear)
            //for (int j = MaxHeightX - 1; j >= 0; j--)
            //{
            //    for (int i = MaxWidth - 1; i >= 0; i--)
            //    {
            //        if (j - (MaxHeightX-x) < 0)
            //            continue;
            //        _Grid[i, j] = _Grid[i, j - (MaxHeightX - x)];
            //    }
            //}

        }

        public int NumbersofLineToClear()
        {
            int lines = 0;
            for (int y = MaxHeightX - 1; y >= 4; y--)
            {
                if (_Grid[0, y] != 0 && _Grid[1, y] != 0 && _Grid[2, y] != 0 && _Grid[3, y] != 0 && _Grid[4, y] != 0 && _Grid[5, y] != 0 && _Grid[6, y] != 0 && _Grid[7, y] != 0 && _Grid[8, y] != 0 && _Grid[9, y] != 0)
                {
                    lines++;
                }
            }
            linesClear += lines;
            if (linesClear>3)
            {
                Level++;
                _interval -= 100;
            }
            return lines;
 
        }

        public void ResetWithNewBlock()
        {
            _currentBlock.PosY = 0;
            int maxBlocks = _availableBlocks.Count;
            Random r = new Random();
            _currentBlock = _availableBlocks[ r.Next(0, maxBlocks) ];
            _currentBlock.PosX = 4;

            if (_Grid[4, 4] != 0 || _Grid[5, 4] != 0 || _Grid[6, 4] != 0 || _Grid[7, 4] != 0)
            {
               over = false;

            }

            int a = NumbersofLineToClear();
            for (int i = 1; i <= a;i++)
                LineClear();
        }
    }
}
