using SFML.Graphics;
using SFML.System;

namespace Avito.Client.GameObjects.UI
{
    public abstract class Ui : MouseEvents, IGameObject
    {
        public abstract Vector2f Position { get; set; }
        public virtual void Dispose() { }
        public abstract void Draw(RenderWindow window);
        public abstract void Update(Time deltaTime, RenderWindow window);
    }
}
