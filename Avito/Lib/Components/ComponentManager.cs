using System;
using System.Collections.Generic;
using Avito.Lib.GameObjects;

namespace Avito.Lib.Components
{
    public class ComponenetManager
    {
        public IGameObject Owner { get; private set; }
        private Dictionary<Type, IComponent> Components { get; set; } = new();
        public ComponenetManager(IGameObject owner)
        {
            Owner = owner;
        }
        public T Add<T>() where T : IComponent, new()
        {
            if (!Components.ContainsKey(typeof(T)))
                Components.Add(typeof(T), new T());

            return GetComponent<T>();
        }
        public T GetComponent<T>() where T : IComponent
        {
            return (T)Components[typeof(T)];
        }
    }
}
