using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Jumpin__Pumpkin.Tile;
using System.Diagnostics;

namespace Jumpin__Pumpkin
{
    enum Screen
    {
        Start_screen,
        Tutorial_screen,
        Play_screen,
        Win_screen,
        Game_over_screen
    }

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sprite_batch;

        public Start_screen start_screen;
        public Tutorial_screen tutorial_screen;
        public Play_screen play_screen;
        public Win_screen win_screen;
        public Game_over_screen game_over_screen;

        Screen current_screen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 650;   
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sprite_batch = new SpriteBatch(GraphicsDevice);

            start_screen = new Start_screen(this);
            current_screen = Screen.Start_screen;

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime game_time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            switch (current_screen)
            {
                case Screen.Start_screen:
                    if (start_screen != null)
                        start_screen.Update();
                    break;

                case Screen.Tutorial_screen:
                    if (tutorial_screen != null)
                        tutorial_screen.Update(game_time);
                    break;

                case Screen.Play_screen:
                    if (play_screen != null)
                        play_screen.Update(game_time);
                    break;

                case Screen.Win_screen:
                    if (win_screen != null)
                        win_screen.Update(game_time);
                    break;

                case Screen.Game_over_screen:
                    if (game_over_screen != null)
                        game_over_screen.Update();
                    break;

            }

            base.Update(game_time);
        }

        protected override void Draw(GameTime game_time)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sprite_batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

            switch (current_screen)
            {
                case Screen.Start_screen:
                    if (start_screen != null)
                        start_screen.Draw(sprite_batch);
                    break;

                case Screen.Tutorial_screen:
                    if (tutorial_screen != null)
                        tutorial_screen.Draw(sprite_batch);
                    break;

                case Screen.Play_screen:
                    if (play_screen != null)
                        play_screen.Draw(sprite_batch);
                    break;

                case Screen.Win_screen:
                    if (win_screen != null)
                        win_screen.Draw(sprite_batch);
                    break;

                case Screen.Game_over_screen:
                    if (game_over_screen != null)
                        game_over_screen.Draw(sprite_batch);
                    break;

            }

            sprite_batch.End();

            base.Draw(game_time);
        }

        public void Start_game()
        {
            tutorial_screen = new Tutorial_screen(this);
            current_screen = Screen.Tutorial_screen;

            start_screen = null;
            play_screen = null;
            game_over_screen = null;
        }

        public void Play_game()
        {
            play_screen = new Play_screen(this);
            current_screen = Screen.Play_screen;

            start_screen = null;
            tutorial_screen = null;
            game_over_screen = null;
        }

        public void Won_game()
        {
            win_screen = new Win_screen(this);
            current_screen = Screen.Win_screen;

            start_screen = null;
            tutorial_screen = null;
            play_screen = null;
            game_over_screen = null;

            Content_Manager.walls.Clear();
            Content_Manager.candies.Clear();
            Content_Manager.monsters.Clear();
            Content_Manager.power.Clear();
            Content_Manager.teleports.Clear();
        }

        public void Lost_game()
        {
            game_over_screen = new Game_over_screen(this);
            current_screen = Screen.Game_over_screen;

            start_screen = null;
            tutorial_screen = null;
            play_screen = null;

            Content_Manager.walls.Clear();
            Content_Manager.candies.Clear();
            Content_Manager.monsters.Clear();
            Content_Manager.power.Clear();
            Content_Manager.teleports.Clear();
        }
    }
}
