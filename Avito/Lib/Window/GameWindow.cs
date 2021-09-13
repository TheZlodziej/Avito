using SFML.Graphics;
using System;
using SFML.Window;
using GameSettings = Avito.Settings;

namespace Avito.Lib.Window
{
    public class GameWindow : RenderWindow
    {
        public GameWindow() : 
            base(new(GameSettings.UWindowSize.X, GameSettings.UWindowSize.Y), 
                    GameSettings.WindowTitle, 
                    Styles.Default, 
                    GameSettings.WindowSettings)
        {
            AddWindowEvents();
            SetMouseCursorVisible(false);
            SetFramerateLimit(GameSettings.MaxFps);
        }

        private void AddWindowEvents()
        {
            Closed += CloseWindow;
        }

        private void CloseWindow(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
