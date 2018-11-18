using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.Objects
{
    [TestClass]
    public class GameDirectorTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldTickCellsForTurn()
        {
            // arrange
            GridManager gridManager = new GridManager();
            Cell stayingAliveCell = new Cell{IsAlive = true};
            Cell turningDeadCell = new Cell{IsAlive = true};
            Cell stayingDeadCell = new Cell { IsAlive = false };
            Cell turningAliveCell = new Cell { IsAlive = false };
            gridManager.Cells = new List<Cell> { stayingAliveCell, turningDeadCell, stayingDeadCell, turningAliveCell };

            Mock<IRules> mockRules = new Mock<IRules>();
            mockRules.Setup(x => x.IsAliveNextTurn(stayingAliveCell)).Returns(true);
            mockRules.Setup(x => x.IsAliveNextTurn(turningDeadCell)).Returns(false);
            mockRules.Setup(x => x.IsAliveNextTurn(stayingDeadCell)).Returns(false);
            mockRules.Setup(x => x.IsAliveNextTurn(turningAliveCell)).Returns(true);

            GameDirector gameDirector = new GameDirector(gridManager, mockRules.Object);
            
            // act
            gameDirector.Tick();

            // assert
            stayingAliveCell.IsAlive.Should().BeTrue();
            turningDeadCell.IsAlive.Should().BeFalse();
            stayingDeadCell.IsAlive.Should().BeFalse();
            turningAliveCell.IsAlive.Should().BeTrue();
            mockRules.VerifyAll();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldTickCellsForTurnImproved()
        {
            // arrange
            GridManager gridManager = new GridManager();
            Cell stayingAliveCell = new Cell { IsAlive = true };
            Cell turningDeadCell = new Cell { IsAlive = true };
            Cell stayingDeadCell = new Cell { IsAlive = false };
            Cell turningAliveCell = new Cell { IsAlive = false };
            gridManager.Cells = new List<Cell> { stayingAliveCell, turningDeadCell, stayingDeadCell, turningAliveCell };

            Mock<IRules> mockRules = new Mock<IRules>();
            mockRules.Setup(x => x.ShouldDie(stayingAliveCell)).Returns(false);
            mockRules.Setup(x => x.ShouldDie(turningDeadCell)).Returns(true);
            mockRules.Setup(x => x.ShouldGenisis(stayingDeadCell)).Returns(false);
            mockRules.Setup(x => x.ShouldGenisis(turningAliveCell)).Returns(true);

            GameDirector gameDirector = new GameDirector(gridManager, mockRules.Object);

            // act
            gameDirector.ImprovedTick();

            // assert
            stayingAliveCell.IsAlive.Should().BeTrue();
            turningDeadCell.IsAlive.Should().BeFalse();
            stayingDeadCell.IsAlive.Should().BeFalse();
            turningAliveCell.IsAlive.Should().BeTrue();
            mockRules.VerifyAll();
        }
    }
}
