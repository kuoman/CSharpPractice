using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.GameOfLife.Objects
{
    [TestClass]
    public class GridManagerTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldSetup9X9CartesianGrid()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells.Should().HaveCount(9);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldPopulateSouthEastNeighbor()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[4].Neighbors.Should().HaveCount(8);
            gridManager.Cells[4].Neighbors[0].Should().Be(gridManager.Cells[5]);
            gridManager.Cells[4].Neighbors[1].Should().Be(gridManager.Cells[3]);
            gridManager.Cells[4].Neighbors[2].Should().Be(gridManager.Cells[7]);
            gridManager.Cells[4].Neighbors[3].Should().Be(gridManager.Cells[1]);
            gridManager.Cells[4].Neighbors[4].Should().Be(gridManager.Cells[2]);
            gridManager.Cells[4].Neighbors[5].Should().Be(gridManager.Cells[0]);
            gridManager.Cells[4].Neighbors[6].Should().Be(gridManager.Cells[8]);
            gridManager.Cells[4].Neighbors[7].Should().Be(gridManager.Cells[6]);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunWest()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[0].Neighbors.Should().HaveCount(3);
            gridManager.Cells[0].Neighbors[0].Should().Be(gridManager.Cells[1]);
            gridManager.Cells[0].Neighbors[1].Should().Be(gridManager.Cells[3]);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForSouthOrEast()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[0].Neighbors.Should().HaveCount(3);
            gridManager.Cells[8].Neighbors[0].Should().Be(gridManager.Cells[7]);
            gridManager.Cells[8].Neighbors[1].Should().Be(gridManager.Cells[5]);
            gridManager.Cells[8].Neighbors[2].Should().Be(gridManager.Cells[4]);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForNorthOrWest()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[0].Neighbors.Should().HaveCount(3);
            gridManager.Cells[0].Neighbors[0].Should().Be(gridManager.Cells[1]);
            gridManager.Cells[0].Neighbors[1].Should().Be(gridManager.Cells[3]);
            gridManager.Cells[0].Neighbors[2].Should().Be(gridManager.Cells[4]);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForNorthOrEast()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[0].Neighbors.Should().HaveCount(3);
            gridManager.Cells[2].Neighbors[0].Should().Be(gridManager.Cells[1]);
            gridManager.Cells[2].Neighbors[1].Should().Be(gridManager.Cells[5]);
            gridManager.Cells[2].Neighbors[2].Should().Be(gridManager.Cells[4]);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForSouthOrWest()
        {
            // arrange
            GridManager gridManager = new GridManager();

            // act
            gridManager.SetupCartesianGrid(3, 3);

            // assert
            gridManager.Cells[0].Neighbors.Should().HaveCount(3);
            gridManager.Cells[6].Neighbors[0].Should().Be(gridManager.Cells[7]);
            gridManager.Cells[6].Neighbors[1].Should().Be(gridManager.Cells[3]);
            gridManager.Cells[6].Neighbors[2].Should().Be(gridManager.Cells[4]);
        }
    }
}
