using SFML.System;
using System;

namespace Avito.Lib
{
    public static class Utils
    {
        public static Vector2f HadamarProductVec2(Vector2f vec1, Vector2f vec2)
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
    }
}
