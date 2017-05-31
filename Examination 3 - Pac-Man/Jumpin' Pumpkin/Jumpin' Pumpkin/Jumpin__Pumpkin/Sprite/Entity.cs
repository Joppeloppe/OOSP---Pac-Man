using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jumpin__Pumpkin.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Jumpin__Pumpkin.Tile;

namespace Jumpin__Pumpkin
{
    public class Entity : Game_Object
    {
        protected int timer_since_last_frame, milliseconds_per_frame;
        protected float speed = 2f;

        protected int push_back = 1;

        protected Rectangle entity_bb;

        protected bool direction_up, direction_left, direction_down, direction_right, direction_none, player_move, player_teleport;

        public Entity (Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            entity_position = new Vector2(pos.X, pos.Y);
            entity_texture = tex;
            entity_frame_size = new Point(entity_frame_size.X, entity_frame_size.Y);

            entity_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);
        }

        public virtual void Update(GameTime game_time)
        {
            Entity_Animation(game_time);
            Collision();
            Entity_Movement();

            entity_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);
        }

        public override void Draw(SpriteBatch sprite_batch)
        {
            //sprite_batch.Draw(Content_Manager.bb_tex, entity_bb, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

            base.Draw(sprite_batch);
        }

        public virtual void Entity_Animation(GameTime game_time)
        {
            timer_since_last_frame += (int)game_time.ElapsedGameTime.TotalMilliseconds;
            if (timer_since_last_frame > milliseconds_per_frame)
            {
                timer_since_last_frame -= milliseconds_per_frame;

                ++entity_frame_current.X;

                if (entity_frame_current.X >= entity_sheet_size.X)
                {
                    entity_frame_current.X = 0;
                }
            }

        }
        public virtual void Entity_Movement()
        {
            if (direction_up)
            {
                direction_left = false;
                direction_down = false;
                direction_right = false;
                direction_none = false;

                entity_position.Y -= speed;
            }

            if (direction_left)
            {
                direction_up = false;
                direction_down = false;
                direction_right = false;
                direction_none = false;

                entity_position.X -= speed;
            }

            if (direction_down)
            {
                direction_up = false;
                direction_left = false;
                direction_right = false;
                direction_none = false;

                entity_position.Y += speed;
            }

            if (direction_right)
            {
                direction_up = false;
                direction_left = false;
                direction_down = false;
                direction_none = false;

                entity_position.X += speed;
            }

            if (direction_none)
            {
                direction_up = false;
                direction_left = false;
                direction_down = false;
                direction_right = false;
            }
        }

        public virtual void Collision()
        {
            foreach (Wall w in Content_Manager.walls)
            {
                if (w.wall_bb.Intersects(entity_bb))
                {
                    if (direction_up)
                    {
                        if (entity_bb.Top < w.wall_bb.Bottom)
                        {
                            entity_position.Y += speed * push_back;
                        }
                    }

                    else if (direction_left)
                    {
                        if (entity_bb.Left < w.wall_bb.Right)
                        {
                            entity_position.X += speed * push_back;
                        }
                    }

                    else if (direction_down)
                    {
                        if (entity_bb.Bottom > w.wall_bb.Top)
                        {
                            entity_position.Y -= speed * push_back;
                        }
                    }

                    else if (direction_right)
                    {
                        if (entity_bb.Right > w.wall_bb.Left)
                        {
                            entity_position.X -= speed * push_back;
                        }
                    }

                    Movement_Stop();
                }
            }

        }
        public void Movement_Stop()
        {
            direction_none = true;

            direction_up = false;
            direction_left = false;
            direction_down = false;
            direction_right = false;
        }
    }
}
