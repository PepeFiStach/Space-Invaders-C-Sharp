using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
	class Test
	{
		Texture2D textura_test;

		Rectangle rectangle_test;

		Vector2 pozycja_test;
		public Test(Texture2D _textura_invaders, Rectangle _rectangle_test)
		{
			textura_test = _textura_invaders;
			rectangle_test = _rectangle_test;
			pozycja_test.X = 3f;
			pozycja_test.Y = 3f;
		}

		public void Update()
		{
			rectangle_test.X = rectangle_test.X - (int)pozycja_test.X;

			if (rectangle_test.X <= 0)
			{
				rectangle_test.X = 0;
			}
		}

		public void Draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(textura_test, rectangle_test, Color.White);
		}
	}
}
