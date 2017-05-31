using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin
{
    public class Start_screen : Content_Manager
    {
        Game1 game_1;

        public Start_screen(Game1 game_1)
        {
            this.game_1 = game_1;

            Load(game_1);
        }

        public void Update()
        {
            Keyboard_input.Update();

            if (Keyboard_input.Key_Click(Keys.Space))
                    game_1.Start_game();

        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(Content_Manager.start_bg, Vector2.Zero, Color.White);
        }
    }
}
