using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects
{
    public interface IGameObject
    {
        public abstract void Update(Time deltaTime, RenderWindow? window = null);
        public abstract void Draw(RenderWindow window);
    }
}