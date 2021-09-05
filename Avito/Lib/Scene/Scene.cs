using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Scene
{
    abstract class Scene
    {
        public abstract void Update(Time deltaTime);
        public abstract void Draw(RenderWindow window);
    }
}
