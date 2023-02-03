using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class AnimationManager
    {
        public void playerAnimation(Player player, ContentManager Content)
        {

            if (player.isFlipped == false)
            {
                player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerIdle{player.playerAnimationCounter}");
            }
            else
            {
                player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerIdle{player.playerAnimationCounter}");
            }
        
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && player.isHitting == false )
            {
                    player.isFlipped = false;
                if (player.isFlipped == false)
                {
                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerMoving{player.playerAnimationMovingCounter}");
                    player.playerAnimationMovingCounter += 1;
                    if (player.playerAnimationMovingCounter == 4)
                    {
                        player.playerAnimationMovingCounter = 1;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && player.isHitting == false)
            {
                player.isFlipped = true;
                    player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerMoving{player.playerAnimationMovingCounter}");

                    player.playerAnimationMovingCounter += 1;
                    if (player.playerAnimationMovingCounter == 4)
                    {
                        player.playerAnimationMovingCounter = 1;
                    }
            }
            player.playerAnimationCounter += 1;
            if (player.playerAnimationCounter == 6)
            {
                player.playerAnimationCounter = 1;
            }
            if (player.isFlipped)
            {
                if (player.isHitting == true)
                {
                    player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerHitFilp{player.playerAnimationHitCounter}");

                    player.playerAnimationHitCounter += 1;
                    if (player.playerAnimationHitCounter == 11)
                    {
                        player.playerAnimationHitCounter = 1;
                        player.isHitting = false;
                    }

                }

                if (player.isPushing == true && player.mana != 0)
                {

                    player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerPushFlip{player.playerPushingAnimationCounter}");

                    player.playerPushingAnimationCounter += 1;
                    if (player.playerPushingAnimationCounter == 7)
                    {
                        player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerPushFlip7");
                        player.playerPushingAnimationCounter = 1;
                        player.isPushing = false;
                    }



                }

            }
            else
            {
                if (player.isHitting == true)
                {
                    

                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerHit{player.playerAnimationHitCounter}");

                    player.playerAnimationHitCounter += 1;
                    if (player.playerAnimationHitCounter == 11)
                    {

                        player.playerAnimationHitCounter = 1;
                        player.isHitting = false;
                    }

                }

                if (player.isPushing == true && player.mana != 0)
                {

                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerPush{player.playerPushingAnimationCounter}");

                    player.playerPushingAnimationCounter += 1;
                    if (player.playerPushingAnimationCounter == 7)
                    {
                        player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerPush7");
                        player.playerPushingAnimationCounter = 1;
                        player.isPushing = false;
                    }



                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.isHitting = true;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                player.isPushing = true;
            }


            if(Keyboard.GetState().IsKeyDown(Keys.Up) &&  player.isHitting == false && player.isPushing == false)
            {

                player.isFlipped = false;
                if (player.isFlipped == false)
                {
                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerWalkingUp{player.playerAnimationMovingUpCounter}");
                    player.playerAnimationMovingUpCounter += 1;
                    if (player.playerAnimationMovingUpCounter == 7)
                    {
                        player.playerAnimationMovingUpCounter = 1;
                    }
                }
            } 
            
            if(Keyboard.GetState().IsKeyDown(Keys.Down) &&  player.isHitting == false && player.isPushing == false)
            {

                player.isFlipped = false;
                if (player.isFlipped == false)
                {
                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerWalkingDown{player.playerAnimationMovingDownCounter}");
                    player.playerAnimationMovingDownCounter += 1;
                    if (player.playerAnimationMovingDownCounter == 3)
                    {
                        player.playerAnimationMovingDownCounter = 1;
                    }
                }
            }
        }



        public void AnimalAnimation(Animals[] animals,Human[] humans , ContentManager content)
        {

            foreach(Animals animal in animals)
            {
                if (animal != null)
                {
                    animal.animalTexture = content.Load<Texture2D>($"AnimalAnimation/animal{animal.AnimalIdleCounter}");

                    animal.AnimalIdleCounter += 1;
                    if (animal.AnimalIdleCounter == 5)
                    {
                        animal.animalTexture = content.Load<Texture2D>($"AnimalAnimation/animal5");

                    }
                }

                    
            }
               
            

          
        }


        public void HumanAnimation(Human[] humans, ContentManager content, Player player,Vector2 firePos)
        {
            for (int i = 0; i < humans.Length; i++)
            {
                if (humans[i] != null)
                {
                    if (humans[i].isFollowing == false)
                    {
                        humans[i].humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondary{humans[i].humanIdleAnimationCounter}");

                        humans[i].humanIdleAnimationCounter += 1;

                        if (humans[i].humanIdleAnimationCounter == 5)
                        {
                            humans[i].humanTexture = content.Load<Texture2D>("HumansAnimation/HumanSecondary5");

                            humans[i].humanIdleAnimationCounter = 1;

                        }

                    }
                    else
                    {
                        if (humans[i].humanPos.X <= player.playerPos.X)
                        {
                            humans[i].humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondaryWalking{humans[i].humanWalkingAnimationCounter}");
                            humans[i].humanWalkingAnimationCounter += 1;

                            if (humans[i].humanWalkingAnimationCounter == 4)
                            {
                                humans[i].humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondaryWalking1");
                                humans[i].humanWalkingAnimationCounter = 1;
                            }
                        }
                        else
                        {
                            humans[i].humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondaryWalkingFlip{humans[i].humanWalkingAnimationCounter}");
                            humans[i].humanWalkingAnimationCounter += 1;

                            if (humans[i].humanWalkingAnimationCounter == 4)
                            {
                                humans[i].humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondaryWalkingFlip1");
                                humans[i].humanWalkingAnimationCounter = 1;
                            }
                        }

                    }   
                    
                }
            }


        }

        public void waterAnimation(Water[] water , ContentManager content)
        {

            foreach(var waters in water)
            {
                if (waters != null)
                {

                waters.waterTexture = content.Load<Texture2D>($"waterMove{waters.animationCounter}");
                    waters.animationCounter += 1; 

                if(waters.animationCounter == 10)
                {
                    waters.waterTexture = content.Load<Texture2D>($"waterMove10");
                    waters.animationCounter = 1;
                }
                }
            }



        }

        


    }
}
