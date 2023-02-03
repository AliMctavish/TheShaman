using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoGame.Extended;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace TheShaman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Maps level = new Maps();
        private Player player;
        private Water[] water;
        private Vector2 firePos;
        private Texture2D fireTexture;
      
        private float time;
        int fireAnimate = 1;
        float animateCounter = 0.1f;
        float waitingTime = 0;
        private int selectLevel = 1;
        LevelEditor levelMapper = new LevelEditor();
        Ground[] ground;
        Human[] human;
        Tree[] tree;
        int xAxis = 0;
        int yAxis = 0;
        double timer = 20;
        private bool startFollow = false;
        SpriteFont spriteFont;
        AnimationManager animationManager;
            bool zrba = false;
        GamePhysics gamePhysics;
        public bool gameState = true;

        Animals[] animals;
        float sum = 0;

        List<Human> hum = new List<Human>();

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
            human = new Human[sumOfArrays];
            animals = new Animals[sumOfArrays];
            water = new Water[sumOfArrays];
            tree = new Tree[sumOfArrays];


            player = new Player();
            







            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.playerTexture = Content.Load<Texture2D>("PlayerAnimation/playerIdle1");

            fireTexture = Content.Load<Texture2D>("fireAnimation1");

            spriteFont = Content.Load<SpriteFont>("File");



            cam = new OrthographicCamera(GraphicsDevice);

            string[] map = level.LoadLevel(selectLevel);

            levelMapper.StartMapping(ground, map ,human, animals, water, tree, Content);


            firePos = new Vector2(500, 500);

            // ground =level.Map(Content);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameState == false && Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                gameState = true;

                for(int i = 0; i < human.Length; i++)
                {
                    if (human[i] != null)
                    {
                    human[i].humanHealth = 20;
                    }
                    player.mana = 20;
                }

            }
            if (gameState == true)
            {


                timer -= gameTime.TotalGameTime.TotalSeconds;
                waitingTime += (float)gameTime.ElapsedGameTime.TotalSeconds;






                gamePhysics.playerBounderies(player, human, firePos);
                gamePhysics.humansBounderies(human, animals, gameTime);
                gamePhysics.treeColliders(player, human, animals, tree);
                gamePhysics.waterColliders(water,player, human, animals);



                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {

                    gamePhysics.PushAnimals(player, animals, gameTime);
                

                }







                if (waitingTime > animateCounter)
                {
                    animationManager.playerAnimation(player, Content);
                    animationManager.HumanAnimation(human, Content, player, firePos);
                    animationManager.waterAnimation(water, Content);
                    animationManager.AnimalAnimation(animals,human, Content);

                    fireTexture = Content.Load<Texture2D>($"fireAnimation{fireAnimate}");
                    if (fireAnimate == 3)
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

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    player.playerPos.Y -= 2;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    player.playerPos.Y += 2;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    player.playerPos.X += 2;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    player.playerPos.X -= 2;

                }
                cam.LookAt(player.playerPos);

                // TODO: Add your update logic here
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


           
            _spriteBatch.Begin(transformMatrix : cam.GetViewMatrix());

            foreach (var water in water)
            {
                if (water != null)
                {
                    _spriteBatch.Draw(water.waterTexture, new Vector2(water.waterPos.X - 50, water.waterPos.Y - 50), Color.White);
                }
            }


            foreach (var ground in ground)
            {
                if (ground != null)
                {

                    _spriteBatch.Draw(ground.groundTexture, new Vector2(ground.groundPos.X - 50, ground.groundPos.Y - 50), Color.White);
                }

            }

           




            if(gameState == false)
            {
                _spriteBatch.Draw(player.playerTexture, new Rectangle(0, 0, 400, 400), Color.Black);
            }


            _spriteBatch.Draw(player.playerTexture, new Vector2(player.playerPos.X - 50, player.playerPos.Y - 100), Color.White);




            foreach (var animal in animals)
            {
                if (animal != null)
                {
                    _spriteBatch.Draw(animal.animalTexture, new Vector2(animal.animalPos.X - 50, animal.animalPos.Y - 50), Color.White); 
              
                }
            }
            _spriteBatch.Draw(fireTexture, new Vector2(firePos.X - 50, firePos.Y - 100), Color.White);


            foreach (var trees in tree)
            {
                if (trees != null)
                {
                    _spriteBatch.Draw(trees.treeTexture, new Vector2(trees.treePos.X - 50, trees.treePos.Y - 100), Color.White);

                }
            }

            foreach (var human in human)
            {
                if (human != null)
                {
                    if (Vector2.Distance(player.playerPos, firePos) <= 100 && human.isFollowing == true && human.isArrived == false)
                    {
                        _spriteBatch.DrawString(spriteFont, "Press 'Space' To Deliver", new Vector2(player.playerPos.X + 50, player.playerPos.Y - 20), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(spriteFont, "", new Vector2(0, 0), Color.White);
                    }
                    _spriteBatch.Draw(human.humanTexture, new Vector2(human.humanPos.X - 50, human.humanPos.Y - 100), Color.White);


                    if (Vector2.Distance(player.playerPos, human.humanPos) <= 50 && human.isFollowing == false && human.isArrived == false)
                    {

                        _spriteBatch.DrawString(spriteFont, "Press 'Space' To Follow", new Vector2(player.playerPos.X + 50, player.playerPos.Y - 20), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(spriteFont, "", new Vector2(0, 0), Color.AntiqueWhite);
                    }

                    _spriteBatch.DrawString(spriteFont, $"humanHealth :{human.humanHealth}", new Vector2(human.humanPos.X - 30, human.humanPos.Y + 80), Color.White);




                    if (human.humanHealth <= 0)
                    {
                        gameState = false;
                    }


                }



            }
            _spriteBatch.End();



            _spriteBatch.Begin();

            foreach(Human huma in human)
            {
               if(huma != null)
                {
                    if (huma.isArrived == true && huma.isAdded == false)
                    {
                        hum.Add(huma);
                        huma.isAdded = true;
                    }
                }
             
            _spriteBatch.DrawString(spriteFont, $"number of followers : {hum.Count} / 15", new Vector2(1000, 50), Color.White);
            

              _spriteBatch.DrawString(spriteFont, $"Player Mana : {player.mana} / 20", new Vector2(1000, 100), Color.White);
            }





            _spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }

    
}