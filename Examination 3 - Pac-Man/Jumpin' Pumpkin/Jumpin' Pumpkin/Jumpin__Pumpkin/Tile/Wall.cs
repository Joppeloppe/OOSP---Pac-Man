using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jumpin__Pumpkin.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jumpin__Pumpkin.Tile
{
    public class Wall : Game_Object
    {
        public Rectangle wall_bb;
        public Wall(Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = new Vector2(pos.X, pos.Y);

            entity_frame_size = new Point(25, 25);

            layer = 0;

            this.wall_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.Y * scale);
        }
    }
}
