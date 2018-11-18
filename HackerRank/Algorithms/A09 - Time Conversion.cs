using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class UnitTest2
    {
        //Given a time in -hour AM/PM format, convert it to military(-hour) time.

        //Note: Midnight is  on a -hour clock, and  on a -hour clock.Noon is  on a -hour clock, and on a -hour clock.

        //Input Format

        //A single string containing a time in -hour clock format (i.e.:  or ), where and.

        //Output Format
        //     Convert and print the given time in -hour format, where.

        //Sample Input
        //    07:05:45PM

        //Sample Output
        //    19:05:45

        [TestMethod]
        public void TestMethod1()
        {
            string time = "07:05:45PM";

            string result = DateTime.ParseExact(time, "hh:mm:sstt", System.Globalization.CultureInfo.CurrentCulture).ToString("HH:mm:ss");
            Console.Write(result);

            result.Should().Be("19:05:45");
        }
    }
}
