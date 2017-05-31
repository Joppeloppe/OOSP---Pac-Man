using Jumpin__Pumpkin.Tile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin.Sprite
{
    public class Monster : Entity
    {
        protected int direction_random;

        public Rectangle monster_bb;

        public static Vector2 monster_start_pos;

        protected static Random random = new Random();

        public Monster(Texture2D tex, Vector2 pos)
            : base(tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            entity_frame_size = new Point(25, 35);
            entity_frame_current = new Point(0, 0);
            entity_sheet_size = new Point(4, 1);

            milliseconds_per_frame = 250;

            layer = 1;

            entity_origin = new Vector2(0, 10);

            monster_bb = entity_bb;

            speed = 1.5f;

            direction_right = true;

            monster_start_pos = entity_position;
        }

        public override void Update(GameTime game_time)
        {
            monster_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);

            Collision();

            prev_entity_position = entity_position;

            base.Update(game_time);
        }

        public override void Collision()
        {

            foreach (Wall w in Content_Manager.walls)
                if (w.wall_bb.Intersects(monster_bb))
                {
                    Movement_Stop();

                    entity_position = prev_entity_position;

                    monster_bb.X = (int)prev_entity_position.X;
                    monster_bb.Y = (int)prev_entity_position.Y;

                    direction_random = random.Next(0, 4);

                    if (direction_random == 0)
                        direction_up = true;

                    else if (direction_random == 1)
                        direction_left = true;

                    else if (direction_random == 2)
                        direction_down = true;

                    else if (direction_random == 3)
                        direction_right = true;
                }
        }
    }
}

