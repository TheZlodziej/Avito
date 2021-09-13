using Avito.Lib.GameObjects.Characters;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Avito.Lib.GameObjects.Items
{
    class Inventory : IGameObject
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
            foreach(var item in Items)
            {
                item.Draw(window);
            }
        }
    }
}
