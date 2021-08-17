using DiamondLetters;
using System;
using Xunit;

namespace DiamondLetterTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("A", 0)]
        [InlineData("B", 1)]
        [InlineData("C", 2)]
        [InlineData("Z", 25)]
        public void TestLetterIndex(string letter, int expected)
        {
            int actual = Diamond.LetterIndex(letter);
            Assert.Equal(expected, actual);
        
        
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 5)]
        [InlineData(5, 9)]
        [InlineData(7, 13)]
        public void TestCalcDot(int index, int expected)
        {
            int actual = Diamond.CalculateDots(index);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A", "A", "A")]
        [InlineData("B", "A", ".A.")]
        [InlineData("B", "B", ".B.B.")]
        [InlineData("C", "C", "C...C")]
        [InlineData("D", "B", "..B.B..")]
        [InlineData("D", "D", "D.....D")]

        public void TestDrawLine(string BlockLetter, string Current, string expected)
        {
            string actual = Diamond.DrawLine(BlockLetter, Current);
            Assert.Equal(expected, actual);
        }




    }
}
