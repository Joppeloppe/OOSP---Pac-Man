using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Jumpin__Pumpkin.Tile;
using Jumpin__Pumpkin.Sprite;
using System.Diagnostics;

namespace Jumpin__Pumpkin
{
    public class Content_Manager
    {
        Game1 game_1;
        Player player;

        public static Texture2D start_bg, end_bg, win_bg, player_tex_down, player_tex_up, player_tex_side, zombie_tex, candy_sheet, bonus_candy_tex, power_up_tex, wall_tex, teleport_tex, bb_tex;
        public static SoundEffect bg_music, eat_candy;
        SoundEffectInstance bg_music_instance;

        public SpriteFont font;

        List<String> level_tiles = new List<String>();

        public Teleport teleport_1, teleport_2;

        public static List<Wall> walls = new List<Wall>();
        public static List<Candy> candies = new List<Candy>();
        public static List<Monster> monsters = new List<Monster>();
        public static List<Power_up> power = new List<Power_up>();
        public static List<Teleport> teleports = new List<Teleport>();

        public int offset = 50;
        public int map_origin;

        public virtual void Load(Game1 game_1)
        {
            this.game_1 = game_1;

            start_bg = game_1.Content.Load<Texture2D>(@"Image/start_bg");
            win_bg = game_1.Content.Load<Texture2D>(@"Image/win_bg");
            end_bg = game_1.Content.Load<Texture2D>(@"Image/end_screen");

            player_tex_down = game_1.Content.Load<Texture2D>(@"Image/jumpin_pumpkin");
            player_tex_up = game_1.Content.Load<Texture2D>(@"Image/jumpin_pumpkin_back");
            player_tex_side = game_1.Content.Load<Texture2D>(@"Image/jumpin_pumpkin_side");

            zombie_tex = game_1.Content.Load<Texture2D>(@"Image/zombie_walk");

            candy_sheet = game_1.Content.Load<Texture2D>(@"Image/candy_sheet");
            bonus_candy_tex = game_1.Content.Load<Texture2D>(@"Image/bonus_candy");
            power_up_tex = game_1.Content.Load<Texture2D>(@"Image/power_up_flame");
            teleport_tex = game_1.Content.Load<Texture2D>(@"Image/teleport");

            wall_tex = game_1.Content.Load<Texture2D>(@"Image/wall");

            bb_tex = game_1.Content.Load<Texture2D>(@"Image/Bounding_box");

            bg_music = game_1.Content.Load<SoundEffect>(@"Sound/bg_music");
            eat_candy = game_1.Content.Load<SoundEffect>(@"Sound/eat_candy");

            //Play_bg_music();

            font = game_1.Content.Load<SpriteFont>(@"Font/font");
        }

        public void Unload_Content()
        {
            game_1.Content.Unload();
        }
        public void Load_level(String level_name)
        {
            StreamReader tutorial_level_reader = new StreamReader(level_name);

            while (!tutorial_level_reader.EndOfStream)
                level_tiles.Add(tutorial_level_reader.ReadLine());

            tutorial_level_reader.Close();

            for (int i = 0; i < level_tiles.Count; i++)
            {
                for (int j = 0; j < level_tiles[i].Length; j++)
                {
                    if (level_tiles[i][j] == 'w')
                        walls.Add(new Wall(wall_tex, new Vector2(offset * j, offset * i)));

                    if (level_tiles[i][j] == 'p')
                        player = new Player(player_tex_down, new Vector2(offset * j, offset * i));

                    if (level_tiles[i][j] == 'c')
                        candies.Add(new Candy(candy_sheet, new Vector2(offset * j, offset * i)));

                    if (level_tiles[i][j] == 'b')
                        candies.Add(new Bonus_candy(bonus_candy_tex, new Vector2(offset * j, offset * i)));

                    if (level_tiles[i][j] == 's')
                        power.Add(new Power_up(power_up_tex, new Vector2(offset * j, offset * i)));

                    if (level_tiles[i][j] == 'z')
                    {
                        monsters.Add(new Monster(zombie_tex, new Vector2(offset * j, offset * i)));

                        candies.Add(new Candy(candy_sheet, new Vector2(offset * j, offset * i)));
                    }

                    if (level_tiles[i][j] == '1')
                    {
                        teleport_1 = new Teleport(teleport_tex, new Vector2(offset * j, offset * i)); 

                        teleports.Add(teleport_1);
                    }

                    if (level_tiles[i][j] == '2')
                    {
                        teleport_2 = new Teleport(teleport_tex, new Vector2(offset * j, offset * i)); 

                        teleports.Add(teleport_2);
                    }

                }
            }
        }


        public virtual void Update_level(GameTime game_time)
        {
            player.Update(game_time);

            foreach (Candy c in candies)
            {
                c.Update(game_time);
            }

            foreach (Monster m in monsters)
                m.Update(game_time);

            foreach (Power_up p in power)
                p.Update(game_time);

            foreach (Teleport t in teleports)
                t.Update(game_time);
        }



        public virtual void Draw_level(SpriteBatch sprite_batch)
        {
            foreach (Wall w in walls)
                w.Draw(sprite_batch);

            player.Draw(sprite_batch);

            foreach (Candy c in candies)
                c.Draw(sprite_batch);

            foreach (Monster m in monsters)
                m.Draw(sprite_batch);

            foreach (Power_up p in power)
                p.Draw(sprite_batch);

            foreach (Teleport t in teleports)
                t.Draw(sprite_batch);

            sprite_batch.DrawString(font, "Score: " + Player.score.ToString() + "    Life: " + Player.player_life.ToString() + "  Power up timer: " + Player.powered_duration.ToString(), new Vector2(0, 500), Color.Black);
        }


        private void Play_bg_music()
        {
            bg_music_instance = bg_music.CreateInstance();
            bg_music_instance.IsLooped = true;
            bg_music_instance.Play();
        }
    }
}
