﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class AnimationManager
    {
        public int counter = 0;
        public int state = 1;
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
                 player.PlayerMovingAnimation("PlayerAnimation/playerMoving", 4, Content);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && player.isHitting == false)
            {
                player.isFlipped = true;
                player.PlayerMovingAnimation("PlayerFlipAnimation/playerMoving", 4, Content);
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
                 player.PlayerIsHittingFlipAnimation("PlayerFlipAnimation/playerHitFilp", 11, Content); 
                }
                if (player.isPushing == true && player.mana != 0 )
                {
                 player.PlayerIsPushingFlipAnimation("PlayerFlipAnimation/playerPushFlip" , 7 , Content);
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
                if (player.isPushing == true && player.mana != 0 && !player.isFlipped)
                {
                    player.PlayerIsPushingAnimation("PlayerAnimation/playerPush", 7, Content);
                   
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
                 player.PlayerWalkingDownAnimation("PlayerAnimation/playerWalkingDown", 3, Content);
                }
            }

            //sorry for the recurrtion :p

            if(player.mana == 20)
            {
            player.manaBarTexture = Content.Load<Texture2D>("ManaBar1");
            }
            if (player.mana <= 18)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar1");
            }
            if (player.mana <= 16)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar2");
            }
            if (player.mana <= 14)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar3");
            }
            if (player.mana <= 12)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar4");
            }
            if (player.mana <= 8)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar5");
            }
            if (player.mana <= 7)
            {
                player.manaBarTexture = Content.Load<Texture2D>("ManaBar6");
            }
            if (player.mana <= 5)
            {
                player.manaBarTexture = Content.Load<Texture2D>($"ManaBar7");
            }
            if (player.mana <= 3)
            {
                player.manaBarTexture = Content.Load<Texture2D>($"ManaBar8");
            }
            if (player.mana <= 1)
            {
                player.manaBarTexture = Content.Load<Texture2D>($"ManaBar9");
            }

            if(player.health == 20)
            {
                player.HealthBar= Content.Load<Texture2D>("HealthBar1");
            }
            if(player.health <= 18)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar2");
            }
            if(player.health <= 16)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar3");
            }  
            if(player.health <= 14)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar4");
            } 
            if(player.health <= 12)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar5");
            } 
            if(player.health <= 8)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar6");
            }  
            if(player.health <= 7)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar7");
            }  
            if(player.health <= 5)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar8");
            }
            if (player.health <= 3)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar8");
            }
            if(player.health <= 1)
            {
                player.HealthBar = Content.Load<Texture2D>("HealthBar9");
            }
        }
        public void AnimalAnimation(List<Animals> animals, ContentManager content)
        {
            foreach (Animals animal in animals)
            {
                if (!animal.isMoving )
                {
                     animal.AnimateAnimal("AnimalAnimation/animal", 4 , content);   
                }
                if(animal.isMoving)
                { 
                    animal.AnimateAnimal("AnimalAnimation/AnimalWalking", 4  , content);
                }
                if (animal.isAttacking)
                {
                    animal.AnimateAnimal("AnimalAnimation/AnimalAttacking", 4 , content);
                }
            }
        }
        public void HumanAnimation(List<Human> humans, ContentManager content, Player player,Vector2 firePos)
        {
            for (int i = 0; i < humans.Count; i++)
            {
                if (humans[i].isFollowing == false)
                {

                    if (humans[i].GetType() == typeof(Human))
                    {
                    humans[i].AnimateHuman("HumansAnimation/HumanSecondary",5,content);
                    }
                    if(humans[i].GetType() == typeof(SecondaryHuman))
                    {
                    humans[i].AnimateHuman("HumansAnimation/HumanIdle",10,content);
                    }
                }
                else
                {
                    if (humans[i].humanPos.X <= player.playerPos.X)
                    {
                        if (humans[i].GetType()==typeof(Human))
                        {
                            humans[i].AnimateMovingHuman("HumansAnimation/HumanSecondaryWalking",4,content);
                        }
                        if (humans[i].GetType() == typeof(SecondaryHuman))
                        {
                            humans[i].AnimateMovingHuman("HumansAnimation/HumanWalking", 4, content);
                        }
                    }
                    else
                    {
                        if (humans[i].GetType() == typeof(Human))
                        {
                            humans[i].AnimateMovingHuman("HumansAnimation/HumanSecondaryWalkingFlip", 4, content);
                        }

                        if (humans[i].GetType() == typeof(SecondaryHuman))
                        {
                            humans[i].AnimateMovingHuman("HumansAnimation/HumanWalkingFlip", 4, content);
                        }
                    }
                }
                //sorry again dont have time to fix it xD
                if (humans[i].humanHealth <= 18)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar1");
                }
                if (humans[i].humanHealth <= 16)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar2");
                }
                if (humans[i].humanHealth <= 14)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar3");
                }
                if (humans[i].humanHealth <= 12)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar4");
                }
                if (humans[i].humanHealth <= 8)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar5");
                }
                if (humans[i].humanHealth <= 7)
                {
                    humans[i].HealthBar = content.Load<Texture2D>("HealthBar6");
                }
                if (humans[i].humanHealth <= 5)
                {
                    humans[i].HealthBar = content.Load<Texture2D>($"HealthBar7");
                }
                if (humans[i].humanHealth <= 3)
                {
                    humans[i].HealthBar = content.Load<Texture2D>($"HealthBar8");
                }
                if (humans[i].humanHealth <= 1)
                {
                    humans[i].HealthBar = content.Load<Texture2D>($"HealthBar9");
                }
            }
        }
        public void waterAnimation(List<Water> waters, ContentManager content)
        {
            foreach (var water in waters)
            {
                water.waterTexture = content.Load<Texture2D>($"waterMove{water.animationCounter}");
                water.animationCounter += 1;

                if (water.animationCounter == 10)
                {
                    water.waterTexture = content.Load<Texture2D>($"waterMove10");
                    water.animationCounter = 1;
                }
            }
        }
    }
}
