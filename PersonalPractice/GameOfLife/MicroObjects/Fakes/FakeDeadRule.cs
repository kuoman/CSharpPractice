using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.MicroObjects.Fakes
{
    public class FakeDeadRule : IRule
    {
        public Cell EvaluateTick(Cell cell, List<Cell> neighbors)
        {
            return new DeadCell(cell);
        }
    }
}
