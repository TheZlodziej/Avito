using Avito.Client.Scenes;
using Avito.Client.Window;
using SFML.System;
using System;

namespace Avito.Client
{
    public sealed class Game : IDisposable
    {
        private GameWindow Window { get; set; } = new();
        private SceneManager Scenes { get; set; } = new();
        private Clock Clock { get; set; } = new();
        private Time DeltaTime { get; set; } = new();
        private Cursor Cursor { get; set; } = new();
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
            Scenes.ActiveScene.Update(DeltaTime, Window);
            Cursor.Update(Window);
        }
        private void Draw()
        {
            Window.Clear(Settings.Window.ClearColor);
            Scenes.ActiveScene.Draw(Window);
            Cursor.Draw(Window);
            Window.Display();
        }

        public void Dispose()
        {
            Window?.Dispose();
            Window = null!;

            Scenes?.Dispose();
            Scenes = null!;

            Clock?.Dispose();
            Clock = null!;

            Cursor?.Dispose();
            Cursor = null!;
        }
    }
}
