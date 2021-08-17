using System;
using Xunit;
using OddEvenKata;

namespace OddEvenKataTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "Odd")]
        [InlineData(2, "Prime")]
        [InlineData(4, "Even")]
        [InlineData(23, "Prime")]
        [InlineData(42, "Even")]
        [InlineData(97, "Prime")]
        [InlineData(57, "Odd")]

        public void IsEvenTest(int num, string expected)
        {
            string actual = OddEven.IsEven(num);
            Assert.Equal(expected, actual);
        }
    }
}
