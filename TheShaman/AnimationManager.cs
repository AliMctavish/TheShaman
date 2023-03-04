using Microsoft.Xna.Framework;
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
        private FileManager _fileManager = new FileManager();
        public int counter = 0;
        public int state = 1;
        public void playerAnimation(Player player, ContentManager Content)
        {
            if(player.isIdle)
            {
                if (player.isFlipped == false)
                {
               player.PlayerAnimation(_fileManager.PlayerIdle, Content);
                }
                else
                {
                    player.PlayerAnimation(_fileManager.playerIdleFlip, Content);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && player.isHitting == false )
            {
                    player.isFlipped = false;
                if (player.isFlipped == false)
                {
                 player.PlayerAnimation(_fileManager.playerMoving , Content);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && player.isHitting == false)
            {
                player.isFlipped = true;
                player.PlayerAnimation(_fileManager.playerMovingFlip,Content);
            }
            if (player.isFlipped)
            {
                if (player.isHitting == true)
                {
                 player.PlayerAnimation(_fileManager.playerHtiFlip, Content); 
                }
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) &&  player.mana != 0 )
                {
                 player.PlayerAnimation(_fileManager.playerPushFlip, Content);
                    player.isPushing = true;
                }
                else
                {
                    player.isPushing = false;
                }
            }
            else
            {
                if (player.isHitting == true)
                {
                    player.PlayerAnimation(_fileManager.playerHit, Content);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.isHitting = true;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.LeftControl) && player.mana != 0 && !player.isFlipped)
            {
                player.PlayerAnimation(_fileManager.playerPush,Content);
                player.isPushing = true;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Up) &&  player.isHitting == false && player.isPushing == false)
            {
                player.isFlipped = false;
                if (player.isFlipped == false)
                {
                    player.PlayerAnimation(_fileManager.playerWalkingUp, Content);
                }
            } 
            if(Keyboard.GetState().IsKeyDown(Keys.Down) &&  player.isHitting == false && player.isPushing == false)
            {
                player.isFlipped = false;
                if (player.isFlipped == false)
                {
                 player.PlayerAnimation(_fileManager.playerWalkingDown,Content);
                }
            }
            for(int i = 9; player.mana / 2.4 <= i; i--)
            {
            player.manaBarTexture = Content.Load<Texture2D>($"ManaBar{i}");
            }
            for (int i = 9; player.health / 2.4 <= i; i--)
            {
            player.HealthBar = Content.Load<Texture2D>($"HealthBar{i}");
            }
        }
        public void AnimalAnimation(List<Animals> animals, ContentManager content)
        {
            foreach (Animals animal in animals)
            {
                if (!animal.isMoving && animal.isAttacking == false)
                {
                     animal.AnimateAnimal(_fileManager.animalFiles, content);
                }
                if(animal.isMoving)
                { 
                     animal.AnimateAnimal(_fileManager.animalWalkingFiles, content);
                }
                if (animal.isAttacking)
                {
                     animal.AnimateAnimal(_fileManager.animalAttackingFiles,content);
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
                    humans[i].AnimateHuman(_fileManager.humanIdle,content);
                    }
                    if(humans[i].GetType() == typeof(SecondaryHuman))
                    {
                    humans[i].AnimateHuman(_fileManager.secondaryHumanIdle,content);
                    }
                }
                else
                {
                    if (humans[i].humanPos.X <= player.playerPos.X)
                    {
                        if (humans[i].GetType()==typeof(Human))
                        {
                            humans[i].AnimateHuman(_fileManager.humanWalking,content);
                        }
                        if (humans[i].GetType() == typeof(SecondaryHuman))
                        {
                            humans[i].AnimateHuman(_fileManager.secondaryHumanWalking, content);
                        }
                    }
                    else
                    {
                        if (humans[i].GetType() == typeof(Human))
                        {
                            humans[i].AnimateHuman(_fileManager.humanWalkingFlip,content);
                        }

                        if (humans[i].GetType() == typeof(SecondaryHuman))
                        {
                            humans[i].AnimateHuman(_fileManager.secondaryHumanWalkingFlip,content);
                        }
                    }
                }
                for(int j = 9; humans[i].humanHealth/2.4 <= j; j--)
                {
                    humans[i].HealthBar = content.Load<Texture2D>($"HealthBar{j}");
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
