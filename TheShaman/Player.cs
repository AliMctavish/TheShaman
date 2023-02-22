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
        public Texture2D HealthBar;
        public Texture2D manaBarTexture;
        public Color playerColor = Color.White;
        public int mana = 20;
        public int health = 20;
        public int AcceptedHumans = 0;
        private int[] fileCounter = { 1, 2, 3, 4, 5, 6 };
        public void PlayerAnimation(string filePath, int counter, int type, ContentManager content)
        {
            if (type != 3)
            {
                playerTexture = content.Load<Texture2D>($"{filePath}{fileCounter[type]}");
                fileCounter[type] += 1;
                if (fileCounter[type] == counter)
                {
                    fileCounter[type] = 1;
                }
            }
            else
            {
                playerTexture = content.Load<Texture2D>($"{filePath}{fileCounter[type]}");
                fileCounter[type] += 1;
                if (fileCounter[type] == counter)
                {
                    fileCounter[type] = 5;
                }
            }
        }
    }
}
