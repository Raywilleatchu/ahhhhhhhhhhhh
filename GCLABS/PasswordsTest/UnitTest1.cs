using System;
using Xunit;
using Passwords;
using System.Linq;

namespace PasswordsTest
{
    public class UnitTest1
    {
        //string test;
        [Theory]
        [InlineData("hunkMan", false)]
        [InlineData("Something1", true)]
        [InlineData("badpass", false)]
        [InlineData("Jumping54", true)]
        [InlineData("Bonus1", false)]
        [InlineData("Poll34", false)]
        [InlineData("boatLover1", true)]
        [InlineData("poll34", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]



        public void PasswordTest(string pass, bool expected)
        {
            bool actual = Password.PasswordMaker(pass);
            Assert.Equal(expected, actual);
        }
    }
}
