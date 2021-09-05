using SFML.System;

namespace Avito.Lib.Components
{
    class Transform : Component
    {
        public Vector2f Position = new(0f,0f);
        public Vector2f Origin = new(0f,0f);
        public Vector2f Scale = new(1f,1f);
        public float Rotation = 0f;
        public Transform() : base() { }
    }
}
