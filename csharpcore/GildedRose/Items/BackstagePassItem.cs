namespace GildedRoseKata.Items
{
    public class BackstagePassItem : GildedRoseItem
    {
        public BackstagePassItem(Item item) : base(item)
        {
        }

        public override void UpdateItem()
        {
            Item.Quality++;
            Item.SellIn--;

            // Quality goes up the closer to the event we get.
            if (Item.SellIn < 11)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality++;
                }
            }

            if (Item.SellIn < 6)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality++;
                }
            }

            // If we pass the sell date quality becomes 0.
            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
        }
    }
}
