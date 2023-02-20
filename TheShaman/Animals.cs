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
        int fileCounter = 1;
        public void AnimateAnimal(string filepath , int counter,  ContentManager content)
        {
            if(animalTexture.Name != filepath)
            {
                animalTexture = content.Load<Texture2D>($"{filepath}{fileCounter}");
                fileCounter += 1;
            }else
            {
                animalTexture = content.Load<Texture2D>($"{filepath}{fileCounter}");
                fileCounter = 1;
            }
        }
    }

    
}
