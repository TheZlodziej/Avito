using SFML.Graphics;

namespace Avito.Lib.GameObjects.UI
{
    public interface IMouseEvents
    {
        public void Click();
        public void Hover();
        public bool MouseIsOver(RenderWindow relativeWindow);
    }
}
