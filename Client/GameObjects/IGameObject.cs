using SFML.Graphics;
using SFML.System;
using System;

namespace Avito.Client.GameObjects
{
    public interface IGameObject
    {
        public abstract void Update(Time deltaTime, RenderWindow window);
        public abstract void Draw(RenderWindow window);
    }
}