using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin
{
    public class Game_over_screen: Content_Manager
    {
        Game1 game_1;

        public Game_over_screen(Game1 game_1)
        {
            this.game_1 = game_1;
        }

        public void Update()
        {
            Keyboard_input.Update();

            Player.score = 0;
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(Content_Manager.end_bg, Vector2.Zero, Color.White);
        }
    }
}
