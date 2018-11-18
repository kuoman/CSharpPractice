using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonalPractice.GameOfLife.MicroObjects
{
    [TestClass]
    public class CellsBuilderTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldSetupCells()
        {
            // arrange
            CellsBuilder cellsBuilder = new CellsBuilder();

            // act
            List<Cell> cellList = cellsBuilder.SetupCartesianGrid(3, 3);

            // assert
            cellList.Should().HaveCount(9);
        }
    }

    public interface ICellsBuilder
    {
        List<Cell> SetupCartesianGrid(int rows, int columns);
    }
    
    public class CellsBuilder
    {
        public List<Cell> SetupCartesianGrid(int rows, int columns)
        {
            int count = rows * columns;

            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < count; i++)
            {
                cells.Add(new LiveCell(Guid.NewGuid()));
            }
            
            return cells;
        }
    }
}