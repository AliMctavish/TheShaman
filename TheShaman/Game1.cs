using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoGame.Extended;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace TheShaman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Maps level = new Maps();
        private Player player;
        private Vector2 firePos;
        private Texture2D fireTexture;
        private float time;
        int fireAnimate = 1;
        float animateCounter = 0.1f;
        float waitingTime = 0;
        private int selectLevel = 1;
        LevelEditor levelMapper = new LevelEditor();
        Ground[] ground;
        Enemy[] enemy; 
        int xAxis = 0;
        int yAxis = 0;
        double timer = 20;
        private bool startFollow = false;
        AnimationManager animationManager;
        GamePhysics gamePhysics;

        float sum = 0;

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
            int sumOfArrays = -1;
            foreach (var cell in level.LoadLevel(selectLevel))
            {
                sumOfArrays += cell.Length;
            }

           animationManager = new AnimationManager();
            gamePhysics = new GamePhysics();
            ground = new Ground[sumOfArrays];
            enemy = new Enemy[sumOfArrays];


            player = new Player();
            


            Debug.Write(enemy);





            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.playerTexture = Content.Load<Texture2D>("PlayerAnimation/playerIdle1");

            fireTexture = Content.Load<Texture2D>("fireAnimation1");



            cam = new OrthographicCamera(GraphicsDevice);

            string[] map = level.LoadLevel(selectLevel);

            levelMapper.StartMapping(ground, map ,enemy, Content);


            firePos = new Vector2(500, 500);

            // ground =level.Map(Content);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

           
            timer -= gameTime.TotalGameTime.TotalSeconds;
            waitingTime += (float)gameTime.ElapsedGameTime.TotalSeconds;







            gamePhysics.playerBounderies(player , enemy , firePos);


           


        
            if(waitingTime > animateCounter)
            {
                animationManager.playerAnimation(player, Content);

                fireTexture = Content.Load<Texture2D>($"fireAnimation{fireAnimate}");
                if(fireAnimate == 3)
                {
                    fireTexture = Content.Load<Texture2D>($"fireAnimation3");
                    fireAnimate = 1;
                }
                fireAnimate += 1;
            animateCounter += 0.1f;
            }






            float time = (float)gameTime.TotalGameTime.TotalSeconds;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                player.playerPos.Y -= 2;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player.playerPos.Y += 2;
              
            }  
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.playerPos.X += 2;
               
            } 
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
               player.playerPos.X -= 2;
              
            }
            cam.LookAt(player.playerPos);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin(transformMatrix : cam.GetViewMatrix());

            foreach (var ground in ground)
            {
                if (ground != null)
                {

                    _spriteBatch.Draw(ground.groundTexture, new Vector2(ground.groundPos.X - 50, ground.groundPos.Y - 50), Color.White);
                }

            }
            _spriteBatch.Draw(fireTexture, firePos, Color.White);




            foreach (var enemy in enemy)
            {
                if(enemy != null)
                {
                _spriteBatch.Draw(enemy.enemyTexture, new Vector2(enemy.enemyPos.X - 50, enemy.enemyPos.Y - 50), Color.White); _spriteBatch.Draw(enemy.enemyTexture, new Vector2(enemy.enemyPos.X - 50, enemy.enemyPos.Y - 50), Color.White);
                }

            }

         

            
            _spriteBatch.Draw(player.playerTexture, new Vector2(player.playerPos.X - 50 , player.playerPos.Y - 50 ), Color.White);
           








            _spriteBatch.End();




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}