using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class RuleTests
    {
        [TestMethod]
        public void ShouldDieWithFewerThanTwo()
        {
            LiveCell liveCell = new LiveCell(Guid.NewGuid());
            Rule rule = new Rule();

            Cell returnCell = rule.EvaluateTick(liveCell, new List<Cell> {new LiveCell(Guid.NewGuid())});

            returnCell.Should().BeOfType<DeadCell>();
        }

        [TestMethod]
        public void ShouldLiveIfLiveAndThreeLiveNeighbors()
        {
            LiveCell liveCell = new LiveCell(Guid.NewGuid());
            Rule rule = new Rule();

            Cell returnCell = rule.EvaluateTick(liveCell, new List<Cell> { new LiveCell(Guid.NewGuid()), new LiveCell(Guid.NewGuid()), new LiveCell(Guid.NewGuid())});

            returnCell.Should().BeOfType<LiveCell>();
        }

        [TestMethod]
        public void ShouldLiveIfLiveAndTwoLiveNeighbors()
        {
            LiveCell liveCell = new LiveCell(Guid.NewGuid());
            Rule rule = new Rule();

            Cell returnCell = rule.EvaluateTick(liveCell, new List <Cell> { new LiveCell(Guid.NewGuid()), new LiveCell(Guid.NewGuid())});

            returnCell.Should().BeOfType<LiveCell>();
        }

        [TestMethod]
        public void ShouldGenisisIfThreeLiveNeighbors()
        {
            DeadCell liveCell = new DeadCell(Guid.NewGuid());
            Rule rule = new Rule();

            Cell returnCell = rule.EvaluateTick(liveCell, new List<Cell> { new LiveCell(Guid.NewGuid()), new LiveCell(Guid.NewGuid()), new LiveCell(Guid.NewGuid())});

            returnCell.Should().BeOfType<LiveCell>();
        }
    }

    public interface IRule
    {
        Cell EvaluateTick(Cell cell, List<Cell> neighbors);
    }

    public class Rule : IRule
    {
        public Cell EvaluateTick(Cell cell, List<Cell> neighbors)
        {
            if (neighbors.Count(c => c.IsAlive()) == 3) return new LiveCell(cell);
            if (cell.IsAlive() && neighbors.Count(c => c.IsAlive()) == 2) return new LiveCell(cell);

            return new DeadCell(cell);
        }
    }
}
