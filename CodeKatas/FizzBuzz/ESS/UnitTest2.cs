using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzz.ESS
{
    [TestClass]
    public class UnitTest2
    {
        //// input of a number and return the number as a string
        // if the number is divisible by 3 return "fizz"
        // if the number is divisible by 5 return "buzz"
        // if the number is divisible by 3 and 5 "fizzbuzz"

        [TestMethod]
        public void ShouldReturnNumberAsString()
        {
            // arrange
            FizzBuzz1 fizzBuzz1 = new FizzBuzz1();
            const int expected = 1;

            // act
            string actual = fizzBuzz1.Evaluate(expected);

            // assert
            actual.Should().Be(expected.ToString());
        }

        [TestMethod]
        public void ShouldReturnFizzForModThree()
        {
            // arrange
            FizzBuzz1 fizzBuzz1 = new FizzBuzz1();

            // act
            string actual = fizzBuzz1.Evaluate(3);

            // assert
            actual.Should().Be("fizz");
        }
    }

    public class FizzBuzz1
    {
        public string Evaluate(int inputValue)
        {
            if (inputValue % 3 == 0)
            {
                return "fizz";
            }

            return inputValue.ToString();
        }
    }
}
