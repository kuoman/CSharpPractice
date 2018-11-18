using System.Collections.Generic;
using System.Linq;

namespace PersonalPractice.GameOfLife.Objects
{
    public class GameDirector
    {
        private readonly GridManager _gridManager;
        private readonly IRules _rules;

        public GameDirector(GridManager gridManager, IRules rules)
        {
            _gridManager = gridManager;
            _rules = rules;
        }

        public void Tick() // deprecated, not as efficient at the ImprovedTick
        {
            List<Cell> renderedCells = _gridManager.Cells.Where(cell => _rules.IsAliveNextTurn(cell)).ToList();

            foreach (Cell renderedCell in renderedCells.Where(x => x.IsAlive == false))
            {
                renderedCell.IsAlive = true;
            }

            foreach (Cell deadCell in _gridManager.Cells.Where(x => x.IsAlive).Except(renderedCells))
            {
                deadCell.IsAlive = false;
            }
        }

        public void ImprovedTick()
        {
            // should only evaluate all live cells that should die, with 2 or 3 live neighbors.
            List<Cell> cellsToDie = _gridManager.Cells.Where(x => x.IsAlive && _rules.ShouldDie(x)).ToList();

            // will only evaluate dead cells with 3 live neighbors
            List<Cell> cellsToGenisis = _gridManager.Cells.Where(x => !x.IsAlive && _rules.ShouldGenisis(x)).ToList();

            foreach (Cell cell in cellsToDie)
            {
                cell.IsAlive = false;
            }

            foreach (Cell cell in cellsToGenisis)
            {
                cell.IsAlive = true;
            }
        }
    }
}