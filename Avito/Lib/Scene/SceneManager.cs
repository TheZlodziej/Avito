using System;
using System.Collections.Generic;

namespace Avito.Lib.Scene
{
    class SceneManager
    {
        private readonly Dictionary<Type, IScene> _scenes = new();
        public IScene? ActiveScene { get; set; }
        public SceneManager()
        {
            LoadScenes();
            SetScene<GameScene>();
        }
        private void LoadScenes()
        {
            foreach (var type in typeof(SceneManager).Assembly.GetTypes())
            {  
                if (!type.IsInterface && typeof(IScene).IsAssignableFrom(type))
                {
                    var ctor = type.GetConstructor(Array.Empty<Type>());
                    if (ctor == null)
                    {
                        // warning: no constructor
                        Console.Error.WriteLine($"No constructor for type {typeof(IScene).Name}.");
                        continue;
                    }

                    var scene = (IScene)ctor.Invoke(Array.Empty<object>());
                    _scenes.Add(type, scene);
                }
            }
        }
        public void SetScene<T>()
        {
            ActiveScene = _scenes[typeof(T)];

            if (ActiveScene == null)
            {
                throw new Exception("ActiveScene returned null.");
            }
        }
    }
}
