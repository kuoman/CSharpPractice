using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class CompareTriplets03Tests
    {
        // second pass with objects
        [TestMethod]
        public void ShouldCompareObjectTouples2()
        {
            Score2 scoreA = new Score2(5, 6, 7);
            Score2 scoreB = new Score2(3, 6, 10);

            scoreA.ScoreAgainstAnother(scoreB);
            scoreB.ScoreAgainstAnother(scoreA);

            string actual = $"{scoreA.MyScore()} {scoreB.MyScore()}";

            actual.Should().Be("1 1");
        }
    }

    public class Score2
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;

        private int _myScore;

        public Score2(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public void IncreaseScore()
        {
            _myScore += 1;
        }

        public int MyScore() => _myScore;

        public void ScoreAgainstAnother(Score2 challenger)
        {
            challenger.EvaluateAgainstOpponent(_a, _b, _c, challenger);
        }

        private void EvaluateAgainstOpponent(int a, int b, int c, Score2 opponent)
        {
            EvaluateScore(_a, a, opponent);
            EvaluateScore(_b, b, opponent);
            EvaluateScore(_c, c, opponent);
        }

        private void EvaluateScore(int championScore, int challengerScore, Score2 challenger)
        {
            if (championScore < challengerScore) challenger.IncreaseScore();
        }
    }
}
