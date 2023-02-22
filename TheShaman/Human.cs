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
        public Texture2D HealthBar;
        public int HealthCounter = 1;
        private int[] fileCounter = { 1, 2 , 3 };
        public virtual void AnimateHuman(string filepath , int counter, int type  ,ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"{filepath}{fileCounter[type]}");
            fileCounter[type] += 1;
            if (fileCounter[type] == counter)
            {
             humanTexture = content.Load<Texture2D>($"{filepath}{counter}");
             fileCounter[type] = 1;
            }
        }
    }
    class SecondaryHuman : Human
    {
        private int[] fileCounter = { 1, 2, 3 };

        public override void AnimateHuman(string filepath, int counter , int type, ContentManager content)
        {
            humanTexture = content.Load<Texture2D>($"{filepath}{fileCounter[type]}");
            fileCounter[type] += 1;
            if (fileCounter[type] == counter)
            {
                humanTexture = content.Load<Texture2D>($"{filepath}{counter}");
                fileCounter[type] = 1;
            }
        }
    }
}
