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

        public BlockCombo _currentBlock;
        int _interval = 150;
        int _timeSinceLastUpdate = 0;
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
                        _currentBlock.PosY += 1;
                    _timeSinceLastUpdate = 0;
                }
            
        }


        public int CurrentBlockYPosition()
        {
            return _currentBlock.PosY;
        }

        public bool gameEnd() 
        {
            int Check = 0;
            for (int i = 0; i <= MaxWidth; i++)
            {
                Check = 0;

                for (int j = 0; j <= MaxHeight; j++)
                {
                    if (_Grid[i, j] == 1)
                    {
                        Check = Check + 1;
                    }
                }

                if (Check == MaxHeight)
                {
                    return true;
                }
            }

                    return false;
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
                        _Grid[pointX, pointY] = pointIs;
                }
            }

        }

        public void LineClear()
        {
            //int totalLinesToClear = 0;
            List<int> linesToClear = new List<int>();

            for (int j=MaxHeightX-1; j>=0; j--)
            {
                bool lineClearFlag = true;
                for (int i=MaxWidth-1; i>=0; i--)
                {
                    if (_Grid[i,j] == 0)
                    {
                        lineClearFlag = false;
                        break;
                    }
                }
                if (lineClearFlag)
                {
                    linesToClear.Add( j );
                }
            }

            //for (int x = MaxHeightX - 1; x >= MaxHeightX - 1 - totalLinesToClear; x--)
            foreach(int x in linesToClear)
            for (int j = MaxHeightX - 1; j >= 0; j--)
            {
                for (int i = MaxWidth - 1; i >= 0; i--)
                {
                    if (j - (MaxHeightX-x) < 0)
                        continue;
                    _Grid[i, j] = _Grid[i, j - (MaxHeightX - x)];
                }
            }

        }

        public void ResetWithNewBlock()
        {
            _currentBlock.PosY = 0;
            int maxBlocks = _availableBlocks.Count;
            Random r = new Random();
            _currentBlock = _availableBlocks[ r.Next(0, maxBlocks) ];
            _currentBlock.PosX = 4;

            LineClear();
        }
    }
}
