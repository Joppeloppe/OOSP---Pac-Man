using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jumpin__Pumpkin.Sprite
{
    public class Game_Object
    {
        protected Vector2 entity_position, entity_origin, prev_entity_position;

        protected Texture2D entity_texture;

        protected SpriteEffects entity_sprite_fx;

        protected Point entity_frame_size;
        protected Point entity_frame_current;
        protected Point entity_sheet_size;

        protected int scale = 2;
        protected int layer;

        public Game_Object(Texture2D tex, Vector2 pos)
        {
            this.entity_texture = tex;
            this.entity_position = new Vector2(pos.X, pos.Y);
        }

        public virtual void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw
                (entity_texture, entity_position,
                new Rectangle(entity_frame_current.X * entity_frame_size.X, entity_frame_current.Y * entity_frame_size.Y, entity_frame_size.X, entity_frame_size.Y),
                Color.White, 0, entity_origin, scale, entity_sprite_fx, layer);
        }
    }
}
