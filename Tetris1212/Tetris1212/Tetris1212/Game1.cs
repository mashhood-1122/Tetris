using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace Tetris1212
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>



    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int MaxWidth = 10;
        const int MaxHeight = 20;
        const int MaxHeightX = 24;
        Texture2D blockYellow;

        SpriteFont Font;

        BlocksManager _bMgr;
        String[] colorBlocks = {"", ".\\blockYellow", ".\\blockRed", ".\\blockPink", ".\\blockGreen", ".\\blockBlue" };
        double time = 0;
        double sec = 00;
        double Min = 00;
      ///  int Score = 0;
      //  public static Song menuSong;
        

       // KeyboardState _lastKeyState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            int[,] _Grid = new int[MaxWidth, MaxHeight+4];

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _bMgr = new BlocksManager();

            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
          //  _bMgr = new BlocksManager();
            //Random r = new Random();
            //int id = r.Next(0, 4);
            blockYellow = this.Content.Load<Texture2D>(colorBlocks[1]);
            Font = this.Content.Load<SpriteFont>("SpriteFont1");

           // ContentManager Content;

           //Content = (ContentManager)Game.Services.GetService(typeof(ContentManager));
           // ContentManager contentManager = new ContentManager(this.Services, @"Content");

          //  menuSong = Content.Load<Song>(@"Daft");
            //this.hitCannon = Content.Load<Song>(@"PlayerJump");
           

            //blockYellow = this.Content.Load<Texture2D>(".\\blockYellow");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //KeyboardState newKeyState = Keyboard.GetState();
            //if (newKeyState.IsKeyDown(Keys.A) && !_lastKeyState.IsKeyDown(Keys.A))
            //{
            //    _bMgr._currentBlock.prevBlock();
            //}

           sec += gameTime.ElapsedGameTime.TotalSeconds;
           if (sec > 1.0)
           {
               
               time++;
               sec -= 1.0;
               if (time == 60)
               {
                   time = 0;
                   Min++;
               }
           }

            TouchCollection touches = TouchPanel.GetState();
            foreach (TouchLocation touch in touches)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    if (touch.Position.Y < 200)
                        _bMgr.switchRotation();
                    else if (touch.Position.X < 180)
                        _bMgr.MoveLeft();
                    else if (touch.Position.X > 220)
                        _bMgr.MoveRight();
                }
            }

            _bMgr.Update(gameTime);
           // _lastKeyState = newKeyState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
          //  MediaPlayer.Play(menuSong);
            spriteBatch.Begin();

            spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
            spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
            spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);

            if (_bMgr.gameEnd())
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                int blockDrawSize = 38;
                int gridDrawSizeH = blockDrawSize * MaxHeight;
                int gridDrawSizeW = blockDrawSize * MaxWidth;

                int gridOffsetX = (480 - gridDrawSizeW) / 2;
                int gridOffsetY = 20;
                // TODO: Add your drawing code here
                Texture2D rect = new Texture2D(graphics.GraphicsDevice, gridDrawSizeW, gridDrawSizeH);
                Vector2 coor = new Vector2(gridOffsetX, gridOffsetY);
                Vector2 coorBlocks = new Vector2(gridOffsetX, gridOffsetY - blockDrawSize * 4);

                Color[] data = new Color[gridDrawSizeW * gridDrawSizeH];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.Black;
                rect.SetData(data);
                spriteBatch.Draw(rect, coor, Color.White);

                var blockObj = _bMgr._currentBlock;
                var blockRaw = blockObj.GetCurrent().BlockObj;

                int test = _bMgr.CurrentBlockYPosition();
                //if (test == 0)
                //{
                //    Random r = new Random();
                //    int id = r.Next(0, 4);
                //    blockYellow = this.Content.Load<Texture2D>(colorBlocks[id]);
                //}
                //var zzz = blockObj.BlockObj;

                for (int bx = 0; bx < 4; bx++)
                    for (int by = 0; by < 4; by++)
                    {
                        if (blockRaw[bx, by] == 0)
                            continue;
                        var vecOffset = new Vector2();
                        vecOffset += coorBlocks;
                        vecOffset.X += bx * blockDrawSize + blockDrawSize * blockObj.PosX;
                        vecOffset.Y += by * blockDrawSize + blockDrawSize * blockObj.PosY;
                        int color = blockObj.color;
                        blockYellow = this.Content.Load<Texture2D>(colorBlocks[color]);
                        spriteBatch.Draw(blockYellow, vecOffset, Color.White);
                    }

                for (int bx = 0; bx < MaxWidth; bx++)
                    for (int by = 0; by < MaxHeightX; by++)
                    {
                        if (_bMgr._Grid[bx, by] == 1)
                        {
                            blockYellow = this.Content.Load<Texture2D>(colorBlocks[1]);
                       //     spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);

                            spriteBatch.Draw(blockYellow, coorBlocks + (new Vector2(blockDrawSize * bx, blockDrawSize * by)), Color.White);
                        }

                        else if (_bMgr._Grid[bx, by] == 2)
                        {
                            blockYellow = this.Content.Load<Texture2D>(colorBlocks[2]);
                        //    spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);
                            spriteBatch.Draw(blockYellow, coorBlocks + (new Vector2(blockDrawSize * bx, blockDrawSize * by)), Color.White);
                        }

                        else if (_bMgr._Grid[bx, by] == 3)
                        {
                            blockYellow = this.Content.Load<Texture2D>(colorBlocks[3]);
                       //     spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);
                            spriteBatch.Draw(blockYellow, coorBlocks + (new Vector2(blockDrawSize * bx, blockDrawSize * by)), Color.White);
                        }

                        else if (_bMgr._Grid[bx, by] == 4)
                        {
                            blockYellow = this.Content.Load<Texture2D>(colorBlocks[4]);
                       //     spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
                        //    spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
                       //     spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);
                            spriteBatch.Draw(blockYellow, coorBlocks + (new Vector2(blockDrawSize * bx, blockDrawSize * by)), Color.White);
                        }
                        else if (_bMgr._Grid[bx, by] == 5)
                        {
                            blockYellow = this.Content.Load<Texture2D>(colorBlocks[5]);
                //            spriteBatch.DrawString(Font, "Time " + Min + " : " + time, (new Vector2(0, 0)), Color.White);
                 //           spriteBatch.DrawString(Font, "Lines Clear : " + _bMgr.linesClear, (new Vector2(170, 0)), Color.White);
                  //          spriteBatch.DrawString(Font, "Level : " + _bMgr.Level, (new Vector2(350, 0)), Color.White);
                            spriteBatch.Draw(blockYellow, coorBlocks + (new Vector2(blockDrawSize * bx, blockDrawSize * by)), Color.White);
                        }
                    }

                
            }
            else 
            {

                Texture2D rect = new Texture2D(graphics.GraphicsDevice, 5, 5);
                Vector2 coor = new Vector2(5*32, 5*32);
                //Vector2 coorBlocks = new Vector2(gridOffsetX, gridOffsetY - blockDrawSize * 4);

                Color[] data = new Color[(5 * 32) * (5 * 32)];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.Green;
                //rect.SetData(data);
                spriteBatch.Draw(rect, coor, Color.White);

                spriteBatch.DrawString(Font, "Game Over : ", (new Vector2(170, 80)), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
