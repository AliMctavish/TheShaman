using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        float decreaseMana = 2;
        Random random= new Random();    
     

        public void playerBounderies(Player player , Human[] humans, Vector2 firePos)
        {
            for (int i = 0; i < humans.Length; i++)
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
                        humans[i].isArrived = true;
                    }

                    if (humans[i].isArrived == true)
                    {
                            Vector2 movDir = firePos - humans[i].humanPos;

                            movDir.Normalize();

                            humans[i].humanPos = humans[i].humanPos +  movDir ;

                        if (Vector2.Distance(humans[i].humanPos, firePos) <= 100)
                        {

                            movDir = firePos - humans[i].humanPos;

                            movDir.Normalize();

                            humans[i].humanPos -= movDir;
                        }


                    }


                    if(Vector2.Distance(player.playerPos , firePos) <= 50)
                    {
                        Vector2 movDir2 = firePos - player.playerPos;

                        movDir2.Normalize();

                        player.playerPos -= movDir2;
                    }
                    
                  






                   
                }
            }
        }
        public void humansBounderies(Human[] humans, Animals[] animals, GameTime gameTime)
        {
            decreaseHealth -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < humans.Length; i++)
            {
                if (humans[i] != null )
                {
                    for(int j = 0; j < animals.Length; j++)
                    {
                        if (animals[j] != null)
                        {
                            if (Vector2.Distance(humans[i].humanPos, animals[j].animalPos) <= 200 && !humans[i].isArrived)
                            {
                                Vector2 movDir = humans[i].humanPos - animals[j].animalPos;

                                movDir.Normalize();

                                animals[j].animalPos += movDir * 2;

                                if(decreaseHealth <= 1)
                                {
                                    humans[i].humanHealth -= 1;
                                    decreaseHealth = 2;
                                }
                                humans[i].isFollowing = false;

                            }
                        }
                    }
                }

            }
            //for (int i = 0; i < humans.Length; i++)
            //{
            //    if (humans[i] != null)
            //    {
            //        for (int j = 0; j < animals.Length; j++)
            //        {
            //            if (animals[j] != null)
            //            {
            //                if (Vector2.Distance(humans[i].humansPos, animals[j].animalPos) <= 50)
            //                {
            //                    Vector2 movDir = humans[i].humansPos - animals[j].animalPos;

            //                    movDir.Normalize();

            //                    humans[i].humansPos += movDir;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public void PushAnimals(Player player , Animals[] animals , GameTime gameTime)
        {
          decreaseMana -= (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
                for (int i = 0; i < animals.Length; i++)
                {


                if (animals[i] != null)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                    {
                        if (Vector2.Distance(player.playerPos, animals[i].animalPos) <= 200 && player.mana != 0)
                        {
                            Vector2 movDir = player.playerPos - animals[i].animalPos;

                            movDir.Normalize();

                            animals[i].animalPos -= movDir * 5;

                            animals[i].isMoving = true;
                        }




                        if (decreaseMana <= 1 && player.mana != 0)
                        {
                            player.mana -= 1;
                            decreaseMana = 2;
                        }
                    }
                    else
                    {
                        animals[i].isMoving = false;
                    }

                  }
                   
                }
        }
        public void treeColliders(Player player, Human[] humans, Animals[] animals, Tree[] trees)
        {
            foreach(var tree in trees)
            {
                if (tree != null)
                {
                    foreach (var human in humans)
                    {
                        if (human != null)
                        {

                            if (Vector2.Distance(human.humanPos, tree.treePos) <= 100)
                            {
                                Vector2 movDir = human.humanPos - tree.treePos;

                                movDir.Normalize();

                                human.humanPos += movDir;
                            }


                        }
                    }
                    foreach (var animal in animals)
                    {
                        if (animal != null)
                        {

                            if (Vector2.Distance(animal.animalPos, tree.treePos) <= 100)
                            {
                                Vector2 movDir = animal.animalPos - tree.treePos;

                                movDir.Normalize();

                                animal.animalPos += movDir;
                            }


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
        }
        public void waterColliders( Water[] waters , Player player, Human[] humans , Animals[] animals)
        {
          foreach(var water in waters)
          {
            if(water != null)
                {
                    foreach (var animal in animals)
                    {
                        if (animal != null)
                        {
                            if (Vector2.Distance(animal.animalPos, water.waterPos) <= 50)
                            {

                                Vector2 movDir = animal.animalPos - water.waterPos;

                                movDir.Normalize();

                                animal.animalPos += movDir * 10;


                            }
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
}
