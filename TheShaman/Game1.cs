using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoGame.Extended;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using System.Xml.Schema;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

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
        private Texture2D GameOver;
        private bool winState = false;
        private Texture2D StartGame;
        private SoundEffect sound;
        private Texture2D infoGame;
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
        public bool loseGameState = true;
        public bool startGameState = false;
        Animals[] animals;
        float sum = 0;
        bool infoState = false;

        private Texture2D background;

        List<Human> hum = new List<Human>();

        OrthographicCamera cam;

     
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 1200;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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
            StartGame = Content.Load<Texture2D>("StartGame1");
            player.manaBarTexture = Content.Load<Texture2D>("ManaBar1");

            sound = Content.Load<SoundEffect>("backgroundMusic");

  
            GameOver = Content.Load<Texture2D>("GameOver1");

            infoGame = Content.Load<Texture2D>("info");


            background = Content.Load<Texture2D>("background");





            cam = new OrthographicCamera(GraphicsDevice);
            
            string[] map = level.LoadLevel(selectLevel);

            levelMapper.StartMapping(ground, map ,human, animals, water, tree, Content);

            sound.Play();
            firePos = new Vector2(1500, 700);

            // ground =level.Map(Content);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

           


            if(startGameState == false)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {

                    infoState = true;

                }
            }
         
          
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    startGameState = true;
                    infoState= false;
                }
            

            if (loseGameState == false && startGameState == true && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {

                loseGameState = true;

                for(int i = 0; i < human.Length; i++)
                {
                    if (human[i] != null)
                    {
                    human[i].humanHealth = 20;
                    }
                    player.mana = 20;
                }

            }
            if (loseGameState == true)
            {


                timer -= gameTime.TotalGameTime.TotalSeconds;
                waitingTime += (float)gameTime.ElapsedGameTime.TotalSeconds;






                gamePhysics.playerBounderies(player, human, firePos);
                gamePhysics.humansBounderies(human, animals, gameTime);
                gamePhysics.treeColliders(player, human, animals, tree);
                gamePhysics.waterColliders(water,player, human, animals);



               


                    gamePhysics.PushAnimals(player, animals, gameTime);

                








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


            if (loseGameState)
            {
                if (startGameState == true)
                {
                    if (winState == false)
                    {





                        _spriteBatch.Begin(transformMatrix: cam.GetViewMatrix());


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



                        foreach (var trees in tree)
                        {
                            if (trees != null)
                            {
                                _spriteBatch.Draw(trees.treeTexture, new Vector2(trees.treePos.X - 50, trees.treePos.Y - 100), Color.White);

                            }
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
                                _spriteBatch.Draw(human.humanTexture, new Vector2(human.humanPos.X - 50, human.humanPos.Y - 100), human.damageColor);


                                if (Vector2.Distance(player.playerPos, human.humanPos) <= 50 && human.isFollowing == false && human.isArrived == false)
                                {

                                    _spriteBatch.DrawString(spriteFont, "Press 'Space' To Follow", new Vector2(player.playerPos.X + 50, player.playerPos.Y - 20), Color.White);
                                }
                                else
                                {
                                    _spriteBatch.DrawString(spriteFont, "", new Vector2(0, 0), Color.AntiqueWhite);
                                }

                                _spriteBatch.Draw(human.HealthBar, new Vector2(human.humanPos.X - 30, human.humanPos.Y - 100), Color.White);




                                if (human.humanHealth <= 0)
                                {
                                    loseGameState = false;
                                }


                            }




                        }

                        _spriteBatch.Draw(player.manaBarTexture, new Vector2(player.playerPos.X - 40, player.playerPos.Y - 110), Color.White);

                        _spriteBatch.End();
                    }
                    else
                    {
                        GraphicsDevice.Clear(Color.White);
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(background, new Rectangle(0, 0, 1200, 600), Color.White);
                        _spriteBatch.Draw(StartGame, new Rectangle(160, 10, 900, 600), Color.White);
                        _spriteBatch.DrawString(spriteFont, "Press 'Space' For Help !", new Vector2(900, 500), Color.White);
                        if (infoState == true)
                        {
                            _spriteBatch.Draw(infoGame, new Vector2(0, 0), Color.White);
                        }
                        _spriteBatch.End();
                    }
                }
                else
                {
                    GraphicsDevice.Clear(Color.White);
                    _spriteBatch.Begin();
                  _spriteBatch.Draw(background, new Rectangle(0,0, 1200, 600), Color.White);
                    _spriteBatch.Draw(StartGame, new Rectangle(160, 10, 900, 600), Color.White);
                    _spriteBatch.DrawString(spriteFont, "Press 'Space' For Help !", new Vector2(900,500), Color.White);
                    if(infoState == true)
                    {
                    _spriteBatch.Draw(infoGame, new Vector2(0,0), Color.White);
                    }

                    _spriteBatch.End();
                }
            }
            else
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Rectangle(0, 0, 1200, 600), Color.White);
                _spriteBatch.Draw(GameOver, new Rectangle(160, 10, 900, 600), Color.White);
                _spriteBatch.End();
            }



            _spriteBatch.Begin();

                foreach (Human huma in human)
                {
                    if (huma != null)
                    {
                        if (huma.isArrived == true && huma.isAdded == false)
                        {
                            hum.Add(huma);
                            huma.isAdded = true;
                        if (player.mana < 20)
                        {
                            player.mana += 2;
                        }

                       if(hum.Count >= 8)
                        {
                            winState = true;
                        }
                    }
                    }
                    if(startGameState== true)
                {
                    _spriteBatch.DrawString(spriteFont, $"number of followers : {hum.Count} / 8", new Vector2(800, 50), Color.White);

                }


            }


           


            _spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }

    
}