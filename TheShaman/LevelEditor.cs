using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;

namespace TheShaman
{
    internal class LevelEditor
    {
      
        int num = 0;
        private int groundAxis = 50;

        public void StartMapping(Ground[] ground , string[] map, Human[] humans , Animals[] animals, Water[] water, Tree[] tree , ContentManager Content)
        {

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '#')
                    {
                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground");
                        num++;
                    }
                    if (map[i][j] == '$')
                    {
                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground");
                        num++;
                    }
                    if (map[i][j] == '%')
                    {
                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground2");

                        num++;
                    }

                       
                        //if (map[i][j] == 'y')
                        //{
                        //    ground[num] = new Ground(64 * j, i * 64 + 50);
                        //    ground[num].groundTexture = Content.Load<Texture2D>("ground4");
                        //    num++;

                        //}
                        if (map[i][j] == 'x')
                    {
                        animals[num] = new Animals();
                        animals[num].animalPos = new Vector2(50 * j, i * 50);
                        animals[num].animalTexture = Content.Load<Texture2D>("AnimalAnimation/animal1");

                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground");
                        num++;

                    }
                    if (map[i][j] == '.')
                    {
                        num++;
                    }
                    if (map[i][j] == '@')
                    {
                        water[num] = new Water();
                        water[num].waterPos = new Vector2(50 * j, i * 50 + 50);
                        water[num].waterTexture = Content.Load<Texture2D>("waterMove1");

                        num++;
                    }
                    //if (map[i][j] == '?')
                    //{
                    //    humans[num] = new Human();
                    //    humans[num].humanPos = new Vector2(50 * j, i * 50);
                    //    humans[num].humanTexture = Content.Load<Texture2D>("HumansAnimation/HumanSecondary1");
                    //    ground[num] = new Ground(50 * j, i * 50 + 50);
                    //    ground[num].groundTexture = Content.Load<Texture2D>("ground");
                    //    num++;
                    //}
                    if (map[i][j] == '!')
                    {
                        humans[num] = new Human();
                        humans[num].humanPos = new Vector2(50 * j, i * 50);
                        humans[num].humanTexture = Content.Load<Texture2D>("HumansAnimation/HumanSecondary1");
                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground");
                        num++;
                    }
                    if (map[i][j] == '|')
                    {
                        tree[num] = new Tree();
                        tree[num].treePos = new Vector2(50 * j, i * 50);
                        tree[num].treeTexture = Content.Load<Texture2D>("tree-export");
                        ground[num] = new Ground(50 * j, i * 50 + 50);
                        ground[num].groundTexture = Content.Load<Texture2D>("ground");

                        num++;
                    }


                }
                groundAxis += 50;
            }




        }

       
      








    }
}
