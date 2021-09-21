using SFML.Graphics;
using SFML.Window;

namespace Avito.Client.GameObjects.UI
{
    public abstract class MouseEvents
    {
        protected abstract void OnClick();
        protected abstract void MouseEnter();
        protected abstract void MouseLeft();
        protected abstract bool MouseIsOver(RenderWindow relativeWindow);
        protected virtual void MouseEventsHandler(RenderWindow relativeWindow)
        {
            if (MouseIsOver(relativeWindow))
            {
                MouseEnter();

                if (Mouse.IsButtonPressed(Settings.Controls.Mouse.Confirm))
                {
                    OnClick();
                }
            }
            else
            {
                MouseLeft();
            }
        }
    }
}
