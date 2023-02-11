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
using MonoGame.Extended.Collections;

namespace TheShaman
{
    internal class LevelEditor
    {
      
        int num = 0;
        private int groundAxis = 50;
        private Ground ground;
        private Human human;
        private Animals animal;
        private Water water;
        private Tree tree;



        public void StartMapping(List<Ground> grounds , string[] map, List<Human> humans , List<Animals> animals, List<Water> waters, List<Tree> trees , ContentManager Content)
        {

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '#')
                    {
                        ground = new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("Mashroom");
                        grounds.Add(ground);
                    }
                    if (map[i][j] == '$')
                    {
                        ground = new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("ground");
                        grounds.Add(ground);
                    }
                    if (map[i][j] == '%')
                    {
                        ground = new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("ground2");
                        grounds.Add(ground);
                    }

                       
                        //if (map[i][j] == 'y')
                        //{
                        //    ground[num] = new Ground(64 * j, i * 64 + 50);
                        //    ground[num].groundTexture = Content.Load<Texture2D>("ground4");
                        //    num++;

                        //}
                        if (map[i][j] == 'x')
                    {
                        animal = new Animals();
                        animal.animalPos = new Vector2(50 * j, i * 50);
                        animal.animalTexture = Content.Load<Texture2D>("AnimalAnimation/animal1");
                        animals.Add(animal);
                        ground = new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("ground");
                        grounds.Add(ground); 

                    }
                    if (map[i][j] == '.')
                    {
                        num++;
                    }
                    if (map[i][j] == '@')
                    {
                        water = new Water();
                        water.waterPos = new Vector2(50 * j, i * 50 + 50);
                        water.waterTexture = Content.Load<Texture2D>("waterMove1");
                        waters.Add(water);
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
                        human = new Human();
                        human.humanPos = new Vector2(50 * j, i * 50);
                        human.humanTexture = Content.Load<Texture2D>("HumansAnimation/HumanSecondary1");
                        human.HealthBar = Content.Load<Texture2D>("HealthBar1");
                        ground = new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("ground");
                        humans.Add(human);
                        grounds.Add(ground);
                    }
                    if (map[i][j] == '|')
                    {
                        tree = new Tree();
                        tree.treePos = new Vector2(50 * j, i * 50);
                        tree.treeTexture = Content.Load<Texture2D>("tree-export");
                        ground= new Ground(50 * j, i * 50 + 50);
                        ground.groundTexture = Content.Load<Texture2D>("ground");
                        trees.Add(tree);
                        grounds.Add(ground);
                    }


                }
                groundAxis += 50;
            }




        }

       
      








    }
}
