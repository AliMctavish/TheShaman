﻿using Microsoft.Xna.Framework;
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

        public int humanHealth = 20;


        public Color damageColor = Color.White;

        public int humanIdleAnimationCounter = 1;

        public int humanWalkingAnimationCounter= 1;

        public Texture2D HealthBar;
        public int HealthCounter = 1;

      



    }


}
