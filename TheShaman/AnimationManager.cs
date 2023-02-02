using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class AnimationManager
    {

        public void playerAnimation(Player player, ContentManager Content)
        {

            if (player.isFlipped == false)
            {
                player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerIdle {player.playerAnimationCounter}");
            }
            else
            {
                player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerIdle{player.playerAnimationCounter}");
            }
        
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right) )
            {
                    player.isFlipped = false;
                if (player.isFlipped == false)
                {
                    player.playerTexture = Content.Load<Texture2D>($"PlayerAnimation/playerMoving{player.playerAnimationMovingCounter}");
                    player.playerAnimationMovingCounter += 1;
                    if (player.playerAnimationMovingCounter == 4)
                    {
                        player.playerAnimationMovingCounter = 1;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.isFlipped = true;
                    player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerMoving{player.playerAnimationMovingCounter}");

                    player.playerAnimationMovingCounter += 1;
                    if (player.playerAnimationMovingCounter == 4)
                    {
                        player.playerAnimationMovingCounter = 1;
                    }
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
                    player.playerTexture = Content.Load<Texture2D>($"PlayerFlipAnimation/playerHitFilp{player.playerAnimationHitCounter}");

                    player.playerAnimationHitCounter += 1;
                    if (player.playerAnimationHitCounter == 11)
                    {
                        player.playerAnimationHitCounter = 1;
                        player.isHitting = false;
                    }

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
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                player.isHitting = true;
            }


            




        }

        


    }
}
