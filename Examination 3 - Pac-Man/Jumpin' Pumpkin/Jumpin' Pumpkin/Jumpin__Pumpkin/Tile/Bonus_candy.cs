using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jumpin__Pumpkin.Tile
{
    public class Bonus_candy : Candy
    {
        public Bonus_candy(Texture2D tex, Vector2 pos) : base (tex, pos)
        {
            this.entity_texture = tex;
            this.entity_position = pos;

            point = 50;
        }
    }
}
