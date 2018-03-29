using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Tarcza
    {
        public Texture2D texture_tarcza;
        public Rectangle rectangle_tarcza;
        public Vector2 pozycja_tarcza;
        public bool rysuj;

        public Tarcza(Texture2D _texture_tarcza)
        {
            texture_tarcza = _texture_tarcza;
            //rectangle_tarcza = _rectangle_tarcza;
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture_tarcza, rectangle_tarcza, Color.White);
        }
    }
}
