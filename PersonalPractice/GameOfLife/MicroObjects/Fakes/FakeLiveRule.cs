using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.MicroObjects.Fakes
{
    public class FakeLiveRule : IRule
    {
        public Cell EvaluateTick(Cell cell, List<Cell> neighbors)
        {
            return new LiveCell(cell);
        }
    }
}
