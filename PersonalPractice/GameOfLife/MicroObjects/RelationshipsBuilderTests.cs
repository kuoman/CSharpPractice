using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonalPractice.GameOfLife.MicroObjects.Fakes;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class RelationshipsBuilderTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldPopulateSouthEastNeighbor()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 4;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(8);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[5])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[3])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[7])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[1])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[2])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[0])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[8])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[6])).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunWest()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 0;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(3);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[1])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[3])).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForSouthOrEast()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 8;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(3);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[7])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[5])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[4])).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForNorthOrWest()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 0;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(3);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[1])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[3])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[4])).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForNorthOrEast()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 2;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(3);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[1])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[5])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[4])).Should().BeTrue();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldNotOverrunForSouthOrWest()
        {
            // arrange
            RelationshipsBuilder relationshipsBuilder = new RelationshipsBuilder();
            List<Cell> cells = new FakeCellsBuilder().SetupCartesianGrid(3, 3);

            // act
            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            // assert
            int indexToCheck = 6;
            relationships.GetNeighbors(cells[indexToCheck]).Should().HaveCount(3);
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[7])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[3])).Should().BeTrue();
            relationships.GetNeighbors(cells[indexToCheck]).Any(x => x.IsNeighborOf(cells[4])).Should().BeTrue();
        }
    }

    public class RelationshipsBuilder
    {
        public Relationships GetCellRelationships(List<Cell> cells, int rows, int columns)
        {
            Relationships relationships = new Relationships();

            IterateOverRows(cells, rows, columns, relationships);

            return relationships;
        }
        
        private void IterateOverRows(IReadOnlyList<Cell> cells, int rows, int columns, Relationships relationships)
        {
            for (int row = 0; row < rows; row++)
            {
                IterateOverColumns(cells, rows, columns, row, relationships);
            }
        }

        private void IterateOverColumns(IReadOnlyList<Cell> cells, int rows, int columns, int row, Relationships relationships)
        {
            for (int column = 0; column < columns; column++)
            {
                CreateRelationship(cells, rows, columns, row, relationships, column);
            }
        }

        private void CreateRelationship(IReadOnlyList<Cell> cells, int rows, int columns, int row, Relationships relationships, int column)
        {
            Cell cell = cells [(row * rows) + column];
            int position = (row * rows) + column;

            if (AddEast(columns, column)) relationships.CreateNewRelationship(cell, cells[position + 1]);

            if (AddWest(column)) relationships.CreateNewRelationship(cell, cells[position - 1]);

            if (AddSouth(rows, row)) relationships.CreateNewRelationship(cell, cells[position + rows]);

            if (AddNorth(row)) relationships.CreateNewRelationship(cell, cells[position - rows]);

            if (AddNorthEast(columns, row, column)) relationships.CreateNewRelationship(cell, cells[position - rows + 1]);

            if (AddNorthWest(row, column)) relationships.CreateNewRelationship(cell, cells[position - rows - 1]);

            if (AddSouthEast(rows, columns, row, column)) relationships.CreateNewRelationship(cell, cells[position + rows + 1]);

            if (AddSouthWest(rows, row, column)) relationships.CreateNewRelationship(cell, cells[position + rows - 1]);
        }

        private bool AddSouthWest(int rows, int row, int column) => AddWest(column) && AddSouth(rows, row);

        private bool AddSouthEast(int rows, int columns, int row, int column) => AddEast(columns, column) && AddSouth(rows, row);

        private bool AddNorthWest(int row, int column) => AddWest(column) && AddNorth(row);

        private bool AddNorthEast(int columns, int row, int column) => AddEast(columns, column) && AddNorth(row);

        private bool AddNorth(int row) => row != 0;

        private bool AddSouth(int rows, int row) => row != rows - 1;

        private bool AddWest(int column) => column != 0;

        private bool AddEast(int columns, int column) => column != columns - 1;
    }
}
