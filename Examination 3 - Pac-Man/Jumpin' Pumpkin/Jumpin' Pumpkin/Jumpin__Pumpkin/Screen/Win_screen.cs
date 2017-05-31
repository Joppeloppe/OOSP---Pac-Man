using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin
{
    public class Win_screen : Content_Manager
    {
        Game1 game_1;

        public Win_screen(Game1 game_1)
        {
            this.game_1 = game_1;
        }

        public void Update(GameTime game_time)
        {
            Keyboard_input.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                game_1.Play_game();

            Player.powered_duration = 500;
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(Content_Manager.win_bg, Vector2.Zero, Color.White);
        }
    }
}
