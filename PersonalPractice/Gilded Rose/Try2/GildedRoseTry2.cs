using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PersonalPractice.Gilded_Rose.Try2
{
    [TestClass]
    public class GildedRoseTry2
    {
        [TestMethod]
        public void ShouldDecreaseSellinByOne()
        {
            // arrange
            InventorySystem inventorySystem = new InventorySystem();
            Item item = new Item
            {
                SellIn = 10
            };
            inventorySystem.Items.Add(item);

            // act
            inventorySystem.Reconcile();

            // assert
            item.SellIn.Should().Be(9);
        }

        [TestMethod]
        public void ShouldDecreaseQualityByOne()
        {
            // arrange
            InventorySystem inventorySystem = new InventorySystem();
            Item item = new Item
            {
                Quality = 9,
                SellIn = 1
            };
            inventorySystem.Items.Add(item);

            // act
            inventorySystem.Reconcile();

            // assert
            item.Quality.Should().Be(8);
        }

        [TestMethod]
        public void ShouldDecreaseQualityByTwoWhenPastSellIn()
        {
            // arrange
            InventorySystem inventorySystem = new InventorySystem();
            Item item = new Item
            {
                Quality = 10,
                SellIn = 0
            };
            inventorySystem.Items.Add(item);

            // act
            inventorySystem.Reconcile();

            // assert
            item.Quality.Should().Be(8);
        }

        [TestMethod]
        public void ShouldNeverHaveNegativeQuality()
        {
            // arrange
            InventorySystem inventorySystem = new InventorySystem();
            Item item = new Item
            {
                Quality = 0,
                SellIn = 1
            };
            inventorySystem.Items.Add(item);

            // act
            inventorySystem.Reconcile();

            // assert
            item.Quality.Should().Be(0);
        }


        [TestMethod]
        public void ShouldDecreaseQualityByTwoWhenPastSellIn5()
        {
            // arrange
            InventorySystem inventorySystem = new InventorySystem();
            Item item = new Item
            {
                Quality = 20,
                SellIn = 0
            };
            inventorySystem.Items.Add(item);

            // act
            inventorySystem.Reconcile();
            inventorySystem.Reconcile();

            // assert
            item.Quality.Should().Be(16);
        }

        private class Item
        {
            public int SellIn { get; set; }
            public int Quality { get; set; }
        }

        private class InventorySystem
        {
            public List<Item> Items { get; set; }

            public InventorySystem()
            {
                Items = new List<Item>();
            }

            public void Reconcile()
            {
                Item item = Items[0];

                AdjustQuality(item);

                item.SellIn -= 1;
            }

            private static void AdjustQuality(Item item)
            {
                item.Quality -= 1;

                if (item.SellIn <= 0)
                {
                    item.Quality -= 1;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
