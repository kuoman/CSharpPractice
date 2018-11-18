using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class DiagonalDifferenceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //3
            //11 2 4
            //4 5 6
            //10 8 - 12

            int size = 3;

            int[] matrix1 = { 11, 2, 4};
            int[] matrix2 = { 4, 5, 6 };
            int[] matrix3 = { 10, 8, -12 };

            int[][] matrix = { matrix1, matrix2, matrix3};

            int difference = CalculateDiagonalDifference(matrix, size);

            difference.Should().Be(15);

            int dynamicDiagonal1 = 0;
            int inverseDiagnal = 0;

            for (int i = 0; i < size; i++)
            {
                dynamicDiagonal1 += matrix[i][i];
                inverseDiagnal += matrix[i][size - 1 - i];
            }

            Console.Write(Math.Abs(dynamicDiagonal1 - inverseDiagnal));
        }

        private int CalculateDiagonalDifference(int[][] matrix, int size)
        {
            int dynamicDiagonal1 = 0;
            int inverseDiagnal = 0;

            for (int i = 0; i < size; i++)
            {
                dynamicDiagonal1 += matrix[i][i];
                inverseDiagnal += matrix[i][size - 1 - i];
            }

            return Math.Abs(dynamicDiagonal1 - inverseDiagnal);
        }
    }
}
