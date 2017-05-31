using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jumpin__Pumpkin.Sprite;
using Jumpin__Pumpkin.Tile;
using System.Diagnostics;

namespace Jumpin__Pumpkin
{ 
    public class Player : Entity

    {
        public Rectangle player_bb;

        public static int player_life = 3;
        public static int score, elapsed_time;
        public static int powered_duration, teleport_cooldown = 500;
        public static int time_duration = 2;

        Vector2 start_pos;

        public bool powered_player;
        public Player(Texture2D tex, Vector2 pos) : base  (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            entity_frame_size = new Point(25, 25);
            entity_frame_current = new Point(0, 0);
            entity_sheet_size = new Point(6, 1);
                
            milliseconds_per_frame = 75;

            layer = 1;

            player_bb = entity_bb;

            start_pos = entity_position;
        }

        public override void Update(GameTime game_time)
        {
            player_bb = new Rectangle((int)entity_position.X, (int)entity_position.Y, entity_frame_size.X * scale, entity_frame_size.X * scale);

            Player_Movement_Input();
            Collision();
            Timer(game_time);

            base.Update(game_time);
        }


        public override void Draw(SpriteBatch sprite_batch)
        {
            if (direction_up)
                entity_texture = Content_Manager.player_tex_up;

            if (direction_left || direction_right)
                entity_texture = Content_Manager.player_tex_side;

            if (direction_down)
                entity_texture = Content_Manager.player_tex_down;

            base.Draw(sprite_batch);
        }

        public override void Entity_Movement()
        {
            Player_Movement_Input();

            base.Entity_Movement();
        }

        private void Player_Movement_Input()
        {
                if (Keyboard_input.Key_Click(Keys.W))
                {
                    direction_up = true;
                    direction_left = false;
                    direction_down = false;
                    direction_right = false;
                    direction_none = false;

                    entity_sprite_fx = SpriteEffects.None;
                }

                if (Keyboard_input.Key_Click(Keys.A))
                {
                    direction_up = false;
                    direction_left = true;
                    direction_down = false;
                    direction_right = false;
                    direction_none = false;

                    entity_sprite_fx = SpriteEffects.FlipHorizontally;
                }

                if (Keyboard_input.Key_Click(Keys.S))
                {
                    direction_up = false;
                    direction_left = false;
                    direction_down = true;
                    direction_right = false;
                    direction_none = false;

                    entity_sprite_fx = SpriteEffects.None;
                }

                if (Keyboard_input.Key_Click(Keys.D))
                {
                    direction_up = false;
                    direction_left = false;
                    direction_down = false;
                    direction_right = true;
                    direction_none = false;

                    entity_sprite_fx = SpriteEffects.None;
                }
        }

        public override void Collision()
        {
            foreach (Candy c in Content_Manager.candies)
                if (c.candy_bb.Contains(player_bb))
                {
                    Content_Manager.candies.Remove(c);

                    Content_Manager.eat_candy.Play();

                    score += c.point;

                    break;
                }

            foreach (Power_up p in Content_Manager.power)
                if (p.power_up_bb.Intersects(player_bb))
                {
                    Content_Manager.power.Remove(p);

                    Content_Manager.eat_candy.Play();

                    player_life += 1;

                    powered_duration = 500;

                    score += p.point;

                    powered_player = true;

                    break;
                }

            foreach (Monster m in Content_Manager.monsters)
            {
                if (m.monster_bb.Intersects(player_bb) && !powered_player)
                {
                    entity_position = start_pos;

                    Content_Manager.eat_candy.Play();

                    player_life -= 1;

                    Movement_Stop();
                }

                if (m.monster_bb.Intersects(player_bb) && powered_player)
                {
                    Content_Manager.monsters.Remove(m);

                    break;
                }
                
            }

            base.Collision();
        }
        private void Timer(GameTime game_time)
        {
            if (powered_player)
            {
                elapsed_time += (int)game_time.ElapsedGameTime.TotalMilliseconds;

                if (elapsed_time >= time_duration)
                {
                    --powered_duration;

                    elapsed_time -= time_duration;
                }

            }

            if (powered_duration == 0)
            {
                powered_player = false;

                powered_duration = 500;
            }

            if (player_teleport)
            {
                elapsed_time += (int)game_time.ElapsedGameTime.TotalMilliseconds;

                if (elapsed_time >= time_duration)
                {
                    --teleport_cooldown;

                    elapsed_time -= time_duration;
                }
            }

        }

        public void Teleport_player()
        {
            foreach (Teleport t in Content_Manager.teleports)
                if (t.teleport_bb.Intersects(player_bb))
                {
                    player_teleport = true;

                    entity_position = t.teleport_position;
                }
        }

    }
}
