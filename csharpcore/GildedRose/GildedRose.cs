using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        // Allow for having more than 1 legendary item.
        private List<string> LegendaryItems;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            LegendaryItems = new List<string> { "Sulfuras, Hand of Ragnaros" };
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
            var itemType = GetItemType(item.Name);
            switch (itemType)
            {
                case ItemType.AGEDBRIE:
                    ProcessAgedBrie(item);
                    break;
                case ItemType.BACKSTAGEPASS:
                    ProcessBackstagePasses(item);
                    break;
                case ItemType.CONJURED:
                    ProcessConjured(item);
                    break;
                case ItemType.LEGENDARY:
                    ProcessLegendary(item);
                    break;
                default:
                    ProcessStandardItem(item);
                    break;
            }

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

        void ProcessAgedBrie(Item item)
        {
            item.Quality++;
            item.SellIn--;

            // If we pass the sell date quality increases twice as fast.
            if (item.SellIn < 0)
            {
                item.Quality++;
            }
        }

        void ProcessBackstagePasses(Item item)
        {
            item.Quality++;
            item.SellIn--;

            // Quality goes up the closer to the event we get.
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            // If we pass the sell date quality becomes 0.
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        void ProcessConjured(Item item)
        {
            // loses value twice as fast as standard item.
            item.Quality -= 2;
            item.SellIn--;

            // if it's past the sell date, loses value twice as fast.
            if (item.SellIn < 0)
            {
                item.Quality -= 2;
            }
        }

        void ProcessLegendary(Item item)
        {
            // placeholder, nothing gets changed in this case today.
        }

        void ProcessStandardItem(Item item)
        {
            item.Quality -= 1;
            item.SellIn -= 1;

            // if it's past the sell date, loses value twice as fast.
            if (item.SellIn < 0)
            {
                item.Quality -= 1;
            }
        }

        ItemType GetItemType(string name)
        {
            if (IsConjured(name))
            {
                return ItemType.CONJURED;
            }
            else if (IsLegendary(name))
            {
                return ItemType.LEGENDARY;
            }
            else if (IsBackstagePass(name))
            {
                return ItemType.BACKSTAGEPASS;
            }
            else if (isAgedBrie(name))
            {
                return ItemType.AGEDBRIE;
            }

            return ItemType.STANDARD;
        }

        // Any item that starts with "conjured" is a conjured item.
        bool IsConjured(string name) => name.StartsWith("conjured", System.StringComparison.CurrentCultureIgnoreCase);

        // The legendary items are defined in the constructor.
        bool IsLegendary(string name) => LegendaryItems.Any(i => i.Equals(name, System.StringComparison.CurrentCultureIgnoreCase));

        // Took the libery of expanding this so we coudld have backstage passes to more than 1 event.
        bool IsBackstagePass(string name) => name.StartsWith("backstage passes", System.StringComparison.CurrentCultureIgnoreCase);

        // Specific item type
        bool isAgedBrie(string name) => name.Equals("aged brie", System.StringComparison.CurrentCultureIgnoreCase);
    }

    public enum ItemType
    {
        AGEDBRIE = 0,
        BACKSTAGEPASS = 1,
        CONJURED = 2,
        LEGENDARY = 3,
        STANDARD = 4
    }
}
