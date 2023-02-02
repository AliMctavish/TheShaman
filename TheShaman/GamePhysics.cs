using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class GamePhysics
    {

        public void playerBounderies(Player player , Enemy[] enemy, Vector2 firePos)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] != null)
                {
                    if (Vector2.Distance(player.playerPos, enemy[i].enemyPos) < 100 && Keyboard.GetState().IsKeyDown(Keys.Space) )
                    {
                        enemy[i].isFollowing = true;
                    }

                    if (enemy[i].isFollowing == true)
                    {
                        Vector2 movDir = player.playerPos - enemy[i].enemyPos;

                        movDir.Normalize();

                        enemy[i].enemyPos += movDir;
                    }

                    if (Vector2.Distance(player.playerPos, firePos) < 100 && Keyboard.GetState().IsKeyDown(Keys.Space) && enemy[i].isFollowing)
                    {
                        enemy[i].isFollowing = false;
                        enemy[i].isArrived = true;
                    }

                    if (enemy[i].isArrived == true)
                    {
                        Vector2 movDir = firePos - enemy[i].enemyPos;

                        movDir.Normalize();

                        enemy[i].enemyPos += movDir;
                    }
                }
            }
        }



    }
}
