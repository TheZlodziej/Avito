using Avito.Lib.Scene;
using Avito.Lib.Window;
using SFML.System;

namespace Avito.Lib.Game
{
    public class Game
    {
        private GameWindow _window = new();
        private SceneManager _scenes = new();
        private Clock _clock = new();
        private Time _deltaTime = new();

        public void Start()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                Update();
                Draw();
            }
        }

        private void Update() 
        {
            _deltaTime = _clock.Restart();
            _scenes.ActiveScene.Update(_deltaTime);
        }
        private void Draw()
        {
            _window.Clear(GameWindow.ClearColor);
            _scenes.ActiveScene.Draw(_window);
            _window.Display();
        }
    }
}
