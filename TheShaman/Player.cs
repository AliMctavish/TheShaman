using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Player
    {
        public Texture2D playerTexture;
        public Vector2 playerPos = new Vector2(1200,800);
        public int playerAnimationCounter = 1;
        public int playerAnimationMovingCounter = 1;
        public int playerAnimationHitCounter = 1;
        public int playerAnimationMovingUpCounter = 1;
        public int playerAnimationMovingDownCounter = 1;
        public int playerPushingAnimationCounter = 1;
        public bool isFlipped = false;
        public bool isHitting = false;
        public bool isPushing = false;
        public Texture2D HealthBar;
        public Texture2D manaBarTexture;
        public Color playerColor = Color.White;
        public int mana = 20;
        public int health = 20;
        public int AcceptedHumans = 0;



        public void PlayerWalkingDownAnimation(string filePath , int counter , ContentManager content)
        {
            playerTexture = content.Load<Texture2D>($"{filePath}{playerAnimationMovingDownCounter}");
            playerAnimationMovingDownCounter += 1;
            if (playerAnimationMovingDownCounter == counter)
            {
                playerAnimationMovingDownCounter = 1;
            }
        }


        public void PlayerIsPushingAnimation(string filePath , int counter , ContentManager content)
        {
            playerTexture = content.Load<Texture2D>($"{filePath}{playerPushingAnimationCounter}");
            playerPushingAnimationCounter += 1;
            if (playerPushingAnimationCounter == counter)
            {
                playerTexture = content.Load<Texture2D>($"PlayerAnimation/playerPush7");
                playerPushingAnimationCounter = 5;
                isPushing = false;
            }
        }
        public void PlayerMovingAnimation(string filePath , int counter , ContentManager content)
        {
            playerTexture = content.Load<Texture2D>($"{filePath}{playerAnimationMovingCounter}");
            playerAnimationMovingCounter += 1;
            if (playerAnimationMovingCounter == counter)
            {
                playerAnimationMovingCounter = 1;
            }
        }
        public void PlayerIsHittingFlipAnimation(string filePath, int counter, ContentManager content)
        {
            playerTexture = content.Load<Texture2D>($"{filePath}{playerAnimationHitCounter}");

            playerAnimationHitCounter += 1;
            if (playerAnimationHitCounter == counter)
            {
                playerAnimationHitCounter = 1;
                isHitting = false;
            }
        }
        public void PlayerIsPushingFlipAnimation(string filePath , int counter , ContentManager content)
        {
            playerTexture = content.Load<Texture2D>($"{filePath}{playerPushingAnimationCounter}");
            playerPushingAnimationCounter += 1;
            if (playerPushingAnimationCounter == counter)
            {
                playerTexture = content.Load<Texture2D>("PlayerFlipAnimation/playerPushFlip7");
                playerPushingAnimationCounter = 5;
                isPushing = false;
            }
        }
    }





   
  
}
