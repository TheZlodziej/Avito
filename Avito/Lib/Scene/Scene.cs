using Avito.Lib.Window;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Scene
{
    public abstract class Scene
    {
        public Camera Camera { get; set; } = new();
        public abstract void Draw(RenderWindow window);
        public virtual void Update(Time deltaTime, RenderWindow window)
        {
            Camera.Update(window);
        }
    }
}
