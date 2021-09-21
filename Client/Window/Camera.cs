using SFML.Graphics;
using SFML.System;

namespace Avito.Client.Window
{
    public class Camera : View // IDisposable inherited
    {
        // Transformable object that the camera is pinned to
        // if not set then the camera center is set to Window.Size/2f
        public Transformable? Pin { get; set; }

        public void Update(RenderWindow window)
        {
            Size = Settings.Window.Size;

            if (Pin == null)
                Center = Size / 2f;

            else
                Center = Pin.Position;

            Resize(window);
            window.SetView(this);
        }

        public void Resize(RenderWindow window)
        {
            Vector2f winSize = (Vector2f)window.Size;
            float aspectRatio = winSize.X / winSize.Y;
            Size = new(Settings.Window.Size.Y * aspectRatio, Settings.Window.Size.Y);
        }
    }
}