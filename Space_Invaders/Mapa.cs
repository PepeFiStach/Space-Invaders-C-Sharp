using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
	class Mapa
	{
		ContentManager content;

		Texture2D textura_invaders1;
		Texture2D textura_invaders2;
		Texture2D textura_invaders3;
		Texture2D textura_statek;

		const int border = 160;
        string direction = "LEFT";
        float speeed = 1;
		public Invaders[,] tab_invaders = new Invaders[5, 10];

		public string[,] tab_visible_invaders = new string[5, 10];

		Statek[] tab_statek = new Statek[1];
		public Mapa(ContentManager _content)
		{
			content = _content;
			textura_invaders1 = content.Load<Texture2D>("invaders1");
			textura_invaders2 = content.Load<Texture2D>("invaders2");
			textura_invaders3 = content.Load<Texture2D>("invaders3");
			textura_statek = content.Load<Texture2D>("Statek");
		}
		public Invaders[,] wczytaj_invaders()
		{
			for (int y = 0; y < tab_invaders.GetLength(0); y++)
			{
				for (int x = 0; x < tab_invaders.GetLength(1); x++)
				{
					if (y < 1)
					{
						tab_invaders[y, x] = new Invaders(textura_invaders2,new Rectangle((35 * x) + border, (35 * y) + border + 110, 20, 20));
					}
					else if (y >= 1 && y < 3)
					{
						tab_invaders[y, x] = new Invaders(textura_invaders1,new Rectangle((35 * x) + border, (35 * y) + border + 110, 20, 20));
					}
					else if (y >= 3 && y < 5)
					{
						tab_invaders[y, x] = new Invaders(textura_invaders3,new Rectangle((35 * x) + border, (35 * y) + border + 110, 20, 20));
					}
					tab_visible_invaders[y, x] = "YES";
				}
			}
			return tab_invaders;
		}

        public void ruch_invaders()
        {
            string change_direction = "N";

            #region stare nie dziala
            //for (int y = 0; y < tab_invaders.GetLength(0); y++)
            //{
            //    for (int x = 0; x < tab_invaders.GetLength(1); x++)
            //    {
            //        tab_invaders[y, x].rectangle_invaders.X = tab_invaders[y, x].rectangle_invaders.X - (int)tab_invaders[y, x].pozycja_invaders.X;

            //        if (tab_invaders[0, 0].rectangle_invaders.X <= 100)
            //        {
            //            tab_invaders[y, x].pozycja_invaders.X = -tab_invaders[y, x].pozycja_invaders.X;
            //            //tab_invaders[y, x].pozycja_invaders.X = (tab_invaders[y, x].pozycja_invaders.X * 2.5f)/2;

            //        }
            //        if (tab_invaders[0, 9].rectangle_invaders.X + tab_invaders[y, x].textura_invaders.Width >= 700)
            //        {
            //            tab_invaders[y, x].pozycja_invaders.X = -tab_invaders[y, x].pozycja_invaders.X;
            //            //tab_invaders[y, x].pozycja_invaders.X = (tab_invaders[y, x].pozycja_invaders.X * 2.5f) / 2;
            //        }
            //    }
            //}
            #endregion

            for (int y = 0; y < tab_invaders.GetLength(0); y++)
            {
                for (int x = 0; x < tab_invaders.GetLength(1); x++)
                {
                    if (direction.Equals("RIGHT"))
                    {
                        tab_invaders[y, x].rectangle_invaders.X = tab_invaders[y, x].rectangle_invaders.X + (int)speeed;
                    }
                    if (direction.Equals("LEFT"))
                    {
                        tab_invaders[y, x].rectangle_invaders.X = tab_invaders[y, x].rectangle_invaders.X - (int)speeed;
                    }
                }
            }
            for (int y = 0; y < tab_invaders.GetLength(0); y++)
            {
                for (int x = 0; x < tab_invaders.GetLength(1); x++)
                {
                    if (tab_invaders[0, 0].rectangle_invaders.X <= 100)
                    {
                        direction = "RIGHT";
                        change_direction = "Y";
                    }
                    if (tab_invaders[0, 9].rectangle_invaders.X + tab_invaders[y, x].textura_invaders.Width >= 700)
                    {
                        direction = "LEFT";
                        change_direction = "Y";
                    }
                }
            }
            if (change_direction.Equals("Y"))
            {
                for (int y = 0; y < tab_invaders.GetLength(0); y++)
                {
                    for (int x = 0; x < tab_invaders.GetLength(1); x++)
                    {
                        tab_invaders[y, x].rectangle_invaders.Y = tab_invaders[y, x].rectangle_invaders.Y + 10;
                        speeed = speeed + 0.007f;
                    }
                }
            }
        }

        public void strzelanie_invaders()
        {

        }
	}
}
