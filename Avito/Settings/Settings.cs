using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.IO;
using SfMouse = SFML.Window.Mouse;

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

        public static class Input
        {
            public static Keyboard.Key CapitalizeKey { get; } = Keyboard.Key.LShift;
            public static Keyboard.Key RemoveLetterKey { get; } = Keyboard.Key.Backspace;
            public static Dictionary<Keyboard.Key, string> AvailableKeys { get; } = new() 
            {
                [Keyboard.Key.A] = "a",
                [Keyboard.Key.B] = "b",
                [Keyboard.Key.C] = "c",
                [Keyboard.Key.D] = "d",
                [Keyboard.Key.E] = "e",
                [Keyboard.Key.F] = "f",
                [Keyboard.Key.G] = "g",
                [Keyboard.Key.H] = "h",
                [Keyboard.Key.I] = "i",
                [Keyboard.Key.J] = "j",
                [Keyboard.Key.K] = "k",
                [Keyboard.Key.L] = "l",
                [Keyboard.Key.M] = "m",
                [Keyboard.Key.N] = "n",
                [Keyboard.Key.O] = "o",
                [Keyboard.Key.P] = "p",
                [Keyboard.Key.Q] = "q",
                [Keyboard.Key.R] = "r",
                [Keyboard.Key.S] = "s",
                [Keyboard.Key.T] = "t",
                [Keyboard.Key.U] = "u",
                [Keyboard.Key.W] = "w",
                [Keyboard.Key.X] = "x",
                [Keyboard.Key.V] = "v",
                [Keyboard.Key.Y] = "y",
                [Keyboard.Key.Z] = "z",
                [Keyboard.Key.Num0] = "0",
                [Keyboard.Key.Num1] = "1",
                [Keyboard.Key.Num2] = "2",
                [Keyboard.Key.Num3] = "3",
                [Keyboard.Key.Num4] = "4",
                [Keyboard.Key.Num5] = "5",
                [Keyboard.Key.Num6] = "6",
                [Keyboard.Key.Num7] = "7",
                [Keyboard.Key.Num8] = "8",
                [Keyboard.Key.Num9] = "9",
                [Keyboard.Key.Space] = " "
            };
            public static Color BackgroundColor { get; } = new(255, 255, 255);
            public static Color TextColor { get; } = new(0, 0, 0);
            public static Color ActiveBackgroundColor { get; } = new(200, 200, 200);
        }

        public static class Controls
        {
            public static class Mouse
            {
                public static SfMouse.Button Confirm { get; } = SfMouse.Button.Left;
            }

            public static class Movement 
            {
                public static Keyboard.Key Left { get; } = Keyboard.Key.A;
                public static Keyboard.Key Up { get; } = Keyboard.Key.W;
                public static Keyboard.Key Down { get; } = Keyboard.Key.S;
                public static Keyboard.Key Right { get; } = Keyboard.Key.D;
            }
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
