using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
	class Invaders
	{
		public Texture2D textura_invaders;

		public Rectangle rectangle_invaders;

		public Vector2 pozycja_invaders;

		Mapa map;

		public Invaders(Texture2D _textura_invaders, Rectangle _rectangle_invaders)
		{
			textura_invaders = _textura_invaders;
			rectangle_invaders = _rectangle_invaders;
			pozycja_invaders.X = 1;
			pozycja_invaders.Y = 1;
		}

		public void Update()
		{
			rectangle_invaders.X = rectangle_invaders.X - (int)pozycja_invaders.X;
			//rectangle_invaders.Y = rectangle_invaders.Y - (int)pozycja_invaders.Y;

			if (rectangle_invaders.X <= 100)
			{
				pozycja_invaders.X = -pozycja_invaders.X;
			}
			if (rectangle_invaders.X + textura_invaders.Width >= 700)
			{
				pozycja_invaders.X = -pozycja_invaders.X;
			}

			//if (rectangle_invaders.Y <= 100)
			//{
			//    pozycja_invaders.Y = -pozycja_invaders.Y;
			//}
			//if (rectangle_invaders.Y + textura_invaders.Width >= 700)
			//{
			//    pozycja_invaders.Y = -pozycja_invaders.Y;
			//}
		} //STARY RUCH

		public void Draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(textura_invaders, rectangle_invaders, Color.White);
		}
	}
}
