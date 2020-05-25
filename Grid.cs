using System;
using System.Text;

namespace ConsoleSnake
{
    public class Grid
    {
        //public readonly int gridSize;
        public readonly int columnLength;
        public readonly int rowLength;

        private bool[,] cells;

        public Grid(int columnLength, int rowLength)
        {
            this.columnLength = columnLength;
            this.rowLength = rowLength;
            cells = new bool[columnLength, rowLength];
        }

        public void PrintGrid()
        {
            StringBuilder grid = new StringBuilder();
            for (int i = 0; i < rowLength; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < columnLength; j++)
                {
                    row.Append(cells[j, i] ? "█" : " ");
                }
                grid.Append(row).Append("\n");
            }
            Console.WriteLine(grid);
        }

        public Vector2 ModifyCell(int x, int y, bool value)
        {
            int columnLength = this.columnLength - 1;
            int rowLength = this.rowLength - 1;
            // forces the position inside the grid with pacman-like warping
            if (x < 0)
            {
                x = Math.Abs(x) % columnLength;
                x = columnLength - x;
            }
            else
                x = (x % columnLength);

            if (y < 0)
            {
                y = Math.Abs(y) % rowLength;
                y = rowLength - y;
            }
            else
                y = (y % rowLength);

            cells[x, y] = value;
            return new Vector2(x, y);
        }

        public bool QueryCell(int x, int y)
        {
            return cells[x, y];
        }

        public void FillGrid()
        {
            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    cells[i, j] = true;
                }
            }
        }
    }
}
