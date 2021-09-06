using Avito.Lib.Scene;
using Avito.Lib.Window;
using SFML.System;

namespace Avito.Lib.Game
{
    public class Game
    {
        private GameWindow Window { get; set; } = new();
        private SceneManager Scenes { get; set; } = new();
        private Clock Clock { get; set; } = new();
        private Time DeltaTime { get; set; } = new();

        public void Start()
        {
            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Update();
                Draw();
            }
        }

        private void Update() 
        {
            DeltaTime = Clock.Restart();
            Scenes.ActiveScene.Update(DeltaTime);
        }
        private void Draw()
        {
            Window.Clear(GameWindow.ClearColor);
            Scenes.ActiveScene.Draw(Window);
            Window.Display();
        }
    }
}
