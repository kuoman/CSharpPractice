using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class BirthdayCandlesTests
    {
        [TestMethod]
        public void ShouldReturnAllTrue()
        {
            int[] ints = {1, 2, 3, 4};

            int result = CandleCounter(ints);

            result.Should().Be(1);
        }

        [TestMethod]
        public void ShouldReturnBlocked2()
        {
            int[] ints = { 3, 1, 2, 4 };

            int result = CandleCounter(ints);

            result.Should().Be(1);

            Console.Write(CandleCounter(ints));
        }

        [TestMethod]
        public void ShouldReturnBlocked2ForTies()
        {
            int[] ints = { 3, 1, 2, 3 };

            int result = CandleCounter(ints);

            result.Should().Be(2);

            Console.Write(CandleCounter(ints));
        }


        [TestMethod]
        public void ShouldReturnOnlyTallestCandles()
        {
            int[] ints = { 3, 1, 2, 3 };

            int result = CandleCounter(ints);

            result.Should().Be(2);

            Console.Write(CandleCounter(ints));

         //   int champion = ints.Max();
          //  Console.Write(ints.Where(x => x == champion).Count());
        }

        private int CandleCounter(int[] height)
        {
            return height.Where(x => x == height.Max()).Count();
        }
    }
}
