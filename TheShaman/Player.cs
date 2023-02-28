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
        public Vector2 playerPos = new Vector2(1200, 800);
        public bool isFlipped = false;
        public bool isHitting = false;
        public bool isPushing = false;
        public bool isIdle = true;
        public Texture2D HealthBar;
        public Texture2D manaBarTexture;
        public Color playerColor = Color.White;
        public int mana = 20;
        public int health = 20;
        public int AcceptedHumans = 0;
        private int fileCounter = 1;
        public void PlayerAnimation(List<string> filePath , ContentManager content)
        {
            if (fileCounter >= filePath.Count)
            {
                fileCounter = 0;
            }
            else
            {
                playerTexture = content.Load<Texture2D>($"{filePath[fileCounter]}");
                fileCounter += 1;
            }
        }
    }
}
