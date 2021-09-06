using SFML.Graphics;
using System;
using GameAssets = Avito.Assets;

namespace Avito.Lib.Window
{
    public class GameWindow : RenderWindow
    {
        public static uint Width { get; private set; } = GameAssets.WindowWidth;
        public static uint Height { get; private set; } = GameAssets.WindowHeight;
        public static string Title { get; private set; } = GameAssets.WindowTitle;
        public static Color ClearColor { get; private set; } = Color.Red;

        public GameWindow() : base(new(Width, Height), Title)
        {
            AddWindowEvents();
        }

        private void AddWindowEvents()
        {
            Closed += CloseWindow;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }
    }
}
