using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.Objects
{
    [TestClass]
    public class RulesTest
    {
        // deprecated
        [TestMethod, TestCategory("Unit")]
        public void ShouldDieWithFewerThanTwo()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> {new Cell {IsAlive = true}};

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.IsAliveNextTurn(cell);

            // assert
            isAliveNextTurn.Should().BeFalse();
        }

        // deprecated
        [TestMethod, TestCategory("Unit")]
        public void ShouldDieWithMoreThanThree()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.IsAliveNextTurn(cell);

            // assert
            isAliveNextTurn.Should().BeFalse();
        }

        // deprecated
        [TestMethod, TestCategory("Unit")]
        public void ShouldLiveIfTwoLiveNeighbors()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.IsAliveNextTurn(cell);


            // assert
            isAliveNextTurn.Should().BeTrue();
        }

        // deprecated
        [TestMethod, TestCategory("Unit")]
        public void ShouldGenisisIfThreeLiveNeighbors()
        {
            // arrange
            
            Cell cell = new Cell();
            cell.IsAlive = false;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.IsAliveNextTurn(cell);


            // assert
            isAliveNextTurn.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldDieWithLessThanTwoLiveNeighbors()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldDie(cell);

            // assert
            isAliveNextTurn.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldDieWithLessThanThreeLiveNeighbors()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldDie(cell);

            // assert
            isAliveNextTurn.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldLiveWithThreeLiveNeighbors()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldDie(cell);

            // assert
            isAliveNextTurn.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldLiveWithTwoLiveNeighbors()
        {
            // arrange
            Cell cell = new Cell();
            cell.IsAlive = true;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldDie(cell);

            // assert
            isAliveNextTurn.Should().BeFalse();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldGenisis()
        {
            // arrange

            Cell cell = new Cell();
            cell.IsAlive = false;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = true }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldGenisis(cell);


            // assert
            isAliveNextTurn.Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotGenisis()
        {
            // arrange

            Cell cell = new Cell();
            cell.IsAlive = false;
            cell.Neighbors = new List<Cell> { new Cell { IsAlive = false }, new Cell { IsAlive = true }, new Cell { IsAlive = true } };

            Rules rules = new Rules();

            // act
            bool isAliveNextTurn = rules.ShouldGenisis(cell);


            // assert
            isAliveNextTurn.Should().BeFalse();
        }
    }
}
