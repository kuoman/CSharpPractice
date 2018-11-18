using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class CompareTriplets01Tests
    {
        // first dirty pass at doing it with a raw method
        [TestMethod]
        public void ShouldCompareTouples()
        {
            string actual = CompareTouple(5, 6, 7, 3, 6, 10);

            actual.Should().Be("1 1");
        }

        private string CompareTouple(int a1, int a2, int a3, int b1, int b2, int b3)
        {
            int aScore = 0;
            int bScore = 0;

            EvaluateScore(a1, b1, ref aScore, ref bScore);
            EvaluateScore(a2, b2, ref aScore, ref bScore);
            EvaluateScore(a3, b3, ref aScore, ref bScore);

            return $"{aScore} {bScore}";
        }

        private void EvaluateScore(int a1, int b1, ref int aScore, ref int bScore)
        {
            if (a1 == b1) return;

            if (a1 > b1)
            {
                aScore += 1;
            }
            else
            {
                bScore += 1;
            }
        }
    }
}
