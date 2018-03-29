using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Space_Invaders
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;

		SpriteBatch spriteBatch;

		Texture2D textura_invaders_1;
		Texture2D textura_plansza;
		Texture2D textura_statek;
        Texture2D koniec_planszy;
        Texture2D textura_zycia;

		Vector2 pozycja_statek;
		Vector2 velocity;
		Vector2 tescik;

		Rectangle rectangle_statek;
        Rectangle rectangle_koniec_planszy = new Rectangle(300, 560, 1000, 25); //300 600

        public int screenWidth;
		public int screenHight;
        int licznik_zycia=3;
        int wynik_do_wygranej;
        int score;

        bool pocisk_na_planszy_statek;
        bool pocisk_na_planszy_invaders;
        bool is_clicked_zycia = false;

        bool rysuj_koniec_planszy = false;
        bool strzelanie_on = true;
        string direction ="LEFT";
		#region pociski z klasy statek
		List<Bullets> bullet_list_statek = new List<Bullets>();
		Texture2D test_bullet_texture;
		bool shoot_click;
        #endregion

        #region pociski z klasy invaders
        List<Bullets> bullet_list_invaders = new List<Bullets>();
        bool shoot_invaders;
        int limit_pociskow = 30;
        #endregion

        #region tarcza
        List<Tarcza> tarcza_list = new List<Tarcza>();
        //List<string> list_string_rysuj = new List<string>();
        string[] list_string_rysuj = new string[5];
        Tarcza tarcza;

        Texture2D textura_tarcza1;

        Rectangle rectangle_tarcza1;

        int licznik_zycia_tarczy;

        bool rysuj=true;
        int licznik_testowy;
        #endregion

        #region strzelanie
        //List<Vector2> pociski;
        //float predkosc_pociski = 200f;
        //Texture2D textura_pociski;
        //bool is_clicked;
        //Vector2 pozycja_pociski;
        //Rectangle rectangle_pociski;
        #endregion

        #region DO TESTOW
        Texture2D test_texture;
		Rectangle test_rectangle;
		Vector2 test_vector;
		Test[] test_tab = new Test[5];
		#endregion

		Statek statek;
		Mapa map;
		Invaders[,] invaders_tab = new Invaders[5, 10];

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			graphics.PreferredBackBufferHeight = 780; //780
			graphics.PreferredBackBufferWidth = 790; //790

			screenWidth = GraphicsDevice.Viewport.Width;
			screenHight = GraphicsDevice.Viewport.Height;

			spriteBatch = new SpriteBatch(GraphicsDevice);

			textura_invaders_1 = Content.Load<Texture2D>("invaders1");
			textura_plansza = Content.Load<Texture2D>("plansza1");
			textura_statek = Content.Load<Texture2D>("Statek");
            koniec_planszy = Content.Load<Texture2D>("koniec");

            pozycja_statek = new Vector2(300, 600); /////////
			//statek = new Statek(textura_statek, pozycja_statek = new Vector2(pozycja_statek.X, pozycja_statek.Y)); //new Rectangle((int)pozycja_statek.X,(int)pozycja_statek.Y, 50, 25)
			statek = new Statek(textura_statek, new Rectangle((int)pozycja_statek.X, (int)pozycja_statek.Y, 50, 25)); //50,25

			map = new Mapa(Content);
			invaders_tab = map.wczytaj_invaders();

			#region DO TESTOW
			test_texture = Content.Load<Texture2D>("invaders1");
			test_rectangle = new Rectangle(400, 400, 20, 20);

			for (int i = 0; i < test_tab.Length; i++)
			{
				test_tab[i] = new Test(Content.Load<Texture2D>("invaders2"), new Rectangle(i * 100, 100, 10, 10));
			}

			test_vector.X = 3f;
			test_vector.Y = 3f;
			#endregion

			#region strzelanie
			//pociski = new List<Vector2>();
			//textura_pociski = Content.Load<Texture2D>("pocisk");
			//is_clicked = false;
			//rectangle_pociski = new Rectangle((int)pozycja_pociski.X, (int)pozycja_pociski.Y, 10, 10);
			#endregion

			#region pociski z klasy
			test_bullet_texture = Content.Load<Texture2D>("pocisk");
            #endregion

            //for (int y = 0; y<invaders_tab.GetLength(0); y++)
            //{
            //	for (int x = 0; x<invaders_tab.GetLength(1); x++)
            //	{
            //		map.tab_string[y, x] = "YES";
            //	}
            //}

            #region tarcza
            for (int i = 0; i < 5; i++)
            {
                Tarcza new_tarcza = new Tarcza(Content.Load<Texture2D>("tarcza1"));
                new_tarcza.rectangle_tarcza = new Rectangle((100 * i) + 180, 560, 45, 35);
                tarcza_list.Add(new_tarcza);
                //tarcza_list[i].rysuj = true;
                list_string_rysuj[i] = "YES";
            }
            #endregion

            IsMouseVisible = true;
			graphics.ApplyChanges();

		}
		protected override void UnloadContent()
		{

		}
		protected override void Update(GameTime gameTime)
		{

			//invaders_tab = map.wczytaj_invaders();
			statek.Update();

			#region DO TESTOW
			test_rectangle.X = test_rectangle.X - (int)test_vector.X; //Ruch 1 invadera w lewo
			test_rectangle.Y = test_rectangle.Y - (int)test_vector.Y;
			foreach (Test element in test_tab) //ruch tab invadera_test
			{
				element.Update();
			}
			//if (test_rectangle.X <= 0) //zatrzymanie 1 invadera na koncu mapy
			//{
			//    test_vector.X = 0;
			//}
			if (test_rectangle.X <= 0)
			{
				test_vector.X = -test_vector.X;
			}
			if (test_rectangle.X + test_texture.Width >= 790)
			{
				test_vector.X = -test_vector.X;
			}
			if (test_rectangle.Y <= 0)
			{
				test_vector.Y = -test_vector.Y;
			}
			if (test_rectangle.Y + test_texture.Height >= 780)
			{
				test_vector.Y = -test_vector.Y;
			}
            #endregion

            map.ruch_invaders();



            #region Strzelanie
            //if (Keyboard.GetState().IsKeyDown(Keys.Z))
            //{
            //	if (is_clicked == false)
            //	{
            //		pociski.Add(statek.pozycja_statku); //statek.pozycja_statku
            //		is_clicked = true;
            //	}
            //}
            //if (Keyboard.GetState().IsKeyUp(Keys.Z))
            //{
            //	is_clicked = false;
            //}
            //for (int i = 0; i < pociski.Count; i++)
            //{
            //	float y = pociski[i].Y;
            //	y -= predkosc_pociski * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //	pociski[i] = pozycja_pociski = new Vector2(pociski[i].X, y);
            //}
            #endregion

            #region pociski z klasy
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && pocisk_na_planszy_statek==false)
			{
				if (shoot_click == false)
				{
                    pocisk_na_planszy_statek = true;
                    shoot();
					shoot_click = true;
				}
			}
			if (Keyboard.GetState().IsKeyUp(Keys.Space))
			{
				shoot_click = false;
			}
			update_bullets();

                strzelanie_invaders(); ///////
                update_strzelanie_invaders(); //////

            #endregion

            //for (int y = 0; y < invaders_tab.GetLength(0); y++)
            //{
            //    for (int x = 0; x < invaders_tab.GetLength(1); x++)
            //    {
            //        if (invaders_tab[y, x].rectangle_invaders.Intersects(rectangle_pociski))
            //        {
            //            predkosc_pocisk = 500f;
            //        }
            //    }
            //}

            #region tarcza
            //for (int i = 0; i < 5; i++)
            //{
            //    Tarcza new_tarcza = new Tarcza(Content.Load<Texture2D>("tarcza1"));
            //    new_tarcza.rectangle_tarcza = new Rectangle((100 * i) + 150, 500, 45, 35);
            //    tarcza_list.Add(new_tarcza);
            //    tarcza_list[i].rysuj = true;
            //}
            #endregion

            uuuuuuuupdate();
            zeby_nie_strzelac_przez_tarcze();
            koniec_gry();  

			base.Update(gameTime);
		}

		public void update_bullets()
		{
			foreach (Bullets b in bullet_list_statek)
			{
				b.position_pocisk.Y = b.position_pocisk.Y - b.speed;

                if(b.position_pocisk.Y <=250)
                {
                    b.is_visible = false;
                    pocisk_na_planszy_statek = false;
                }

				b.rectangle_pocisk = new Rectangle((int)b.position_pocisk.X, (int)b.position_pocisk.Y, b.textura_pocisk.Width, b.textura_pocisk.Height);

				for (int y = 0; y < invaders_tab.GetLength(0); y++)
				{
					for (int x = 0; x < invaders_tab.GetLength(1); x++)
					{
                        if (map.tab_visible_invaders[y, x].Equals("YES"))
                        {
                            if (b.rectangle_pocisk.Intersects(invaders_tab[y, x].rectangle_invaders))
                            {
                                map.tab_visible_invaders[y, x] = "NO";
                                b.is_visible = false;
                                pocisk_na_planszy_statek = false;
                                wynik_do_wygranej = wynik_do_wygranej + 1;
                                score = score + 100;
                            }
                        }
					}
				}

			}

            for (int i = 0; i < bullet_list_statek.Count; i++)
            {
                if (!bullet_list_statek[i].is_visible)
                {
                    bullet_list_statek.RemoveAt(i);
                    i--;
                }
            }
        }

		public void shoot()
		{
			Bullets new_bullet = new Bullets(test_bullet_texture);
			new_bullet.position_pocisk = new Vector2(statek.rectangle_statku.X+20, statek.rectangle_statku.Y);
			new_bullet.is_visible = true;
			bullet_list_statek.Add(new_bullet);
		}

        public void strzelanie_invaders()
        {
            if (limit_pociskow >= 0)
                limit_pociskow--;
            Random rand = new Random();
            int randX = rand.Next(0, 9);
            int randY=rand.Next(0,4);

            for (int y = 0; y < invaders_tab.GetLength(0); y++)
            {
                for (int x = 0; x < invaders_tab.GetLength(1); x++)
                {

                    if (limit_pociskow <= 0)
                    {
                        Bullets new_bullet_invaders = new Bullets(test_bullet_texture);
                        new_bullet_invaders.position_pocisk = new Vector2(invaders_tab[randY, randX].rectangle_invaders.X, invaders_tab[randY, randX].rectangle_invaders.Y);
                        new_bullet_invaders.is_visible = true;
                        bullet_list_invaders.Add(new_bullet_invaders);
                    }
                }
            }

            if (limit_pociskow == 0)
                limit_pociskow = 30;
        }

        public void zeby_nie_strzelac_przez_tarcze()
        {
            foreach (Bullets b in bullet_list_statek)
            {
                for (int i = 0; i < tarcza_list.Count; i++)
                {
                    if (list_string_rysuj[i].Equals("YES"))
                    {
                        if (b.rectangle_pocisk.Intersects(tarcza_list[i].rectangle_tarcza))
                        {
                            b.is_visible = false;
                            pocisk_na_planszy_statek = false;
                        }
                    }
                }
            }
        }
        public void uuuuuuuupdate() //tarcza
        {
            foreach (Bullets b in bullet_list_invaders)
            {
                for (int i = 0; i < tarcza_list.Count; i++)
                {
                    {
                        if (list_string_rysuj[i].Equals("YES"))
                        {
                            if (b.rectangle_pocisk.Intersects(tarcza_list[i].rectangle_tarcza))
                            {
                                b.is_visible = false;
                                licznik_testowy = licznik_testowy + 1;
                                //list_string_rysuj[i] = "NO";

                                if (licznik_testowy == 250 || licznik_testowy==450 || licznik_testowy == 650 || licznik_testowy == 850 || licznik_testowy == 1050)
                                {
                                    //tarcza_list[i].rysuj = false;
                                    list_string_rysuj[i] = "NO";
                                }
                            }
                        }
                    }
                }
            }
        }
        public void update_strzelanie_invaders()
        {
            foreach (Bullets b in bullet_list_invaders)
            {
                b.position_pocisk.Y = b.position_pocisk.Y + (float)2; //speed

                if (b.position_pocisk.Y >= 620)
                {
                    b.is_visible = false;
                    pocisk_na_planszy_invaders = false;
                }

                b.rectangle_pocisk = new Rectangle((int)b.position_pocisk.X, (int)b.position_pocisk.Y, b.textura_pocisk.Width, b.textura_pocisk.Height);

                for (int y = 0; y < invaders_tab.GetLength(0); y++)
                {
                    for (int x = 0; x < invaders_tab.GetLength(1); x++)
                    {
                        if (b.rectangle_pocisk.Intersects(statek.rectangle_statku) && is_clicked_zycia==false)
                        {
                            b.is_visible = false;
                            licznik_zycia = licznik_zycia - 1;
                            is_clicked_zycia = true;

                            if (licznik_zycia == -147)
                            {
                                rysuj_koniec_planszy = true;
                            }
                        }
                        //for (int i = 0; i < tarcza_list.Count; i++)
                        //{
                        //    {
                        //        if (b.rectangle_pocisk.Intersects(tarcza_list[i].rectangle_tarcza))
                        //        {
                        //            rysuj_koniec_planszy = true;
                        //        }
                        //    }
                        //}
                    }
                }
                if (is_clicked_zycia == true)
                {
                    is_clicked_zycia = false;
                }
            }
            for (int i = 0; i < bullet_list_invaders.Count; i++)
            {
                if (!bullet_list_invaders[i].is_visible)
                {
                    bullet_list_invaders.RemoveAt(i);
                    i--;
                }
            }
        }

        public void koniec_gry()
        {
            for (int y = 0; y < invaders_tab.GetLength(0); y++)
            {
                for (int x = 0; x < invaders_tab.GetLength(1); x++)
                {
                    if (map.tab_visible_invaders[y, x].Equals("YES"))
                    {
                        if(invaders_tab[y,x].rectangle_invaders.Intersects(rectangle_koniec_planszy))
                        {
                            rysuj_koniec_planszy = true;
                        }
                    }
                }
            }
        }

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			spriteBatch.Draw(textura_plansza, new Vector2(0, 0), Color.White);

			statek.Draw(spriteBatch);

			//foreach (Invaders element in invaders_tab)
			//{
			//	for (int y = 0; y < invaders_tab.GetLength(0); y++)
			//	{
			//		for (int x = 0; x < invaders_tab.GetLength(1); x++)
			//			if(map.tab_string[y,x].Equals("YES"))
			//			{
			//				element.Draw(spriteBatch);
			//			}
			//		}
			//	}
			//}
			for (int y = 0; y < invaders_tab.GetLength(0); y++)
			{
				for (int x = 0; x < invaders_tab.GetLength(1); x++)
				{
					if (map.tab_visible_invaders[y, x].Equals("YES"))
					{
						invaders_tab[y, x].Draw(spriteBatch);
					}

				}
			}

            #region DO TESTOW
            //spriteBatch.Draw(test_texture, test_rectangle, Color.White);
            //foreach (Test element in test_tab)
            //{
            //    element.Draw(spriteBatch);
            //}
            #endregion

            #region strzelanie
            //for (int i = 0; i < pociski.Count; i++)
            //{
            //	spriteBatch.Draw(textura_pociski, pociski[i], Color.White);
            //}
            #endregion

            #region pociski z klasy statek
            foreach (Bullets b in bullet_list_statek)
			{
				b.Draw(spriteBatch);
			}
            #endregion

            #region pociski z klasy invaders
            foreach (Bullets b in bullet_list_invaders)
            {
                b.Draw(spriteBatch);
            }
            #endregion

            #region tarcza
            //foreach (Tarcza t in tarcza_list)
            //{
            //    //if (t.rysuj==true)
            //    //{
            //    //    t.Draw(spriteBatch);
            //    //}
            //    for (int i = 0; i < list_string_rysuj.Length; i++)
            //    {
            //        if (list_string_rysuj[i].Equals("YES"))
            //        {
            //            t.Draw(spriteBatch);
            //        }
            //    }
            //}
            for (int i = 0; i < list_string_rysuj.Length; i++)
            {
                if (list_string_rysuj[i].Equals("YES"))
                {
                    tarcza_list[i].Draw(spriteBatch);
                }
            }
            #endregion

            if (licznik_zycia == 3)
            {
                spriteBatch.Draw(textura_statek, new Rectangle(385, 700, 60, 35), Color.White);
                spriteBatch.Draw(textura_statek, new Rectangle(455, 700, 60, 35), Color.White);
                spriteBatch.Draw(textura_statek, new Rectangle(525, 700, 60, 35), Color.White);
            }
            else if (licznik_zycia == -47)
            {
                spriteBatch.Draw(textura_statek, new Rectangle(400, 700, 60, 35), Color.White);
                spriteBatch.Draw(textura_statek, new Rectangle(460, 700, 60, 35), Color.White);
            }
            else if (licznik_zycia == -97)
            {
                spriteBatch.Draw(textura_statek, new Rectangle(400, 700, 60, 35), Color.White);
            }

            if (rysuj_koniec_planszy==true)
            {
                spriteBatch.Draw(koniec_planszy, new Vector2(0, 0), Color.White);
            }
            if (wynik_do_wygranej==50)
            {
                spriteBatch.Draw(koniec_planszy, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(Content.Load<SpriteFont>("czcionka"), score.ToString(), new Vector2(500, 700), Color.White);
            }

            //spriteBatch.DrawString(Content.Load<SpriteFont>("czcionka"), licznik_testowy.ToString(), new Vector2(0, 0), Color.White);

            spriteBatch.End();
			base.Draw(gameTime);
		}
	}

}
