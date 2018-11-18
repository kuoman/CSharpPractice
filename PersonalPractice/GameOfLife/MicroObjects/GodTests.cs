using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class GodTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldDieWithFewerThanTwo()
        {
            
        }
    }

    public class God
    {
        public God(CellsBuilder cellsBuilder, RelationshipsBuilder relationshipsBuilder, IRule rule)
        {
            List<Cell> cells = cellsBuilder.SetupCartesianGrid(3,3);

            Relationships relationships = relationshipsBuilder.GetCellRelationships(cells, 3, 3);

            List<Cell> nextTurnCells = new List<Cell>();
            
            foreach (Cell cell in cells)
            {
                relationships.GetNeighbors(cell);
                Cell nextTurnCell = cell.GenerateNextTurnStatus(rule, cells);
                
                nextTurnCells.Add(nextTurnCell);
                // update relationship?
            }
        }
        
    }
}