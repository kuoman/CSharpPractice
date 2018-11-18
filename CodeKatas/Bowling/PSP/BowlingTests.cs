using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.Bowling.PSP
{
    [TestClass]
    public class BowlingTests
    {


        //[TestMethod]
        //public void TestPin()
        //{
        //    Assert.IsTrue(new Pin(ball).IsKnockedDown);
        //    Assert.IsFalse(new Pin(null).IsKnockedDown);

        //    Assert.IsTrue(new Frame(new Ball()).IsStrike);

        //    Assert.IsTrue(new Frame(new Ball()).IsSpare);
        //    //
        //    Assert.IsTrue(new Frame(new Ball()).);
        //}


        [TestMethod]
        public void ShouldReturnZero()
        {
            // arrange
            List<int> pins = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            Game game = new Game();

            // act
            int score= game.Score(pins);

            // assert
            score.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSumOpenFrameGame()
        {
            // arrange
            List<int> pins = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(20);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSimpleOneStrikeGame()
        {
            // arrange
            List<int> pins = new List<int> { 10, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 19 elements
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(16);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPerfectGame()
        {
            // arrange
            List<int> pins = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}; // 12 elements
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(300);
        }

        #region
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPerfectGameWth1()
        {
            // arrange
            List<int> pins = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 9, 0 };
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(267);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPerfectGameWth2()
        {
            // arrange
            List<int> pins = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 3, 3, 9, 0 };
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(234);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPerfectGameWth3()
        {
            // arrange
            List<int> pins = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 3, 3, 10, 10, 10 };
            Game game = new Game();

            // act
            int score = game.Score(pins);

            // assert
            score.Should().Be(255);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSimpleOneSpareGamex()
        {
            // arrange
            List<int> pins = new List<int> { 6, 4, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 20 elements
            Game game = new Game();
            // act
            int score = game.Score(pins);
            // assert
            score.Should().Be(50);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSimpleOneSpareGamexx()
        {
            // arrange
            List<int> pins = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 10 }; // 20 elements
            Game game = new Game();
            // act
            int score = game.Score(pins);
            // assert
            score.Should().Be(38);
        }

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSimpleOneSpareGame()
        {
            // arrange
            List<int> pins = new List<int> { 6, 4, 1, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 20 elements
            Game game = new Game();
            // act
            int score = game.Score(pins);
            // assert
            score.Should().Be(22);
        }
    }
    public class Game
    {
        public int Score(List<int> pins)
        {
            int returnValue = 0;

            for (int index = 0; index < pins.Count; index++)
            {
                int pin = pins[index];

                returnValue += pin + ScoreIfStrike(pins, pin, index) + ScoreIfSpare(pins, ref index);
            }

            return returnValue;
        }

        private int ScoreIfSpare(List<int> pins, ref int index)
        {
            if (!IsNotExtraThrow(index) || !IsSpare(pins, index)) return 0;

            index++;
            return pins[index] + pins[index + 1];
        }

        private int ScoreIfStrike(List<int> pins, int pin, int index)
        {
            if (!IsStrike(pin) || !IsNotExtraThrow(index)) return 0;

            return pins[index + 1] + pins[index + 2];
        }
        private bool IsSpare(List<int> pins, int index) => pins[index] + pins[index + 1] == 10;

        private bool IsNotExtraThrow(int index) => index < 9;

        private bool IsStrike(int pin) => pin == 10;
    }
}
