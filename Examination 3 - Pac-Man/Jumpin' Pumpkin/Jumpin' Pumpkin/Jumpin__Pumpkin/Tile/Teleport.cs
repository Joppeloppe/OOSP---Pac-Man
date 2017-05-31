using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin.Tile
{
    public class Teleport : Entity
    {
        public Rectangle teleport_bb;

        public Vector2 teleport_position;

        public Teleport (Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            entity_frame_size = new Point(25, 25);

            layer = 0;

            teleport_bb = entity_bb;

            teleport_position = entity_position;
        }

        public override void Update(GameTime game_time)
        {
            teleport_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);

            base.Update(game_time);
        }
    }
}
