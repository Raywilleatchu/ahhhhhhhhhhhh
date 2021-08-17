using System;
using Xunit;
using Primes;

namespace PrimesTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5, true)]
        [InlineData(4, false)]
        [InlineData(11, true)]
        [InlineData(12, false)]


        public void IsPrimeTest(int num, bool expected)
        {
            bool acutal = Program.IsPrime(num);
            Assert.Equal(expected, acutal);
        }


        [Theory]
        [InlineData(5, 11)]
        [InlineData(8, 19)]
        [InlineData(17, 59)]
        [InlineData(20, 71)]

        public void PrimeTest(int num, int expected)
        {

            int acutal = Program.GetPrime(num);
            Assert.Equal(expected, acutal);

        }
    }
}
