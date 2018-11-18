using System;
using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.MicroObjects.Fakes
{
    public class FakeCellsBuilder : ICellsBuilder
    {
        public List<Cell> SetupCartesianGrid(int rows, int columns)
        {
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < 9; i++)
            {
                cells.Add(new LiveCell(Guid.NewGuid()));
            }
            
            return cells;
        }
    }
}