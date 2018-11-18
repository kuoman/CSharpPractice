using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalPractice.GameOfLife.MicroObjects.Fakes;
using System;
using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void ShouldReturnLiveCellForNextTurn()
        {
            LiveCell liveCell = new LiveCell(Guid.NewGuid());

            Cell returnCell = liveCell.GenerateNextTurnStatus(new FakeLiveRule(), null);

            returnCell.Should().BeOfType<LiveCell>();
        }

        [TestMethod]
        public void ShouldReturnDyingCellForNextTurn()
        {
            LiveCell liveCell = new LiveCell(Guid.NewGuid());

            Cell returnCell = liveCell.GenerateNextTurnStatus(new FakeDeadRule(), null);

            returnCell.Should().BeOfType<DeadCell>();
        }
    }

    public abstract class Cell
    {
        private readonly Guid _id;
        private bool _hasBeenEvaluated;
        private Cell _futureCell;

        protected Cell(Guid id)
        {
            _id = id;
        }

        protected Cell(Cell cell)
        {
            _id = cell._id;
        }

        public abstract bool IsAlive();

        public Cell GenerateNextTurnStatus(IRule rule, List<Cell> neighbors)
        {
            if (_hasBeenEvaluated) return _futureCell;

            _hasBeenEvaluated = true;

            _futureCell = rule.EvaluateTick(this, neighbors);

            return _futureCell;
        }
    }

    public class LiveCell : Cell
    {
        public LiveCell(Guid id) : base(id) { }
        public LiveCell(Cell cell) : base(cell) { }

        public override bool IsAlive() => true;
    }

    public class DeadCell : Cell
    {
        public DeadCell(Guid id) : base(id) { }
        public DeadCell(Cell cell) : base(cell) { }

        public override bool IsAlive() => false;
    }
}
