using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PersonalPractice.PizzaShop
{
    [TestClass]
    public class ToppingsTests
    {
        [TestMethod]
        public void ShouldReturnToppingPriceForMedium()
        {
            Topping topping = new Topping("cheese", .15d);

            topping.Price(15d).Should().Be(2.25d);
        }

        [TestMethod]
        public void ShouldReturnToppingPriceForLarge()
        {
            Topping topping = new Topping("cheese", .15d);

            topping.Price(18.0d).Should().Be(2.70d);
        }

        [TestMethod]
        public void ShouldAddToDescription()
        {
            Topping topping = new Topping("cheese", .15d);

            topping.AddToDescription("base with").Should().Be("base with cheese");
        }
    }

    public class Topping
    {
        private readonly string _name;
        private readonly double _value;

        public Topping(string name, double value)
        {
            _name = name;
            _value = value;
        }

        public double Price(double pizzaPrice)
        {
            return Math.Round(pizzaPrice * _value, 2);
        }

        public string AddToDescription(string initial)
        {
            return $"{initial} {_name}";
        }
    }
}
