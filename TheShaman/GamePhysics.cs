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

                    if (Vector2.Distance(player.playerPos, firePos) < 100 && Keyboard.GetState().IsKeyDown(Keys.Space) && humans[i].isFollowing)
                    {
                        humans[i].isFollowing = false;
                        humans[i].isArrived = true;
                    }

                    if (humans[i].isArrived == true)
                    {

                      
                            Vector2 movDir = firePos  - humans[i].humanPos;

                            movDir.Normalize();

                            humans[i].humanPos += movDir;


                        if (Vector2.Distance(humans[i].humanPos, firePos) <= 50)
                        {

                            movDir = firePos - humans[i].humanPos;

                            movDir.Normalize();

                            humans[i].humanPos -= movDir;
                        }


                    }



                   
                }
            }
        }

        public void humansBounderies(Human[] humans, Animals[] animals)
        {

            for (int i = 0; i < humans.Length; i++)
            {
                if (humans[i] != null )
                {
                    for(int j = 0; j < animals.Length; j++)
                    {
                        if (animals[j] != null)
                        {
                            if (Vector2.Distance(humans[i].humanPos, animals[j].animalPos) <= 100)
                            {
                                Vector2 movDir = humans[i].humanPos - animals[j].animalPos;

                                movDir.Normalize();

                                animals[j].animalPos += movDir;


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



    }
}
