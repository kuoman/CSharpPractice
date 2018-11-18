using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.FizzBuzz
{
    [TestClass]
    public class FizzBuzzReviewed
    {
        // 1 if you are a number return the number
        // 2 if you are a number divisible by 3, return FIZZ
        // 3 if you are a number divisible by 5, return BUZZ
        // 4 if you are a number divisible by 3 and 5 return FIZZBUZZ

        [TestMethod]
        public void ShouldReturnGivenValueAsString()
        {
            // act
            string returnValue = Evaluate(1);

            // assert
            returnValue.Should().Be("1");
        }

        [TestMethod]
        public void ShouldreturnFizzForMultipleOfThree()
        {
            // act
            string returnValue = Evaluate(3);

            // assert
            returnValue.Should().Be("FIZZ");
        }

        [TestMethod]
        public void ShouldReturnBuzzForMultipleOfFive()
        {
            // act
            string returnValue = Evaluate(5);

            // assert
            returnValue.Should().Be("BUZZ");
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzForMultiplesOfFifteen()
        {
            // act
            string returnValue = Evaluate(15);

            // assert
            returnValue.Should().Be("FIZZBUZZ");
        }

        private string Evaluate(int value)
        {
            if (IsModFifteen(value)) return "FIZZBUZZ";
            if (IsModThree(value)) return "FIZZ";
            if (IsModFive(value)) return "BUZZ";

            return value.ToString();
        }

        //private string Evaluatez(int value)
        //{
        //    StringBuilder returnString = new StringBuilder();

        //    if (IsModThree(value)) returnString.Append("FIZZ");
        //    if (IsModFive(value)) returnString.Append("BUZZ");

        //    return (IsFizzOrBuzz(returnString)) ? value.ToString() : returnString.ToString();
        //}

        //private bool IsFizzOrBuzz(StringBuilder returnString) => string.IsNullOrEmpty(returnString.ToString());

        private bool IsModFifteen(int value) => value % 15 == 0;

        private bool IsModFive(int value) => value % 5 == 0;

        private bool IsModThree(int value) => value % 3 == 0;

    }
}
