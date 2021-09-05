using Avito.Lib.Components;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects
{
    abstract class GameObject
    {
        public ComponenetManager Components;

        public GameObject()
        {
            Components = new(this);
        }

        public abstract void Draw(RenderWindow window);
        public abstract void Update(Time deltaTime);
    }

}
