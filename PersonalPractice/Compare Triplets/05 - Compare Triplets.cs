using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class CompareTriplets05Tests
    {
        [TestMethod]
        public void ShouldScoreArrayNonZeroTie()
        {
            ScoreWithPrivateArray scoreA = new ScoreWithPrivateArray(new List<int> { 6, 6, 6 });
            ScoreWithPrivateArray scoreB = new ScoreWithPrivateArray(new List<int> { 3, 6, 10 });

            scoreA.GetScore(scoreB).Should().Be("1 1");
        }

        [TestMethod]
        public void ShouldScoreArrayTie()
        {
            ScoreWithPrivateArray scoreA = new ScoreWithPrivateArray(new List<int> { 6, 6, 6 });
            ScoreWithPrivateArray scoreB = new ScoreWithPrivateArray(new List<int> { 6, 6, 6 });

            scoreA.GetScore(scoreB).Should().Be("0 0");
        }

        [TestMethod]
        public void ShouldScoreArraySelfWinner()
        {
            ScoreWithPrivateArray scoreA = new ScoreWithPrivateArray(new List<int> { 6, 6, 6 });
            ScoreWithPrivateArray scoreB = new ScoreWithPrivateArray(new List<int> { 3, 4, 5 });

            scoreA.GetScore(scoreB).Should().Be("3 0");
        }
    }

    public class ScoreWithPrivateArray
    {
        private readonly List<int> _scores;

        public ScoreWithPrivateArray(List<int> scores)
        {
            _scores = scores;
        }

        public string GetScore(ScoreWithPrivateArray other) => $"{Score(other)} {other.Score(this)}";

        public int Score(ScoreWithPrivateArray other) => _scores.Select((t, i) => t > other._scores[i] ? 1 : 0).Sum();
    }
}
