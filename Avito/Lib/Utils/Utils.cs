using SFML.System;
using System;

namespace Avito.Lib
{
    public static class Utils
    {
        public static Vector2f HadamarProduct(Vector2f vec1, Vector2f vec2)
        {
            return new(vec1.X * vec2.X, vec1.Y * vec2.Y);
        }

        public static float Length(Vector2f vec)
        {
            return MathF.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        public static Vector2f Normalize(Vector2f vec)
        {
            var len = Length(vec);

            if (len == 0f)
                return new(0, 0);
            
            return 1f / len * vec;
        }
    }
}
