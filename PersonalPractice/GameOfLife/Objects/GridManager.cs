using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.Objects
{
    public class GridManager
    {
        public List<Cell> Cells { get; set; }

        public GridManager()
        {
            Cells = new List<Cell>();
        }

        public void SetupCartesianGrid(int rows, int columns)
        {
            PopulateGrid(rows, columns);

            LinkGridNeighbors(rows, columns);
        }

        private void LinkGridNeighbors(int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Cell cell = Cells[(row * rows) + column];
                    int position = (row * rows) + column;

                    if (AddEast(columns, column))
                    {
                        cell.Neighbors.Add(Cells[position + 1]);
                    }

                    if (AddWest(column))
                    {
                        cell.Neighbors.Add(Cells[position - 1]);
                    }

                    if (AddSouth(rows, row))
                    {
                        cell.Neighbors.Add(Cells[position + rows]);
                    }

                    if (AddNorth(row))
                    {
                        cell.Neighbors.Add(Cells[position - rows]);
                    }

                    if (AddEast(columns, column) && AddNorth(row))
                    {
                        cell.Neighbors.Add(Cells[position - rows + 1]);
                    }

                    if (AddWest(column) && AddNorth(row))
                    {
                        cell.Neighbors.Add(Cells[position - rows - 1]);
                    }

                    if (AddEast(columns, column) && AddSouth(rows, row))
                    {
                        cell.Neighbors.Add(Cells[position + rows + 1]);
                    }

                    if (AddWest(column) && AddSouth(rows, row))
                    {
                        cell.Neighbors.Add(Cells[position + rows - 1]);
                    }
                }
            }
        }

        private void PopulateGrid(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell cell = new Cell();
                    Cells.Add(cell);
                }
            }
        }

        private bool AddNorth(int row) => row != 0;

        private bool AddSouth(int rows, int row) => row != rows -1;

        private bool AddWest(int column) => column != 0;

        private bool AddEast(int columns, int column) => column != columns - 1;
    }
}