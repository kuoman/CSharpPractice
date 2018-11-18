using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Gilded_Rose.Try1
{
    [TestClass]
    public class GildedRose02Tests
    { 
        [TestMethod]
        public void ShouldDecrementQuality1XIfBeforeSellIn()
        {
            // arrange
            Normal itemz = new Normal(1, 5);

            // act
            itemz.AdjustQuality();

            //assert
            itemz.CurrentQuality().Should().Be(4);
        }

        [TestMethod]
        public void ShouldDecrementQuality2XIfPastSellIn()
        {
            // arrange
            Normal itemz = new Normal(0, 6);

            // act
            itemz.AdjustQuality();

            //assert
            itemz.CurrentQuality().Should().Be(4);
        }

        [TestMethod]
        public void ShouldValidateQualityLowerLimit()
        {
            // arrange
            Normal itemz = new Normal(0, 0);

            // act
            itemz.AdjustQuality();

            //assert
            itemz.CurrentQuality().Should().Be(0);
        }

        [TestMethod]
        public void ShouldValidateIsAgedItemsIncrement()
        {
            // arrange
            Aged itemz = new Aged(49);

            // act
            itemz.AdjustQuality();

            //assert
            itemz.CurrentQuality().Should().Be(50);
        }

        [TestMethod]
        public void ShouldValidateQualityUpperLimit()
        {
            // arrange
            Aged itemz = new Aged(50);

            // act
            itemz.AdjustQuality();

            //assert
            itemz.CurrentQuality().Should().Be(50);
        }

        [TestMethod]
        public void ShouldValidateLegendaryIsBoring()
        {
            // arrange
            Legendary item = new Legendary(10);

            // act
            item.AdjustQuality();

            //assert
            item.CurrentQuality().Should().Be(10);
        }

        public abstract class Item
        {
            protected int Quality;

            protected Item(int quality)
            {
                Quality = quality;
            }
            public virtual void AdjustQuality()
            {
            }

            public int CurrentQuality()
            {
                return Quality;
            }
        }

        public class Normal : Item
        {
            private int _sellIn;

            public Normal(int sellIn, int quality) : base(quality)
            {
                _sellIn = sellIn;
            }

            public override void AdjustQuality()
            {
                _sellIn -= 1;

                Quality -= _sellIn < 0 ? 2 : 1;

                if (0 > Quality) Quality = 0;
            }
        }

        public class Aged : Item
        {
            public Aged(int quality) : base(quality){}

            public override void AdjustQuality()
            {
                Quality += 1;

                if (Quality > 50) Quality = 50;
            }
        }

        public class Legendary : Item
        {
            public Legendary(int quality) : base(quality)
            {
            }
        }

        //public abstract class Item
        //{
        //    protected int Quality;

        //    protected Item(int quality)
        //    {
        //        Quality = quality;
        //    }

        //    public int CurrentQuality()
        //    {
        //        return Quality;
        //    }
        //}

        //public abstract class AdjustableItem : Item
        //{
        //    protected AdjustableItem(int quality) : base(quality) { }

        //    public virtual void AdjustQuality() { }
        //}

        //public class Normal : AdjustableItem
        //{
        //    private int _sellIn;

        //    public Normal(int sellIn, int quality) : base(quality)
        //    {
        //        _sellIn = sellIn;
        //    }

        //    public override void AdjustQuality()
        //    {
        //        _sellIn -= 1;

        //        Quality -= _sellIn < 0 ? 2 : 1;

        //        LimitAdjustment();
        //    }

        //    private void LimitAdjustment()
        //    {
        //        if (0 > Quality) Quality = 0;
        //    }
        //}

        //public class Aged : AdjustableItem
        //{
        //    public Aged(int quality) : base(quality) { }

        //    public override void AdjustQuality()
        //    {
        //        Quality += 1;

        //        LimitAdjustment();
        //    }

        //    private void LimitAdjustment()
        //    {
        //        if (Quality > 50) Quality = 50;
        //    }
        //}

        //public class Legendary : Item
        //{
        //    public Legendary(int quality) : base(quality) { }
        //}


        public class Itemz
        {
            private int _sellIn;
            private int _quailty;
            private readonly bool _isAged;

            public Itemz(int sellIn, int quailty, bool isAged)
            {
                _sellIn = sellIn;
                _quailty = quailty;
                _isAged = isAged;
            }

            public int SellIn()
            {
                return _sellIn;
            }

            public void Batch()
            {
                _sellIn -= 1;

                if (_isAged)
                {
                    _quailty += 1;
                }
                else
                {
                    _quailty -= _sellIn < 0 ? 2 : 1;
                }

                QualityLowerLimitAdjustment();
                QualityUpperLimitAdjustment();
            }

            private void QualityUpperLimitAdjustment()
            {
                if (_quailty > 50) _quailty = 50;
            }

            private void QualityLowerLimitAdjustment()
            {
                if (0 > _quailty) _quailty = 0;
            }

            public int GetCurrentQuality()
            {
                return _quailty;
            }
        }
    }
}
