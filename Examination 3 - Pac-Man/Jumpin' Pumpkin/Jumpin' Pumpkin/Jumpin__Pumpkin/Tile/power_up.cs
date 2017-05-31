using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin.Tile
{
    public class Power_up : Candy
    {
        public Rectangle power_up_bb;
        public Power_up (Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            entity_frame_size = new Point(25, 25);
            entity_frame_current = new Point(0, 0);
            entity_sheet_size = new Point(3, 1);

            milliseconds_per_frame = 200;

            point = 250;

            this.power_up_bb = entity_bb;
        }

        public override void Update(GameTime game_time)
        {
            power_up_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);

            base.Update(game_time);
        }
    }
}
