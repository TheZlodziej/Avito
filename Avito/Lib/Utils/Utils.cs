using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Text;

namespace Avito.Lib
{
    public static class Utils
    {

        public static Vector2f HadamarProductDivisionVec2f(Vector2f vec1, Vector2f vec2)
        {
            return new(vec1.X / vec2.X, vec1.Y / vec2.Y);
        }

        public static Vector2f HadamarProductMultiplicationVec2(Vector2f vec1, Vector2f vec2)
        {
            return new(vec1.X * vec2.X, vec1.Y * vec2.Y);
        }

        public static float LengthVec2(Vector2f vec)
        {
            return MathF.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        public static Vector2f NormalizeVec2(Vector2f vec)
        {
            var len = LengthVec2(vec);

            if (len == 0f)
                return new(0, 0);

            return 1f / len * vec;
        }

        public static Vector2f ClampVec2(Vector2f vec, float min, float max)
        {
            return new(Math.Clamp(vec.X, min, max), Math.Clamp(vec.Y, min, max));
        }

        public static Vector2f GetSpriteSize(Sprite sprite)
        {
            var bounds = sprite.GetGlobalBounds();
            return new(bounds.Left + bounds.Width, bounds.Top + bounds.Height);
        }

        public static float RadToDeg(float rad)
        {
            return 180f / MathF.PI * rad;
        }

        public static float DegToRad(float deg)
        {
            return MathF.PI / 180f * deg;
        }

        public static Vector2f CursorCoords(RenderWindow window)
        {
            return window.MapPixelToCoords(Mouse.GetPosition(window));
        }

        public static Vector2f GetTextSize(Text text)
        {
            var bounds = text.GetGlobalBounds();
            return new(bounds.Width + bounds.Left, bounds.Height + bounds.Top);
        }

        public static string ToUTF8(string str)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(str));
        }
    }
}
