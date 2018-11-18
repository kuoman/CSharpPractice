using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class UnitTest1
    {
       //Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers.Then print the respective minimum and maximum values as a single line of two space-separated long integers.

       //Input Format

       //A single line of five space-separated integers.


       //Constraints

       //Each integer is in the inclusive range.
       //Output Format
       

       //Print two space-separated long integers denoting the respective minimum and maximum values that can be calculated by summing exactly four of the five integers. (The output can be greater than 32 bit integer.)

       // Sample Input

       // 1 2 3 4 5
       // Sample Output

       // 10 14
       // Explanation

       // Our initial numbers are , , , , and.We can calculate the following sums using four of the five integers:

       // If we sum everything except , our sum is .
       // If we sum everything except , our sum is .
       // If we sum everything except , our sum is .
       // If we sum everything except , our sum is .
       // If we sum everything except , our sum is .
       // As you can see, the minimal sum is  and the maximal sum is . Thus, we print these minimal and maximal sums as two space-separated integers on a new line.

       // Hints: Beware of integer overflow! Use 64-bit Integer.

        [TestMethod]
        public void ShouldParseList()
        {
            int[] numbers = {3, 2, 1, 4, 5};

            long highChampion = 0;
            long lowChampion =  long.MaxValue;

            for (int ignoredIndex = 0; ignoredIndex < numbers.Length; ignoredIndex++)
            {
                long tempSum = numbers.Where((t, i) => i != ignoredIndex).Aggregate<int, long>(0, (current, t) => current + t);

                if (tempSum > highChampion) highChampion = tempSum;
                if (lowChampion > tempSum) lowChampion = tempSum;
            }

            string result = $"{lowChampion} {highChampion}";

            result.Should().Be("10 14");

            Console.Write(result);
        }

        [TestMethod]
        public void ShouldWalkListOnce()
        {
            int[] arr = { 3, 2, 1, 4, 5 };

            long highChampion = 0;
            long lowChampion = long.MaxValue;
            long sum = 0;

            foreach (int challenger in arr)
            {
                if (challenger > highChampion) highChampion = challenger;
                if (lowChampion > challenger) lowChampion = challenger;
                sum += challenger;
            }

            Console.Write($"{sum - highChampion} {sum - lowChampion}");

            string result = $"{sum - highChampion} {sum - lowChampion}";

            result.Should().Be("10 14");
        }

        [TestMethod]
        public void ShouldSortThenAddBottomFourAndTopFour()
        {
            int[] arr = { 3, 2, 1, 4, 5 };
            List<int> numbers = arr.ToList();

            numbers.Sort();
            long lowChampion = SumFirstFourElements(numbers);

            numbers.Reverse();
            long highChampion = SumFirstFourElements(numbers);

            Console.Write($"{lowChampion} {highChampion}");

            lowChampion.Should().Be(10);
            highChampion.Should().Be(14);

            string result = $"{lowChampion} {highChampion}";

            result.Should().Be("10 14");
        }

        private static int SumFirstFourElements(List<int> numbers) => numbers.Take(4).Sum();
    }
}
