using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class PlusMinusTests
    {
        [TestMethod]
        public void TestMethod1()
        {
           // Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.
            int[] array = new[] {-1, 0, 1};

            PlusMinus plusMinus = new PlusMinus(array);

            string result = plusMinus.PercentPositive();

            result.Should().Be("0.333333");
        }

        [TestMethod]
        public void ShouldCalculateZeroPercent()
        {
            // Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.
            int[] array = new[] { -1, 0, 1 };

            PlusMinus plusMinus = new PlusMinus(array);

            string result = plusMinus.PercentZero();

            result.Should().Be("0.333333");
        }

        [TestMethod]
        public void ShouldCalculateNegativePercent()
        {
            // Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.
            int[] array = new[] { -1, 0, 1 };

            PlusMinus plusMinus = new PlusMinus(array);

            string result = plusMinus.PercentNegative();

            result.Should().Be("0.333333");
        }

        [TestMethod]
        public void ShouldCalculateUseCase()
        {
            // Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.
            int[] array = new[] { -4, 3, -9, 0, 4, 1 };

            PlusMinus plusMinus = new PlusMinus(array);

            string resultP = plusMinus.PercentPositive();
            string resultN = plusMinus.PercentNegative();
            string resultZ = plusMinus.PercentZero();


            Console.WriteLine(plusMinus.PercentPositive());
            Console.WriteLine(plusMinus.PercentNegative());
            Console.WriteLine(plusMinus.PercentZero());

            resultP.Should().Be("0.500000");
            resultN.Should().Be("0.333333");
            resultZ.Should().Be("0.166667");
        }

        [TestMethod]
        public void ShouldCalculateForZero()
        {
            // Given an array of integers, calculate which fraction of its elements are positive, which fraction of its elements are negative, and which fraction of its elements are zeroes, respectively.Print the decimal value of each fraction on a new line.
            int[] array = new[] { -4, 3, -9, 3, 4, 1 };

            PlusMinus plusMinus = new PlusMinus(array);

            string resultP = plusMinus.PercentPositive();
            string resultN = plusMinus.PercentNegative();
            string resultZ = plusMinus.PercentZero();


            Console.WriteLine(plusMinus.PercentPositive());
            Console.WriteLine(plusMinus.PercentNegative());
            Console.WriteLine(plusMinus.PercentZero());

            resultP.Should().Be("0.666667");
            resultN.Should().Be("0.333333");
            resultZ.Should().Be("0.000000");
        }
    }

    public class PlusMinus
    {
        private readonly int[] _array;

        public PlusMinus(int[] array)
        {
            _array = array;
        }

        public string PercentPositive() => Evaluate(value => value > 0);
        public string PercentNegative() => Evaluate(value => 0 > value);
        public string PercentZero() => Evaluate(value => value == 0);

        private string Evaluate(Func<int, bool> strategy) => Math.Round((double)_array.Count(strategy) / _array.Length, 6).ToString("f6");
    }
}
