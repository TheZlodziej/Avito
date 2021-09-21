using Avito.Client.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Avito.Client.Scenes
{
    public abstract class Scene: IDisposable
    {
        public Camera Camera { get; set; } = new();

        public virtual void Dispose()
        {
            return;
        }
        public abstract void Draw(RenderWindow window);
        public virtual void Update(Time deltaTime, RenderWindow window)
        {
            Camera.Update(window);
        }
        
    }
}
