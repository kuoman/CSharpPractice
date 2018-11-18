using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.FizzBuzz.Conference
{
    [TestClass]
    public class UnitTest1
    {
        // given an int return string of that int
        // if given a value divisible by 3 return "fizz"
        // if given a value divisible by 5 return "buzz"
        // if divisible by 3 and 5 return "fizzbuzz"

        // focus #1 TDD
        // focus #2 kata

        // red green refactor
        
        // 4 simple rules of design
        // 1. code works
        // 2. Clearly communicates intent
        // 3. No duplication
        // 4. Minimizing Artifacts / small

        [TestMethod]
        public void ShouldReturn_String()
        {
            // arrange
            FizzyClass fizzyClass = new FizzyClass();

            // act
            string returnValue = fizzyClass.Evaluate(1);

            // assert
            returnValue.Should().Be("1");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_FizzForModThree()
        {
            // arrange
            FizzyClass fizzyClass = new FizzyClass();

            // act
            string returnValue = fizzyClass.Evaluate(6);

            // assert
            returnValue.Should().Be("fizz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_FizzForModFive()
        {
            // arrange
            FizzyClass fizzyClass = new FizzyClass();

            // act
            string returnValue = fizzyClass.Evaluate(10);

            // assert
            returnValue.Should().Be("buzz");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturn_FizzBuzzForModThreeAndFive()
        {
            // arrange
            FizzyClass fizzyClass = new FizzyClass();

            // act
            string returnValue = fizzyClass.Evaluate(30);

            // assert
            returnValue.Should().Be("fizzbuzz");
        }
    }

    public class FizzyClass
    {
        public string Evaluate(int input)
        {
            if (IsModFifteen(input)) return "fizzbuzz";
            if (IsModThree(input)) return "fizz";
            if (IsModFive(input)) return "buzz";

            return input.ToString();
        }

        private static bool IsModFifteen(int input)
        {
            return input % 15 == 0;
        }

        private static bool IsModFive(int input)
        {
            return input % 5 == 0;
        }

        private static bool IsModThree(int input)
        {
            return input % 3 == 0;
        }
    }
}

