using Castle.Core.Internal;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PersonalPractice.PizzaShop
{
    [TestClass]
    public class PizzaShopTests
    {
        // small 9 small pizza toppings 10% of the price
        // medium pizza $15 Toppings 15% - cheese, onlinos bell pepper
        // Large pizza $18 toppings 18% - Pep, sausage, ham
        // 1/2 order calzone $9 toppings $32% Roasted Garliz, Sundried Tomato
        // full order calzone $15

        // Start a new pizza
        // Add toppings to pizza
        // get current price of the pizza
        // get description of the pizza "small menuItem with sausage and chese"

        // change 1
        // small pizza, calzone

        // change 2
        // re-size the pizza or calzone and recalaulate price and description
        // change medium and small pizza 

        [TestMethod]
        public void ShouldReturnCalzoneDescription()
        {
            IItem item = new Item("calzone", 15d, new List<Topping>());

            item.Description().Should().Be("calzone");
        }

        [TestMethod]
        public void ShouldReturnSmallPizzaDescription()
        {
            IItem item = new Item("small pizza", 15d, new List<Topping>());

            item.Description().Should().Be("small pizza");
        }

        [TestMethod]
        public void ShouldReturnOneItemDescription()
        {
            IItem item = new Item("small pizza", 15d, new List<Topping>{new Topping("cheese", 0.0d)});

            item.Description().Should().Be("small pizza with cheese");
        }

        [TestMethod]
        public void ShouldReturnTwoItemDescription()
        {
            IItem item = new Item("small pizza", 15d, new List<Topping> { new Topping("cheese", 0.0d), new Topping("sasuage", 0.0d) });

            item.Description().Should().Be("small pizza with cheese, and sasuage");
        }

        [TestMethod]
        public void ShouldReturnComplexDescription()
        {
            IItem item = new Item("small pizza", 15d, new List<Topping> { new Topping("cheese", 0.0d), new Topping("onion", 0.0d), new Topping("sasuage", 0.0d) });

            item.Description().Should().Be("small pizza with cheese, onion, and sasuage");
        }

        [TestMethod]
        public void ShouldReturnMediumPizzaDescription()
        {
            IItem item = new Item("medium pizza", 15d, new List<Topping>());

            item.Description().Should().Be("medium pizza");
        }

        [TestMethod]
        public void ShouldReturnMediumPizzaPrice()
        {
            IItem item = new Item("medium pizza", 15d, new List<Topping>());

            item.Price().Should().Be(15.0d);
        }

        [TestMethod]
        public void ShouldAdjustPriceWhenToppingAdded()
        {
            IItem item = new Item("medium pizza", 15d, new List<Topping>());

            IItem newItem = item.AddTopping(new Topping("cheese", .10d));

            newItem.Price().Should().Be(16.50d);
        }

        [TestMethod]
        public void ShouldAdjustPriceWhenToppingsAdded()
        {
            IItem item = new Item("medium pizza", 15d, new List<Topping>());

            item = item.AddTopping(new Topping("cheese", .10d));
            item = item.AddTopping(new Topping("sasuage", .18d));

            item.Price().Should().Be(19.20d);
        }

        [TestMethod]
        public void ShouldReturnLargePizzaPrice()
        {
            IItem item = new Item("large pizza", 18d, new List<Topping>());

            item.Price().Should().Be(18.0d);
        }
    }

    public interface IItem
    {
        double Price();
        IItem AddTopping(Topping topping);
        string Description();
    }

    public class Item : IItem
    {
        private readonly string _name;
        private readonly double _basePrice;
        private readonly List<Topping> _toppings;

        public Item(string name, double basePrice, List<Topping> toppings)
        {
            _name = name;
            _basePrice = basePrice;
            _toppings = toppings;
        }

        public IItem AddTopping(Topping topping)
        {
            _toppings.Add(topping);
            return new Item(_name, _basePrice, _toppings);
        }

        public string Description()
        {
            if (_toppings.IsNullOrEmpty()) return _name;

            string returnString = $"{_name} with";

            for (int index = 0; index < _toppings.Count; index++)
            {
                Topping topping = _toppings[index];
                returnString = topping.AddToDescription(returnString);

                if (index != _toppings.Count - 1)
                {
                    returnString = returnString + ",";
                }

                if (index == _toppings.Count - 2)
                {
                    returnString = returnString + " and";
                }

            }

            return returnString;
        }

        public double Price()
        {
            return _basePrice + _toppings.Sum(topping => topping.Price(_basePrice));
        }

    }
}
