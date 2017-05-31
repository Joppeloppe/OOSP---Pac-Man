using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Jumpin__Pumpkin
{
    static class Keyboard_input
    {
        public static KeyboardState keyboard_state, old_keyboard_state = Keyboard.GetState();

        public static bool Key_Click(Keys key)
        {
            return keyboard_state.IsKeyUp(key) && old_keyboard_state.IsKeyDown(key);
        }

        public static void Update()
        {
            old_keyboard_state = keyboard_state;
            keyboard_state = Keyboard.GetState();
        }
    }
}
