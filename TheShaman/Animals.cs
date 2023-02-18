using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int fileCounter = 1;
        public int AnimateAnimal(string filepath , int counter  ,  ContentManager content)
        {
            animalTexture = content.Load<Texture2D>($"{filepath}{fileCounter}");
            fileCounter += 1;
            if (fileCounter == counter)
            {
                animalTexture = content.Load<Texture2D>($"{filepath}{fileCounter}");
                fileCounter = 1;
                return fileCounter;
            }
            return fileCounter;
        }
    }

    
}
