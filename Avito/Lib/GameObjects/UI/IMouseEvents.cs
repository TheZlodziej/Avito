using SFML.Graphics;

namespace Avito.Lib.GameObjects.UI
{
    public interface IMouseEvents
    {
        public void Click();
        public void MouseEnter();
        public void MouseLeft();
        public bool MouseIsOver(RenderWindow relativeWindow);
    }
}
