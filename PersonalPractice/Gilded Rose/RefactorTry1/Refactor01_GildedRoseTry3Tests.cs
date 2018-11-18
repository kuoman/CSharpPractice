using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Gilded_Rose.RefactorTry1
{
    [TestClass]
    public class Refactor01_GildedRoseTry3Tests
    {
        [TestMethod]
        public void ShouldDegradeInQuality()
        {
            // arrange
            Item item = new CommonItem(10, 9, string.Empty);

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(9);
        }

        [TestMethod]
        public void ShouldDecreaseSellBy()
        {
            // arrange
            Item item = new CommonItem(18, 10, string.Empty);

            // act
            item.Process();

            // assert
            item.GetSellBy.Should().Be(9);
        }

        [TestMethod]
        public void ShouldDecreaseTwiceAsFastIfSellByIsPast()
        {
            // arrange
            Item item = new CommonItem(18, 0, string.Empty);

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(16);
        }

        [TestMethod]
        public void QualityCanNeverGoNegative()
        {
            // arrange
            Item item = new Item(0, 1, string.Empty);

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(0);
        }

        [TestMethod]
        public void ShouldAgeBrieUp()
        {
            // arrange
            Item item = new AgedItem(0, 1, "Aged Brie");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(1);
        }

        [TestMethod]
        public void ShouldSulfurasShouldNotChange()
        {
            // arrange
            Item item = new LegendaryItem(10, 1, "Sulfuras");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(10);
            item.GetSellBy.Should().Be(1);
        }

        [TestMethod]
        public void ShouldDecreaseConcertPassesSellBy()
        {
            // arrange
            Item item = new BackstageItem(10, 9, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetSellBy.Should().Be(8);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQuality()
        {
            // arrange
            Item item = new BackstageItem(10, 12, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(11);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQualityBy2IfTenToSixDays()
        {
            // arrange
            Item item = new BackstageItem(10, 10, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(12);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQualityBy2IfFiveToZeroDays()
        {
            // arrange
            Item item = new BackstageItem(10, 5, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(13);
        }

        [TestMethod]
        public void ShouldZeroConcertPassesQualityZeroDays()
        {
            // arrange
            Item item = new BackstageItem(10, 0, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(0);
        }


        [TestMethod]
        public void ShouldDecreaseConjuredItemsTwiceAsFast()
        {
            // arrange
            Item item = new ConjuredItem(10, 10, "Conjured");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(8);
        }
    }

    public class LegendaryItem : Item
    {
        public LegendaryItem(int quality, int sellBy, string name) : base(quality, sellBy, name)
        {
        }
    }

    public class CommonItem : Item
    {
        public CommonItem(int quality, int sellBy, string name) : base(quality, sellBy, name)
        {
        }

        public override void Process()
        {
            int decreaseQualityBy = 1;

            if (0 >= SellBy) decreaseQualityBy ++;

            Process(decreaseQualityBy);
        }
    }


    public class AgedItem : Item
    {
        public AgedItem(int quality, int sellBy, string name) : base(quality, sellBy, name)
        {
        }

        public override void Process()
        {
            Process(-1);
        }
    }

    public class BackstageItem : Item
    {
        public BackstageItem(int quality, int sellBy, string name) : base(quality, sellBy, name)
        {
        }

        public override void Process()
        {
            if (0 >= SellBy)
            {
                Quality = 0;
                return;
            }

            int decreaseQualityBy = -1;

            if (SellBy <= 5) decreaseQualityBy --;

            if (SellBy <= 10) decreaseQualityBy --;

            Process(decreaseQualityBy);
        }
    }

    public class ConjuredItem : Item
    {
        public ConjuredItem(int quality, int sellBy, string name) : base(quality, sellBy, name)
        {
        }

        public override void Process()
        {
            Process(2);
        }
    }

    public class Item 
    {
        protected int Quality;
        public int GetQuality => Quality;

        protected int SellBy;
        public int GetSellBy => SellBy;

        protected readonly string Name;

        public Item(int quality, int sellBy, string name)
        {
            Quality = quality;
            SellBy = sellBy;
            Name = name;
        }

        public virtual void Process()
        {
        }

        protected void Process(int decreaseQualityBy)
        {
            SellBy -= 1;

            Quality -= decreaseQualityBy;

            if (0 >= Quality) Quality = 0;
        }
    }
}
