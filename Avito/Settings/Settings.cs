using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace Avito
{
    public static class Settings
    {
        // DIRECTORY
        public static string RootDirectory { get; } = Directory.GetCurrentDirectory();
        public static uint MaxFps { get; } = 120;

        // WINDOW
        public static class Window
        {
            public static string Title { get; } = "Avito";
            public static Vector2f Size { get; } = new(720, 520);
            public static Vector2u USize { get; } = (Vector2u)Size;
            public static Color ClearColor { get; } = new(100, 100, 100);
            public static ContextSettings Settings { get; } = new() { AntialiasingLevel = 8 };
        }

        // HUD
        public static class Hud
        {
            public static Vector2f ItemSize { get; } = new(50, 50);
            public static Vector2f ItemsBackgroundSize { get; } = new(ItemSize.X * Player.Inventory.Size, ItemSize.Y);
            public static Color ItemsBackroundColor { get; } = new(0, 0, 0, 100);
            public static Vector2f ItemsBackgroundPosition { get; } = new((Window.Size.X - ItemsBackgroundSize.X) / 2f, Window.Size.Y - ItemsBackgroundSize.Y);
            public static Color HpBarColor { get; } = new(230, 0, 38, 200);
            public static Vector2f HpBarPosition { get; } = new(25, 25);
            public static Vector2f HpBarSize { get; } = new(5, 30); // size of 1 hp (it's getting multiplied)
            public static Color HpBarBackgroundColor { get; } = new(0, 0, 0, 100);
        }

        public static class Controls
        {
            public static Keyboard.Key MoveLeft { get; } = Keyboard.Key.A;
            public static Keyboard.Key MoveUp { get; } = Keyboard.Key.W;
            public static Keyboard.Key MoveDown { get; } = Keyboard.Key.S;
            public static Keyboard.Key MoveRight { get; } = Keyboard.Key.D;
        }

        public static class Player
        {
            public static int DefaultHp { get; } = 50;
            public static float Mass { get; } = 10f;

            public static class Inventory
            {
                public static int Size { get; } = 9;
            }
        }

        public static class Physics
        {
            public static float FrictionCoeff { get; } = 0.998f;
            public static float MoveForce { get; } = 10f;
        }
    }
}
