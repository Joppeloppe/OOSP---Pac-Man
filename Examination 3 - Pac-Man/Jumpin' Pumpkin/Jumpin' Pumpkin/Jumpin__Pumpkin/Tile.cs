using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin
{
    public class Tile
    {
        Vector2 tile_pos;

        Texture2D tile_tex;

        Rectangle tile_tex_rec = new Rectangle(0, 15, 25, 25);

        public Tile(Texture2D tile_tex, Vector2 tile_pos)
        {
            this.tile_pos = new Vector2((int)tile_pos.X, (int)tile_pos.Y);
            this.tile_tex = tile_tex;
        }

        public void Update(GameTime game_time)
        {

        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(tile_tex, tile_pos, tile_tex_rec, Color.White);
        }
    }
}
