using SFML.Graphics;
using System;

using GameSettings = Avito.Settings;

namespace Avito.Lib.Window
{
    public class GameWindow : RenderWindow
    {
        public static uint Width { get; private set; } = GameSettings.WindowWidth;
        public static uint Height { get; private set; } = GameSettings.WindowHeight;
        public static string Title { get; private set; } = GameSettings.WindowTitle;
        public static Color ClearColor { get; private set; } = GameSettings.WindowClearColor;

        public GameWindow() : base(new(Width, Height), Title)
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
