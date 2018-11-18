using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Gilded_Rose.Try3
{
    [TestClass]
    public class GildedRoseTry3Tests
    {
        [TestMethod]
        public void ShouldDegradeInQuality()
        {
            // arrange
            Item item = new Item(10, 9, string.Empty);

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(9);
        }

        [TestMethod]
        public void ShouldDecreaseSellBy()
        {
            // arrange
            Item item = new Item(18, 10, string.Empty);

            // act
            item.Process();

            // assert
            item.GetSellBy.Should().Be(9);
        }

        [TestMethod]
        public void ShouldDecreaseTwiceAsFastIfSellByIsPast()
        {
            // arrange
            Item item = new Item(18, 0, string.Empty);

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
            Item item = new Item(0, 1, "Aged Brie");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(1);
        }

        [TestMethod]
        public void ShouldSulfurasShouldNotChange()
        {
            // arrange
            Item item = new Item(10, 1, "Sulfuras");

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
            Item item = new Item(10, 9, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetSellBy.Should().Be(8);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQuality()
        {
            // arrange
            Item item = new Item(10, 12, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(11);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQualityBy2IfTenToSixDays()
        {
            // arrange
            Item item = new Item(10, 11, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(12);
        }

        [TestMethod]
        public void ShouldIncreaseConcertPassesQualityBy2IfFiveToZeroDays()
        {
            // arrange
            Item item = new Item(10, 5, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(13);
        }

        [TestMethod]
        public void ShouldZeroConcertPassesQualityZeroDays()
        {
            // arrange
            Item item = new Item(10, 0, "Backstage Passes");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(0);
        }


        [TestMethod]
        public void ShouldDecreaseConjuredItemsTwiceAsFast()
        {
            // arrange
            Item item = new Item(10, 10, "Conjured");

            // act
            item.Process();

            // assert
            item.GetQuality.Should().Be(8);
        }

        public class Item
        {
            private int _quality;
            public int GetQuality => _quality;

            private int _sellBy;
            public int GetSellBy => _sellBy;

            private readonly string _name;

            public Item(int quality, int sellBy, string name)
            {
                _quality = quality;
                _sellBy = sellBy;
                _name = name;
            }

            public void Process()
            {
                if (_name == "Sulfuras") return;

                int decreaseQualityBy = 1;

                _sellBy -= 1;

                if (_name == "Backstage Passes")
                {
                    if (0 >= _sellBy)
                    {
                        _quality = 0;
                        return;
                    }

                    if (_sellBy <= 5) _quality += decreaseQualityBy;

                    if (_sellBy <= 10) _quality += decreaseQualityBy;

                    _quality += decreaseQualityBy;
                    return;
                }

                if (_name == "Aged Brie")
                {
                    _quality += decreaseQualityBy;
                    return;
                }

                if (_name == "Conjured") decreaseQualityBy = decreaseQualityBy * 2;

                _quality -= decreaseQualityBy;

                if (0 >= _sellBy) _quality -= decreaseQualityBy;

                if (0 >= _quality) _quality = 0;
            }
        }
    }    
}
