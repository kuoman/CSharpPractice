using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PersonalPractice.Compare_Triplets
{
    [TestClass]
    public class CompareTriplets04Tests
    {
        [TestMethod]
        public void ShouldScoreArrayNonZeroTie()
        {
            ScoreArray scoreA = new ScoreArray(new List<int> { 6, 6, 6});
            ScoreArray scoreB = new ScoreArray(new List<int> { 3, 6, 10});

            string actual = scoreA.ScoreAgainstAnother(scoreB);

            actual.Should().Be("1 1");
        }

        [TestMethod]
        public void ShouldScoreArrayTie()
        {
            ScoreArray scoreA = new ScoreArray(new List<int> { 6, 6, 6 });
            ScoreArray scoreB = new ScoreArray(new List<int> { 6, 6, 6 });

            string actual = scoreA.ScoreAgainstAnother(scoreB);

            actual.Should().Be("0 0");
        }

        [TestMethod]
        public void ShouldScoreArraySelfWinner()
        {
            ScoreArray scoreA = new ScoreArray(new List<int> { 6, 6, 6 });
            ScoreArray scoreB = new ScoreArray(new List<int> { 3, 4, 5 });

            string actual = scoreA.ScoreAgainstAnother(scoreB);

            actual.Should().Be("3 0");
        }

        [TestMethod]
        public void ShouldScoreArrayOtherWinner()
        {
            ScoreArray scoreA = new ScoreArray(new List<int> { 2, 1, 0 });
            ScoreArray scoreB = new ScoreArray(new List<int> { 3, 4, 5 });

            string actual = scoreA.ScoreAgainstAnother(scoreB);

            actual.Should().Be("0 3");
        }

        [TestMethod]
        public void ShouldScoreArrayOtherWinnerWith2()
        {
            ScoreArray scoreA = new ScoreArray(new List<int> { 24, 1, 0 });
            ScoreArray scoreB = new ScoreArray(new List<int> { 3, 4, 5 });

            string actual = scoreA.ScoreAgainstAnother(scoreB);

            actual.Should().Be("1 2");
        }

        [TestMethod]
        public void ShouldScoreOpponentZeroForTie()
        {
            ScoreArray score = new ScoreArray(new List<int> { 3});

            int actual = score.EvaluateAgainstOpponent(3, 0);

            actual.Should().Be(0);
        }

        [TestMethod]
        public void ShouldScoreOpponentZeroForOpponentWin()
        {
            ScoreArray score = new ScoreArray(new List<int> { 5 });

            int actual = score.EvaluateAgainstOpponent(3, 0);

            actual.Should().Be(0);
        }

        [TestMethod]
        public void ShouldScoreOpponenteOnForMyWin()
        {
            ScoreArray score = new ScoreArray(new List<int> { 3 });

            int actual = score.EvaluateAgainstOpponent(5, 0);

            actual.Should().Be(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldAppendScore()
        {
            // arrange
            ScoreArray scoreArray = new ScoreArray(new List<int>());

            // act
            string actual = scoreArray.AppendScore("");

            // assert
            actual.Should().Be("0");
        }
    }

    public class ScoreArray
    {
        private readonly List<int> _scores;
        private int _myScore;

        public ScoreArray(List<int> scores)
        {
            _scores = scores;
        }

        public int GetScore()
        {
            return _myScore;
        }

        public string ScoreAgainstAnother(ScoreArray opponent)
        {
            for (int index = 0; index < _scores.Count; index++)
            {
                _myScore += opponent.EvaluateAgainstOpponent(_scores[index], index);
            }

            return opponent.AppendScore($"{_myScore} ");
        }

        public string AppendScore(string input)
        {
            return string.Format($"{input}{_myScore}");
        }

        public int EvaluateAgainstOpponent(int score, int index)
        {
            if (score == _scores[index]) return 0;

            if (_scores[index] < score) return 1;

            _myScore += 1;
            return 0;
        }
    }
}
