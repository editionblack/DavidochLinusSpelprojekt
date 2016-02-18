using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjektLinusDavid
{
    class Walls
    {
        Rectangle walls;
        public Rectangle Walls
        {
            get
            {
                return walls;
            }
        }

        public Walls(int wallX, int wallY, int wallWidth, int wallHeight)
        {
            walls = new Rectangle(wallX, wallY, wallWidth, wallHeight);
        }

    }
}
