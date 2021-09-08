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

        // WINDOW
        public static string WindowTitle { get; set; } = "Avito";
        public static uint WindowWidth { get; set; } = 720u;
        public static uint WindowHeight { get; set; } = 520u;
        public static Color WindowClearColor { get; set; } = Color.Red;

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
