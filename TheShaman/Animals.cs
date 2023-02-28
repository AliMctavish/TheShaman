using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Animals
    {
        public Vector2 animalPos;
        public Texture2D animalTexture;
        public bool isFlipped = false;
        public bool isMoving = false;
        public Color animalColor = Color.White;
        public bool isAttacking = false;
        int fileCounter = 0;
        public void AnimateAnimal(List<string> filepath ,  ContentManager content)
        {
            if (fileCounter >= filepath.Count)
            {
                fileCounter = 0;
            }
            else
            {
              animalTexture = content.Load<Texture2D>($"{filepath[fileCounter]}");
              fileCounter += 1;
            }
        }
    }
}
