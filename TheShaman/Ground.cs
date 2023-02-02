using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    internal class Ground
    {
        public Texture2D groundTexture;
        public Rectangle groundPos;

        public Ground(int posX, int posY)
        {
            this.groundPos = new Rectangle(posX, posY, 50, 64);
        }


      

    }
}
