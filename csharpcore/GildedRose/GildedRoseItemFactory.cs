using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRoseItemFactory
    {
        Dictionary<Func<Item, bool>, Func<Item, GildedRoseItem>> ClassMap;

        // Allow for having more than 1 legendary item.
        private List<string> LegendaryItems;

        public GildedRoseItemFactory()
        {
            // This could be configuration driven.
            LegendaryItems = new List<string> { "Sulfuras, Hand of Ragnaros" };

            ClassMap = new Dictionary<Func<Item, bool>, Func<Item, GildedRoseItem>>
            {
                {
                    m => m.Name.Equals("aged brie", System.StringComparison.CurrentCultureIgnoreCase),
                    (i) => new AgedBrieItem(i)
                },
                {
                    m => LegendaryItems.Any(i => i.Equals(m.Name, System.StringComparison.CurrentCultureIgnoreCase)),
                    (i) => new LegendaryItem(i)
                },
                {
                    m => m.Name.StartsWith("backstage passes", System.StringComparison.CurrentCultureIgnoreCase),
                    (i) => new BackstagePassItem(i)
                },
                {
                    m => m.Name.StartsWith("conjured", System.StringComparison.CurrentCultureIgnoreCase),
                    (i) => new ConjuredItem(i)
                }
            };
        }

        public GildedRoseItem Create(Item item)
        {
            // See what kind of item we have based on it's name.
            var func = ClassMap.FirstOrDefault(e => e.Key(item)).Value;

            // If we didn't match on an item type, it's a standard item.
            return func == null ? new StandardItem(item) : func(item);
        }
    }
}
