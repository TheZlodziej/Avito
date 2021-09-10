using System;
using System.Collections.Generic;

namespace Avito.Lib.Scene
{
    class SceneManager
    {
        private readonly Dictionary<Type, Scene> _scenes = new();
        public Scene ActiveScene { get; set; }

        public SceneManager() : this(typeof(GameScene)) { }

        public SceneManager(Type defaultScene)
        {
            LoadScenes();
            ActiveScene = _scenes[defaultScene];
        }
        private void LoadScenes()
        {
            foreach (var type in typeof(SceneManager).Assembly.GetTypes())
            {  
                if (!type.IsAbstract && type.IsSubclassOf(typeof(Scene)))
                {
                    var ctor = type.GetConstructor(Array.Empty<Type>());
                    if (ctor == null)
                    {
                        // warning: no constructor
                        Console.Error.WriteLine($"No constructor for type {typeof(Scene).Name}.");
                        continue;
                    }

                    var scene = (Scene)ctor.Invoke(Array.Empty<object>());
                    _scenes.Add(type, scene);
                }
            }
        }
        public void SetScene<T>()
        {
            ActiveScene = _scenes[typeof(T)];

            if (ActiveScene == null)
                throw new Exception("ActiveScene returned null.");
        }
    }
}
