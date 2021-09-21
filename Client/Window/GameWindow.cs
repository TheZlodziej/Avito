using SFML.Graphics;
using SFML.Window;
using System;
using GameSettings = Avito.Settings;

namespace Avito.Client.Window
{
    public class GameWindow : RenderWindow
    {
        public GameWindow() :
            base(new(GameSettings.Window.USize.X, GameSettings.Window.USize.Y),
                    GameSettings.Window.Title,
                    Styles.Default,
                    GameSettings.Window.Settings)
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
