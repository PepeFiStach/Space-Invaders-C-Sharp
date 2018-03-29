using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
	class Bullets
	{
		public Texture2D textura_pocisk;
		public Vector2 position_pocisk;
		public Vector2 origin;
		public Rectangle rectangle_pocisk;
		public bool is_visible;
		public float speed;

		public Bullets(Texture2D _textura_pocisk)
		{
			textura_pocisk = _textura_pocisk;
			speed = 7;
			is_visible = false;
		}

		public void Draw(SpriteBatch sprite_Batch)
		{
			sprite_Batch.Draw(textura_pocisk, position_pocisk, Color.LightSkyBlue);
		}
	}
}
