namespace GildedRoseKata.Items
{
    public abstract class GildedRoseItem
    {
        protected Item Item;

        public int Quality
        {
            get
            {
                return Item.Quality;
            }
        }

        public int Sellin
        {
            get
            {
                return Item.SellIn;
            }
        }

        public GildedRoseItem(Item item)
        {
            Item = item;
        }

        public abstract void UpdateItem();
    }
}
