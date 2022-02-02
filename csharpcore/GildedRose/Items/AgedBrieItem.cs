namespace GildedRoseKata.Items
{
    public class AgedBrieItem : GildedRoseItem
    {
        public AgedBrieItem(Item item) : base(item)
        {
        }

        public override void UpdateItem()
        {
            Item.Quality++;
            Item.SellIn--;

            // If we pass the sell date quality increases twice as fast.
            if (Item.SellIn < 0)
            {
                Item.Quality++;
            }
        }
    }
}
