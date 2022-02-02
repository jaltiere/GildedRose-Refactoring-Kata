namespace GildedRoseKata.Items
{
    public abstract class GildedRoseItem
    {
        protected Item Item;

        public GildedRoseItem(Item item)
        {
            Item = item;
        }

        public abstract void UpdateItem();

        public void ValidateProperties()
        {
            // Quality can't fall below 0.
            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }

            // Quality can't go above 50.
            if (Item.Quality > 50)
            {
                Item.Quality = 50;
            }
        }
    }
}
