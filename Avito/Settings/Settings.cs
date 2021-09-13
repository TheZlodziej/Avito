using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace Avito
{
    public static class Settings
    {
        // DIRECTORY
        public static string RootDirectory { get; set; } = Directory.GetCurrentDirectory();
        public static uint MaxFps { get; set; } = 120;

        // WINDOW
        public static class Window
        {
            public static string Title { get; set; } = "Avito";
            public static Vector2f Size { get; set; } = new(720, 520);
            public static Vector2u USize { get; set; } = (Vector2u)Size;
            public static Color ClearColor { get; set; } = Color.Red;
            public static ContextSettings Settings { get; internal set; } = new() { AntialiasingLevel = 8 };
        }

        // HUD
        public static class Hud 
        {
            public static Vector2f ItemsBackgroundSize { get; set; } = new(Window.Size.X * 0.8f, 50f);
            public static Color ItemsBackroundColor { get; set; } = new(0, 0, 0, 100);
            public static Vector2f ItemsBackgroundPosition { get; set; } = new((Window.Size.X - ItemsBackgroundSize.X)/2f, Window.Size.Y - ItemsBackgroundSize.Y);
        }

        public static class Controls
        {
            public static Keyboard.Key MoveLeft { get; set; } = Keyboard.Key.A;
            public static Keyboard.Key MoveUp { get; set; } = Keyboard.Key.W;
            public static Keyboard.Key MoveDown { get; set; } = Keyboard.Key.S;
            public static Keyboard.Key MoveRight { get; set; } = Keyboard.Key.D;
        }

        public static class Player
        {
            public static int DefaultHp { get; set; } = 100;
            public static float Mass { get; set; } = 10f;
        }

        public static class Physics
        {
            public static float FrictionCoeff { get; set; } = 0.998f;
            public static float MoveForce { get; set; } = 10f;
        }
    }
}
