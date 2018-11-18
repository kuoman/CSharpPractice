using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CodeKatas.Compare_Triplets
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestOnesAndZeros()
        {
            // arrange
            ScoreGame aGame = new ScoreGame(new[] { 0, 0, 0 });
            ScoreGame bGame = new ScoreGame(new[] { 1, 1, 1 });

            // act
            string result = bGame.Score(aGame);

            // assert
            Assert.AreEqual("3 0", result);
        }

        [TestMethod]
        public void TestZerosAndOnes()
        {
            // arrange
            ScoreGame bGame = new ScoreGame(new[] { 0, 0, 0 });
            ScoreGame aGame = new ScoreGame(new[] { 1, 1, 1 });

            // act
            string result = bGame.Score(aGame);

            // assert
            Assert.AreEqual("0 3", result);
        }

        [TestMethod]
        public void TestZeros()
        {
            // arrange
            ScoreGame bGame = new ScoreGame(new[] { 0, 0, 0 });
            ScoreGame aGame = new ScoreGame(new[] { 0, 0, 0 });

            // act
            string result = bGame.Score(aGame);

            // assert
            Assert.AreEqual("0 0", result);
        }
    }

    public class ScoreGame
    {
        private readonly int[] _scoreArray;

        public ScoreGame(int[] scoreArray)
        {
            _scoreArray = scoreArray;
            new List<int>();
        }

        private int ScoreAgainstAnother(ScoreGame one, ScoreGame two) => _scoreArray.Where((t, index) => one._scoreArray[index] > two._scoreArray[index]).Count();

        public string Score(ScoreGame other) => $"{ScoreAgainstAnother(this, other)} {ScoreAgainstAnother(other, this)}";
    }
}
