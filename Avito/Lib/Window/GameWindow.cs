using SFML.Graphics;
using System;

namespace Avito.Lib.Window
{
    public class GameWindow : RenderWindow
    {
        public static int Width { get; private set; } = 720;
        public static int Height { get; private set; } = 540;
        public static string Title { get; private set; } = "Avito";
        public static Color ClearColor { get; private set; } = Color.White;

        public GameWindow() : base(new((uint)Width, (uint)Height), Title)
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
