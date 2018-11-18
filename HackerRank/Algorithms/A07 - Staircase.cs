using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class StaircaseTests
    {

        //A single integer, , denoting the size of the staircase.

        //Output Format

        //Print a staircase of size  using # symbols and spaces.

        //Note: The last line must have spaces in it.

        //Sample Input

        //6 
        //Sample Output

        //#
        //##
        //###
        //####
        //#####
        //######

        [TestMethod]
        public void ShouldReturnFirstStair()
        {
            Staircase staircase = new Staircase(6);


            staircase.GetNextStair().Should().Be("     #");
        }

        [TestMethod]
        public void ShouldReturnSecondStair()
        {
            Staircase staircase = new Staircase(6);

            staircase.GetNextStair();

            staircase.GetNextStair().Should().Be("    ##");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDoWholeThing()
        {
            int stairCount = 6;

            Staircase staircase = new Staircase(6);

            for (int i = 0; i < stairCount; i++)
            {
                Console.WriteLine(staircase.GetNextStair());
            }
        }

        private class Staircase
        {
            private readonly int _stairs;
            private int _stairCount;

            public Staircase(int stairs)
            {
                _stairs = stairs;
            }

            public string GetNextStair()
            {
                ++_stairCount;

                return string.Empty.PadRight(_stairCount, '#').PadLeft(_stairs, ' ');
            }
        }
    }
}
