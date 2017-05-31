using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jumpin__Pumpkin.Tile;

namespace Jumpin__Pumpkin
{
    public class Tutorial_screen : Content_Manager
    {
        Game1 game_1;

        public Tutorial_screen(Game1 game_1)
        {
            this.game_1 = game_1;

            Load(game_1);

            Load_level("Tutorial_level.txt");
        }

        public void Update(GameTime game_time)
        {
            Keyboard_input.Update();

            if (Content_Manager.candies.Count == 0)
                game_1.Won_game();

            if (Player.player_life == 0)
                game_1.Lost_game();

            game_1.Window.Title = "Jumpin' Pumpkin        Score:" + Player.score + "  Life:" + Player.player_life + "   Power-up duration:" + Player.powered_duration / 100 + " ";

            Update_level(game_time);
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            Draw_level(sprite_batch);
        }
    }
}
