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
        private int fileCounter = 0;
        public virtual void AnimateHuman(List<string> filepath,ContentManager content)
        {
            if (fileCounter >= filepath.Count)
            {
                fileCounter = 0;
            }
            else
            {
                humanTexture = content.Load<Texture2D>($"{filepath[fileCounter]}");
                fileCounter += 1;
            }
        }
    }
    class SecondaryHuman : Human
    {
        private int fileCounter = 1;

        public override void AnimateHuman(List<string> filepath, ContentManager content)
        {
            if (fileCounter >= filepath.Count)
            {
                fileCounter = 0;
            }
            else
            {
                humanTexture = content.Load<Texture2D>($"{filepath[fileCounter]}");
                fileCounter += 1;
            }
        }
    }
}
