using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class GamePhysics
    {
        float decreaseHealth = 2;
        float playerDecreaseHealth = 2;
        float decreaseMana = 2;
        Random random= new Random();    
     

        public void playerBounderies(Player player , List<Human> humans, List<Animals> animals , Vector2 firePos, GameTime gameTime)
        {

            for (int i = 0; i < humans.Count; i++)
            {
                if (humans[i] != null)
                {
                    if (Vector2.Distance(player.playerPos, humans[i].humanPos) < 100 && Keyboard.GetState().IsKeyDown(Keys.Space) )
                    {
                        humans[i].isFollowing = true;
                    }
                    if (humans[i].isFollowing == true)
                    {
                        Vector2 movDir = player.playerPos - humans[i].humanPos;
                        movDir.Normalize();
                        humans[i].humanPos += movDir  ;
                        if(Vector2.Distance(player.playerPos , humans[i].humanPos) < 100)
                        {
                            movDir = player.playerPos - humans[i].humanPos;
                            movDir.Normalize();
                            humans[i].humanPos -= movDir;
                        }
                    }
                    if (Vector2.Distance(player.playerPos, firePos) < 100 && Keyboard.GetState().IsKeyDown(Keys.Space) && humans[i].isFollowing )
                    {
                        humans[i].isFollowing = false;
                        humans[i].isArriving = true;
                    }
                    if (humans[i].isArriving == true)
                    {
                        Vector2 movDir = firePos - humans[i].humanPos;
                        movDir.Normalize();
                        humans[i].humanPos = humans[i].humanPos +  movDir ;
                        if (Vector2.Distance(humans[i].humanPos, firePos) <= 100)
                        {
                            movDir = firePos - humans[i].humanPos;
                            movDir.Normalize();
                            humans[i].humanPos -= movDir;
                            humans[i].isArrived = true;
                        }
                    }
                    if(Vector2.Distance(player.playerPos , firePos) <= 50)
                    {
                        Vector2 movDir2 = firePos - player.playerPos;
                        movDir2.Normalize();
                        player.playerPos -= movDir2;
                    }

                    foreach(Animals animal in animals)
                    {
                    if(Vector2.Distance(player.playerPos , animal.animalPos) <= 200)
                    {
                        Vector2 movDir = player.playerPos - animal.animalPos;
                        movDir.Normalize();
                        animal.animalPos += movDir;
                            animal.isMoving = true;
                            if (Vector2.Distance(player.playerPos ,  animal.animalPos) <= 70)
                            {
                                playerDecreaseHealth -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                                movDir = player.playerPos - animal.animalPos;
                                movDir.Normalize();
                                animal.animalPos -= movDir;
                                if (playerDecreaseHealth <= 1)
                                {
                                    player.health -= 1;
                                    playerDecreaseHealth = 1.4f;
                                    player.playerColor = Color.Red;
                                    animal.isAttacking = true;
                                }
                                else
                                {
                                    player.playerColor = Color.White;
                                }
                            }
                            else
                            {
                                animal.isAttacking = false;
                            }
                        }
                        else
                        {
                            animal.isMoving = false;
                        }
                    }
                }
            }
        }

        public void takeHony(Player player, List<Items> items) 
        {
        
            foreach(hony item in items.ToList())
            {
                if(item.GetType() == typeof(hony))
                {
                if(Vector2.Distance(player.playerPos, item.ItemPos) <= 50)
                {
                    items.Remove(item);
                }
                }
            }
        
        }
        public void humansBounderies(List<Human> humans, List<Animals> animals, GameTime gameTime)
        {
            decreaseHealth -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            for (int i = 0; i < humans.Count; i++)
            {
               for(int j = 0; j < animals.Count; j++)
               {
                   if (Vector2.Distance(humans[i].humanPos, animals[j].animalPos)<=200&&!humans[i].isArrived)
                   {
                       Vector2 movDir = humans[i].humanPos - animals[j].animalPos;
                       movDir.Normalize();
                       animals[j].animalPos += movDir * 2;
                        if(Vector2.Distance(humans[i].humanPos, animals[j].animalPos) <= 50)
                        {
                            if (decreaseHealth <= 1)
                            {
                                humans[i].humanHealth -= 1;
                                decreaseHealth = 1.4f;
                                animals[j].isAttacking = true;
                                humans[i].damageColor = Color.Red;
                            }
                            else
                            {
                                humans[i].damageColor = Color.White;
                            }
                        }
                        humans[i].isFollowing = false;
                   }
               }
            }
        }
        public void enchantAnimals(Player player , List<Animals> animals , GameTime gameTime)
        {
            foreach(var animal in animals)
            {
                if (Vector2.Distance(player.playerPos, animal.animalPos) <= 50)
                {
                    Vector2 movDir = player.playerPos - animal.animalPos;
                    movDir.Normalize();
                    animal.animalPos -= movDir * 2;
                    animal.animalColor = Color.Green;
                }
            }
        }
        public void PushAnimals(Player player, List<Animals> animals, GameTime gameTime)
        {
            decreaseMana -= (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            for (int i = 0; i < animals.Count; i++)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {
                    if (Vector2.Distance(player.playerPos, animals[i].animalPos) <= 200 && player.mana != 0)
                    {
                        Vector2 movDir = player.playerPos - animals[i].animalPos;
                        movDir.Normalize();
                        animals[i].animalPos -= movDir * 10;
                        animals[i].isMoving = true;
                        animals[i].isAttacking = false;
                    }
                    if (decreaseMana <= 1 && player.mana != 0)
                    {
                        player.mana -= 1;
                        decreaseMana = 2;
                    }
                }
            }
        }
        public void treeColliders(Player player, List<Human> humans, List<Animals> animals, List<Tree> trees)
        {
            foreach(var tree in trees)
            {
                foreach (var human in humans)
                {
                    if (Vector2.Distance(human.humanPos, tree.treePos) <= 100)
                    {
                        Vector2 movDir = human.humanPos - tree.treePos;
                        movDir.Normalize();
                        human.humanPos += movDir;
                    }
                }
                foreach (var animal in animals)
                {
                    if (Vector2.Distance(animal.animalPos, tree.treePos) <= 100)
                    {
                        Vector2 movDir = animal.animalPos - tree.treePos;
                        movDir.Normalize();
                        animal.animalPos += movDir;
                    }
                }
                if (Vector2.Distance(player.playerPos, tree.treePos) <= 100)
                {
                    Vector2 movDir = player.playerPos - tree.treePos;
                    movDir.Normalize();
                    player.playerPos += movDir;
                }
            }
        }
        public void waterColliders( List<Water> waters , Player player, List<Human> humans , List<Animals> animals)
        {
            foreach (var water in waters)
            {
                foreach (var animal in animals)
                {
                    if (Vector2.Distance(animal.animalPos, water.waterPos) <= 50)
                    {
                        Vector2 movDir = animal.animalPos - water.waterPos;
                        movDir.Normalize();
                        animal.animalPos += movDir * 10;
                    }
                }
                if (Vector2.Distance(player.playerPos, water.waterPos) <= 50)
                {
                    Vector2 movDir = player.playerPos - water.waterPos;
                    movDir.Normalize();
                    player.playerPos += movDir * 2;
                }
            }  
        }
    }
}
