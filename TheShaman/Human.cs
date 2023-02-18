using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Human
    {
        public Texture2D humanTexture;
        public Vector2 humanPos;
        public bool isFollowing = false;
        public bool isArrived = false;
        public bool isAdded = false;
        public bool isGettingHit = false;
        public bool isArriving = false;
        public int humanHealth = 20;
        public Color damageColor = Color.White;
        private int humanIdleAnimationCounter = 1;
        public int humanWalkingAnimationCounter= 1;
        public Texture2D HealthBar;
        public int HealthCounter = 1;




        public void AnimateIdleHuman(ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanSecondary{humanIdleAnimationCounter}");
            humanIdleAnimationCounter += 1;
            if (humanIdleAnimationCounter == 5)
            {
                humanTexture = content.Load<Texture2D>("HumansAnimation/HumanSecondary5");
                humanIdleAnimationCounter = 1;
            }
        }
    }

    class SecondaryHuman : Human
    {
        private int humanIdleAnimationCounter = 1;
        public void animateIdleHuman(ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"HumansAnimation/HumanIdle{humanIdleAnimationCounter}");
            humanIdleAnimationCounter += 1;
            if (humanIdleAnimationCounter == 5)
            {
                humanTexture = content.Load<Texture2D>("HumansAnimation/HumanSecondary5");
                humanIdleAnimationCounter = 1;
            }
        }
    }



        



}
