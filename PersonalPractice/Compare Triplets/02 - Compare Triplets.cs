using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class CompareTriplets02Tests
    {
        // first pass with objects
        [TestMethod]
        public void ShouldCompareObjectTouples()
        {
            Score scoreA = new Score(5, 6, 7);
            Score scoreB = new Score(3, 6, 10);

            string actual = scoreA.RankAgainstAnotherScore(scoreB);

            actual.Should().Be("1 1");
        }
    }

    public class Score
    {
        public readonly int A;
        public readonly int B;
        public readonly int C;

        private int _myScore;

        public Score(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void IncreaseScore()
        {
            _myScore += 1;
        }

        public int MyScore() => _myScore;

        public string RankAgainstAnotherScore(Score challenger)
        {
            EvaluateScore(challenger.A, A, challenger, this);
            EvaluateScore(challenger.B, B, challenger, this);
            EvaluateScore(challenger.C, C, challenger, this);

            return $"{MyScore()} {challenger.MyScore()}";
        }

        private void EvaluateScore(int challengerScore, int championScore, Score challenger, Score champion)
        {
            if (challengerScore == championScore) return;

            if (challengerScore> championScore)
            {
                challenger.IncreaseScore();
                return;
            }

            champion.IncreaseScore();
        }
    }
}
