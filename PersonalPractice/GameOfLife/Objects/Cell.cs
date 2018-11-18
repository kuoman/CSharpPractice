using System.Collections.Generic;

namespace PersonalPractice.GameOfLife.Objects
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public List<Cell> Neighbors { get; set; }
        public Cell()
        {
            Neighbors = new List<Cell>();
        }
    }
}