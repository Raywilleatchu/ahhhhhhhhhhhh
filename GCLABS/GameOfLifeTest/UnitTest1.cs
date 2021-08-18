using System;
using Xunit;
using GameOfLife;
using System.Collections.Generic;

namespace GameOfLifeTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(4, 1, 5)]
        [InlineData(8, 1, 9)]
        [InlineData(14, 2, 5)]

        public void GridTest(int i, int expectedX, int expectedY)
        {
            List<Cell> grid = GOL.Grid();
            Cell actual = grid[i];
            (int, int) expected = (expectedX, expectedY);
            Assert.Equal(expected, actual.CellPosition);
        }


        //[Theory]
        //public void GameOfLifeTest()
        //{

        //}
    }
}
