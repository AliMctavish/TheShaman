using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheShaman
{
    public class Items
    {
        public Vector2 ItemPos = new Vector2(0,0);
    }




    public class hony : Items
    {
        private Texture2D texture;
        public Texture2D honyTexture { get { return texture; } set { texture = value; } }
    }

}
