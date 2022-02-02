using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(15, 10, 14, 9)]
        [InlineData(50, 10, 49, 9)]
        public void ShouldUpdateQualityAndSellinForStandardItem(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "some standard item";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(25, -1, 23, -2)]
        [InlineData(10, -5, 8, -6)]
        [InlineData(2, -1, 0, -2)]
        [InlineData(2, 0, 0, -1)]
        public void ShouldDegradeQualityTwiceAsFastForStandardItemAfterSellDate(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "some standard item";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 0, 0, -1)]
        [InlineData(0, -1, 0, -2)]
        [InlineData(1, -1, 0, -2)]
        [InlineData(2, -1, 0, -2)]
        public void ShouldNeverTakeQualityToNegative(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "some standard item";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 0, 2, -1)]
        [InlineData(10, 10, 11, 9)]
        public void ShouldHandleAgedBrieQuality(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Aged Brie";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(50, 5, 50, 4)]
        [InlineData(49, 10, 50, 9)]
        public void ShouldHandleBrieQualityCapAt50(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Aged Brie";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(48, 0, 50, -1)]
        [InlineData(49, 0, 50, -1)]
        [InlineData(20, -1, 22, -2)]
        [InlineData(30, -5, 32, -6)]
        public void ShoudlHandleBrieWhenNegativeSellin(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Aged Brie";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(10, 15, 11, 14)]
        [InlineData(10, 10, 12, 9)]
        [InlineData(10, 5, 13, 4)]
        public void ShouldHandleBackstagePassesQuality(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(10, 0, 0, -1)]
        [InlineData(10, -1, 0, -2)]
        public void ShouldHaveZeroQualityForBackstagePassesAfterSellDate(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(49, 15, 50, 14)]
        [InlineData(49, 10, 50, 9)]
        [InlineData(49, 5, 50, 4)]
        public void ShouldHandleBackstagePassesQualityCapAt50(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(50, 5, 50, 5)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(25, -1, 25, -1)]
        [InlineData(0, 12, 0, 12)]
        public void ShouldNotAlterQualityOrSellinForSulfuras(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Sulfuras, Hand of Ragnaros";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(15, 10, 13, 9)]
        [InlineData(50, 10, 48, 9)]
        public void ShouldUpdateQualityAndSellinForConjuredItem(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Conjured Mana Cake";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(25, -1, 21, -2)]
        [InlineData(10, -5, 6, -6)]
        [InlineData(4, -1, 0, -2)]
        [InlineData(4, 0, 0, -1)]
        public void ShouldDegradeQualityTwiceAsFastForConjuredItemAfterSellDate(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Conjured Mana Cake";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 0, 0, -1)]
        [InlineData(0, -1, 0, -2)]
        [InlineData(1, -1, 0, -2)]
        [InlineData(2, -1, 0, -2)]
        [InlineData(3, -1, 0, -2)]
        [InlineData(4, -1, 0, -2)]
        public void ShouldNeverTakeQualityToNegativeForConjured(int quality, int sellin, int expectedQuality, int expectedSellin)
        {
            var itemName = "Conjured Mana Cake";

            var Items = new List<Item> { new Item { Name = itemName, SellIn = sellin, Quality = quality } };
            GildedRose app = new(Items);

            app.UpdateQuality();
            Assert.Equal(itemName, Items[0].Name);
            Assert.Equal(expectedSellin, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}


