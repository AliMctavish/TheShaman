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
        public  int current = 0;
        public void playerAnimation(Player player, ContentManager Content)
        {
            if(player.isIdle && !Keyboard.GetState().IsKeyDown(Keys.Right) && !Keyboard.GetState().IsKeyDown(Keys.Left) && player.isHitting == false && !Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.Down))
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
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && player.isHitting == false &&
                !Keyboard.GetState().IsKeyDown(Keys.Down) &&
                !Keyboard.GetState().IsKeyDown(Keys.Up) &&
                !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                    player.PlayerAnimation(_fileManager.playerMoving, Content);
                    player.isFlipped = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && player.isHitting == false &&
                !Keyboard.GetState().IsKeyDown(Keys.Down) &&
                !Keyboard.GetState().IsKeyDown(Keys.Up) && 
                !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                player.PlayerAnimation(_fileManager.playerMovingFlip,Content);
                player.isFlipped = true;
            }
            if (player.isFlipped)
            {
                if (player.isHitting == true)
                {
                    player.playerTexture = Content.Load<Texture2D>($"{_fileManager.playerHitFlip[current]}");
                    current += 1;
                    if (current == _fileManager.playerHitFlip.Count)
                    {
                        player.isHitting = false;
                        current = 0;
                    }
                }
            }
            else
            {
                if (player.isHitting == true)
                {
                  player.playerTexture = Content.Load<Texture2D>($"{_fileManager.playerHit[current]}");
                  current += 1;
                    if (current == _fileManager.playerHit.Count)
                    {
                        player.isHitting = false;
                        current = 0;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && player.mana != 0 && !player.isFlipped)
            {
                if (current < _fileManager.playerPush.Count)
                {
                    player.isIdle = false;
                    player.playerTexture = Content.Load<Texture2D>($"{_fileManager.playerPush[current]}");
                    current += 1;
                }
                else
                {
                    current = 5;
                }
            }
            else
            {
                player.isIdle = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && player.mana != 0 && player.isFlipped)
            {
                if (current < _fileManager.playerPushFlip.Count)
                {
                    player.isIdle = false;
                    player.playerTexture = Content.Load<Texture2D>($"{_fileManager.playerPushFlip[current]}");
                    current += 1;
                }
                else
                {
                    current = 5;
                }
            }
            else
            {
                player.isIdle = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.isHitting = true;
            }
        
            if(Keyboard.GetState().IsKeyDown(Keys.Up) &&  player.isHitting == false && player.isPushing == false && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                player.isFlipped = false;
                player.PlayerAnimation(_fileManager.playerWalkingUp, Content);
            } 
            if(Keyboard.GetState().IsKeyDown(Keys.Down) && player.isHitting == false && player.isPushing == false && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
              player.isFlipped = false;  
              player.PlayerAnimation(_fileManager.playerWalkingDown,Content);
            }
            for(int i = 9; player.mana / 2.4 < i; i--)
            {
                player.manaBarTexture = Content.Load<Texture2D>($"ManaBar{i}");
            }
            for (int i = 9; player.health / 2.4 < i; i--)
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
