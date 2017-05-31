using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jumpin__Pumpkin.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumpin__Pumpkin.Tile
{
    public class Candy : Entity
    {
        public Rectangle candy_bb;

        public int point;
        public Candy(Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            entity_frame_size = new Point(25, 25);
            entity_frame_current = new Point(0, 0);
            entity_sheet_size = new Point(8, 1);

            milliseconds_per_frame = 250;

            layer = 0;

            candy_bb = entity_bb;

            point = 10;
        }

        public override void Update(GameTime game_time)
        {
            candy_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);

            base.Update(game_time);
        }
    }
}
