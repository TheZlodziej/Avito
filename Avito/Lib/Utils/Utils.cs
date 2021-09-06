using SFML.System;

namespace Avito.Lib
{
    public static class Utils
    {
        public static Vector2f HadamarProduct(Vector2f v1, Vector2f v2)
        {
            return new(v1.X * v2.X, v1.Y * v2.Y);
        }
    }
}
