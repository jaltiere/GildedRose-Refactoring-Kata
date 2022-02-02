using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        GildedRoseItemFactory ItemFactory;
        IList<Item> Items;
        

        public GildedRose(IList<Item> itemList)
        {
            Items = itemList;

            ItemFactory = new GildedRoseItemFactory();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        void UpdateItem(Item item)
        {
            var gildedRoseItem = ItemFactory.Create(item);
            gildedRoseItem.UpdateItem();

            // Quality can't fall below 0.
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            // Quality can't go above 50.
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}
