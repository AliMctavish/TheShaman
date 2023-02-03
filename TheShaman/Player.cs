using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Player
    {
        public Texture2D playerTexture;

        public Vector2 playerPos = new Vector2(1200/2,600/2);

        public int playerAnimationCounter = 1;
        public int playerAnimationMovingCounter = 1;
        public int playerAnimationHitCounter = 1;
        public int playerAnimationMovingUpCounter = 1;
        public int playerAnimationMovingDownCounter = 1;
        public bool isFlipped = false;
        public bool isHitting = false;
        public int AcceptedHumans = 0;

    }
}
