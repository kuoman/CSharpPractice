using System.Linq;

namespace PersonalPractice.GameOfLife.Objects
{
    public interface IRules
    {
        bool IsAliveNextTurn(Cell cell);
        bool ShouldDie(Cell cell);
        bool ShouldGenisis(Cell cell);
    }

    public class Rules : IRules
    {
        public bool IsAliveNextTurn(Cell cell)
        {
            if (2 > AliveNeighbors(cell) || AliveNeighbors(cell) > 3) return false;

            if (AliveNeighbors(cell) == 3) return true;

            return cell.IsAlive;
        }

        private int AliveNeighbors(Cell cell) => cell.Neighbors.Count(x => x.IsAlive);

        public bool ShouldDie(Cell cell) => 2 > AliveNeighbors(cell) || AliveNeighbors(cell) > 3;

        public bool ShouldGenisis(Cell cell) => cell.Neighbors.Count(x => x.IsAlive) == 3;
    }
}