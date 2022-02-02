using System.Collections.Generic;

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
            // Get the correct instance based on item being processed.
            var gildedRoseItem = ItemFactory.Create(item);

            gildedRoseItem.UpdateItem();
            gildedRoseItem.ValidateProperties();
        }
    }
}
