using Avito.Lib.Components;
using SFML.System;

namespace Avito.Lib.GameObjects
{
    public abstract class GameObject
    {
        public ComponenetManager Components { get; protected set; }
        public GameObject()
        {
            Components = new(this);
        }
        public virtual void Update(Time deltaTime) { return; }
    }
}
