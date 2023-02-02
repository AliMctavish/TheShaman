using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoGame.Extended;

namespace TheShaman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private LevelEditor level;
        private Player player;
        private float time;
        Ground[,] tileMap = new Ground[40, 40];
        Ground ground;
        Enemy[,] enemy = new Enemy[40,40]; 
        int xAxis = 0;
        int yAxis = 0;
        double timer = 20;

        OrthographicCamera cam;
     
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 1200;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            level= new LevelEditor();
            ground = new Ground();
            player = new Player();
            


            Debug.Write(enemy);





            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.playerTexture = Content.Load<Texture2D>("playerTexture");

            enemy[5, 2] = new Enemy();

            enemy[5, 2].enemyTexture = Content.Load<Texture2D>("enemy");

            int xLength = tileMap.GetLength(0);
            int yLength = tileMap.GetLength(1);

            cam = new OrthographicCamera(GraphicsDevice);



            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    tileMap[i, j] = new Ground();

                    if (j < 10)
                    {

                        tileMap[i, j].groundTexture = Content.Load<Texture2D>("ground");
                        
                    }
                    else
                    {
                        tileMap[i, j].groundTexture = Content.Load<Texture2D>("groundDryTexture");

                    }
                 
                 

                    


                }

            }


            enemy[5, 2].enemyPos = new Vector2(100, 100);

            // ground =level.Map(Content);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //enemy[5, 2].enemyPos.X = 50 - xAxis * 2;
            //enemy[5, 2].enemyPos.Y = 50 - xAxis * 2;
           
            timer -= gameTime.TotalGameTime.TotalSeconds;

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    tileMap[i, j].groundPos = new Rectangle(50 * i , 50 * j , 50, 50);
                }
            }


        

            Vector2 movDir = player.playerPos - enemy[5, 2].enemyPos ;

            movDir.Normalize();

            enemy[5, 2].enemyPos += movDir;
           

          
               
            
                Debug.WriteLine(timer);

            float time = (float)gameTime.TotalGameTime.TotalSeconds;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                player.playerPos.Y -= 1  * time;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player.playerPos.Y += 1 * time;
              
            }  
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.playerPos.X += 1 * time;
               
            } 
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
               player.playerPos.X -= 1 * time;
              
            }
            cam.LookAt(player.playerPos);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin(transformMatrix : cam.GetViewMatrix());



            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40 ; j++)
                {

                    _spriteBatch.Draw(tileMap[i, j].groundTexture, tileMap[i, j].groundPos, Color.White);
                 

                }

            }


            _spriteBatch.Draw(enemy[5, 2].enemyTexture, new Vector2(enemy[5,2].enemyPos.X - 50,enemy[5,2].enemyPos.Y - 50), Color.White);


            _spriteBatch.Draw(player.playerTexture, new Vector2(player.playerPos.X - 50 , player.playerPos.Y - 50 ), Color.White);




            _spriteBatch.End();




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}