using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class RelationshipTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfNeighbors()
        {
            LiveCell cell1 = new LiveCell(Guid.NewGuid());
            LiveCell cell2 = new LiveCell(Guid.NewGuid());

            Relationship relationship = new Relationship(cell1, cell2);

            relationship.IsNeighborOf(cell1).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueIfOtherNeighbor()
        {
            LiveCell cell1 = new LiveCell(Guid.NewGuid());
            LiveCell cell2 = new LiveCell(Guid.NewGuid());

            Relationship relationship = new Relationship(cell1, cell2);

            relationship.IsNeighborOf(cell2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotNeighbor()
        {
            LiveCell cell1 = new LiveCell(Guid.NewGuid());
            LiveCell cell2 = new LiveCell(Guid.NewGuid());
            DeadCell cell3 = new DeadCell(Guid.NewGuid());

            Relationship relationship = new Relationship(cell1, cell3);

            relationship.IsNeighborOf(cell2).Should().BeFalse();
        }
    }

    public class Relationship
    {
        private readonly Cell _cell1;
        private readonly Cell _cell2;

        public Relationship(Cell cell1, Cell cell2)
        {
            _cell1 = cell1;
            _cell2 = cell2;
        }

        public bool IsNeighborOf(Cell cell)
        {
            if (_cell1 == cell) return true;
            if (_cell2 == cell) return true;

            return false;
        }
    }
}
