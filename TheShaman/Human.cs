using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
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
        private int idleAnimationCounter = 1;
        public int humanWalkingAnimationCounter= 1;
        public Texture2D HealthBar;
        public int HealthCounter = 1;
        public virtual void AnimateHuman(string filepath , int counter ,ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"{filepath}{idleAnimationCounter}");
            idleAnimationCounter += 1;
            if (idleAnimationCounter == counter)
            {
             humanTexture = content.Load<Texture2D>($"{filepath}{counter}");
             idleAnimationCounter = 1;
            }
        }
    }

    class SecondaryHuman : Human
    {
        private int idleAnimationCounter = 1;
        public override void AnimateHuman(string filepath, int counter, ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"{filepath}{idleAnimationCounter}");
            idleAnimationCounter += 1;
            if (idleAnimationCounter == counter)
            {
                humanTexture = content.Load<Texture2D>($"{filepath}{counter}");
                idleAnimationCounter = 1;
            }
        }
    }



        



}
