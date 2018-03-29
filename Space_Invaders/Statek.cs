using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
	class Statek
	{
		Texture2D textura_statku;

		public Vector2 pozycja_statku;

		public Rectangle rectangle_statku;


		//public Statek(Texture2D _textura_statku, Vector2 _pozycja_statku)
        public Statek(Texture2D _textura_statku, Rectangle _rectangle_statku) //Texture2D _textura_statku, Rectangle _rectangle_statku
		{
			textura_statku = _textura_statku;
			rectangle_statku = _rectangle_statku;
			//pozycja_statku = _pozycja_statku;
			//rectangle_statku = new Rectangle((int)pozycja_statku.X, (int)pozycja_statku.Y, 50, 25); //wymiary (50,25)
		}

		public void Update()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
                rectangle_statku.X -= 8; //wszedzie rectangle_statku ! a pozniej w sprite tez to bedzie mniejsze
			}
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				rectangle_statku.X += 8;
			}


			if (rectangle_statku.X <= 100)
			{
				rectangle_statku.X = 100;
			}
			if (rectangle_statku.X + textura_statku.Width >= 750)
			{
				rectangle_statku.X = 750 - textura_statku.Width;
			}
		}

		public void Draw(SpriteBatch sprite_batch)
		{
			sprite_batch.Draw(textura_statku, rectangle_statku, Color.White); //textura_statku,rectangle_statku,Color.White
		}
	}
}
