using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Avito.Client.GameObjects.Items
{
    public class Inventory : IGameObject
    {
        public List<Item> Items { get; set; } = new();

        public void Update(Time deltaTime, RenderWindow window)
        {
            foreach (var item in Items)
            {
                item.Update(deltaTime, window);
            }
        }

        public void Draw(RenderWindow window)
        {
            foreach (var item in Items)
            {
                item.Draw(window);
            }
        }

        public void Dispose()
        {
            foreach (var item in Items)
            {
                item?.Dispose();
            }
        }
    }
}
