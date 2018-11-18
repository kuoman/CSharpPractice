using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class RelationshipsTests
    {
        [TestMethod]
        public void ShouldReturnRelationshipsForCell()
        {
            Cell cell1 = new LiveCell(Guid.NewGuid());
            Cell cell2 = new LiveCell(Guid.NewGuid());

            Relationships relationships = new Relationships();

            relationships.CreateNewRelationship(cell1, cell2);

            List<Relationship> neighbors = relationships.GetNeighbors(cell1);

            neighbors.Should().HaveCount(1);
        }

        [TestMethod]
        public void ShouldReturnOnlyRelationshipsForCell()
        {
            Cell cell1 = new LiveCell(Guid.NewGuid());
            Cell cell2 = new LiveCell(Guid.NewGuid());

            Relationships relationships = new Relationships();

            relationships.CreateNewRelationship(cell1, cell2);
            relationships.CreateNewRelationship(cell2, cell2);

            List<Relationship> neighbors = relationships.GetNeighbors(cell1);

            neighbors.Should().HaveCount(1);
        }
    }

    public class Relationships
    {
        private readonly List<Relationship> _relationships = new List<Relationship>();

        public void CreateNewRelationship(Cell cell1, Cell cell2)
        {
            if (_relationships.Any(x => x.IsNeighborOf(cell1) && x.IsNeighborOf(cell2))) return;

            _relationships.Add(new Relationship(cell1, cell2));
        }

        public List<Relationship> GetNeighbors(Cell cell1)
        {
            return _relationships.Where(x => x.IsNeighborOf(cell1)).ToList();
        }
    }
}
