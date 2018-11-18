using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class StringSumTests
    {

//      You are given an array of integers of size.You need to print the sum of the elements in the array, keeping in mind that some of those integers may be quite large.

//      Input Format
//      The first line of the input consists of an integer.The next line contains  space-separated integers contained in the array.

//      Output Format

//      Print a single value equal to the sum of the elements in the array.


//      Constraints
//      Sample Input 
//      5
//      1000000001 1000000002 1000000003 1000000004 1000000005

//     Output
//     5000000015
//     Note:
//      The range of the 32-bit integer is .
//      When we add several integer values, the resulting sum might exceed the above range. You might need to use long long int in C/C++ or long data type in Java to store such sums.
      


        [TestMethod]
        public void TestMethod1()
        {
            string[] arr_temp = new[] {"1000000001", "1000000002", "1000000003", "1000000004", "1000000005"};
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            List<long> longList = arr.Select(i => Convert.ToInt64(i)).ToList();

            long result = Array.ConvertAll(arr_temp, Int64.Parse).Sum();

            result.Should().Be(5000000015);
            Console.Write(Array.ConvertAll(arr_temp, Int64.Parse).Sum().ToString());

        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] arr_temp = new[] { "1000000001", "1000000002", "1000000003", "1000000004", "1000000005" };
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            long[] arr2 = Array.ConvertAll(arr_temp, Int64.Parse);

            long result = arr2.Sum();

            result.Should().Be(5000000015);

        }
    }
}
