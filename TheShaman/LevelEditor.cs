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
        Ground[,] tileMap;
        

        public void Map(ContentManager Content)
        {
            tileMap = new Ground[20,20];

            int xLength = tileMap.GetLength(0);
            int yLength = tileMap.GetLength(1);



            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    tileMap[i, j] = new Ground();
                    if (j < 10)
                    {
                        tileMap[i, j].groundTexture = Content.Load<Texture2D>("ground");
                    }
                    else
                    {
                        tileMap[i, j].groundTexture = Content.Load<Texture2D>("groundDryTexture");

                    }
                    tileMap[i, j].groundPos = new Rectangle(50 * i, 50 * j, 50, 50);

                }

            }




        }

       
      








    }
}
