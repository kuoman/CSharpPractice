using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class SimpleArraySumTests
    {
        //Given an array of  integers, can you find the sum of its elements?

        //Input Format

        //The first line contains an integer, , denoting the size of the array.
        //The second line contains  space-separated integers representing the array's elements.

        //Output Format

        //Print the sum of the array's elements as a single integer.

        [TestMethod]
        public void ShouldParseArgsToListOfInt()
        {
            // act
            int actual = ParseToArray("1 2 3 4 10 11");

            // assert
            actual.Should().Be(31);
        }

        private int ParseToArray(String args)
        {
            List<string> list = args.Split().ToList();

            List<int> returnList = list.Select(x => Convert.ToInt32(x)).ToList();

            return returnList.Sum();

            //return input.Split().ToList().Select(x => Convert.ToInt32(x)).ToList().Sum();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldDoSomethingNew()
        {
            // arrange
            

            // act


            // assert

        }
    }
}
