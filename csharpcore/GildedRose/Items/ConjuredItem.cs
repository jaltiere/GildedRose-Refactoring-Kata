namespace GildedRoseKata.Items
{
    public class ConjuredItem : GildedRoseItem
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        public override void UpdateItem()
        {
            // loses value twice as fast as standard item.
            Item.Quality -= 2;
            Item.SellIn--;

            // if it's past the sell date, loses value twice as fast.
            if (Item.SellIn < 0)
            {
                Item.Quality -= 2;
            }
        }
    }
}
