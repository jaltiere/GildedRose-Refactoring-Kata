namespace GildedRoseKata.Items
{
    public class StandardItem : GildedRoseItem
    {
        public StandardItem(Item item) : base(item)
        {
        }

        public override void UpdateItem()
        {
            Item.Quality -= 1;
            Item.SellIn -= 1;

            // if it's past the sell date, loses value twice as fast.
            if (Item.SellIn < 0)
            {
                Item.Quality -= 1;
            }
        }
    }
}
