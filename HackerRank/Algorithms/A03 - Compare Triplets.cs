using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HackerRank.Algorithms
{
    [TestClass]
    public class CompareTripletsTests
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

        // first pass with objects
        [TestMethod]
        public void ShouldCompareObjectTouples()
        {
            Score scoreA = new Score(5, 6, 7);
            Score scoreB = new Score(3, 6, 10);

            string actual = scoreA.RankAgainstAnotherScore(scoreB);

            actual.Should().Be("1 1");
        }

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
