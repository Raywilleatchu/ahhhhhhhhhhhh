using System;
using System.Collections.Generic;

namespace GameOfLife
{

    public class Cell
    {
        private bool aliveOrDead { get; set; }
        private int posX;
        private int posY;
        private (int, int) cellPosition;
        public Cell(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
            CellPosition = (PosX, PosY);
        }

        public Cell()
        {

        }


        public bool AliveOrDead
        {
            get
            {
                return aliveOrDead;
            }
            set
            {
                aliveOrDead = value;
            }
        }

        public int PosX
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
            }
        }

        public int PosY
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
            }
        }

        public (int, int) CellPosition
        {
            get
            {
                return cellPosition;
            }
            set
            {
                cellPosition = value;
            }

        }

    }

    public class GOL
    {
        
        public static List<Cell> Grid()
        {
            List<Cell> grid = new List<Cell>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Cell c = new Cell(i, j);
                    grid.Add(c);
                }
            }
            return grid;
        }


        public static void GameOfLife(List<Cell> grid)
        {

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Cell> cells = GOL.Grid();

            foreach (var cell in cells)
            {
                Console.WriteLine($"{cell.CellPosition}");
            }
        }
    }
}
