using System;
using System.Collections.Generic;
using Avito.Lib.GameObjects;

namespace Avito.Lib.Components
{
    class ComponenetManager
    {
        public GameObject _owner;
        private Dictionary<Type, Component> _components = new();

        public ComponenetManager(GameObject owner)
        {
            _owner = owner;
            Add<Transform>();
        }
        public T Add<T>() where T : Component, new()
        {
            if (!_components.ContainsKey(typeof(T)))
            {
                T newComponent = new()
                {
                    Owner = _owner
                };
                
                _components.Add(typeof(T), newComponent);
                return newComponent;
            }

            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            if (_components.ContainsKey(typeof(T)))
            {
                return (T)_components[typeof(T)];
            }

            return null;
        }
    }
}
