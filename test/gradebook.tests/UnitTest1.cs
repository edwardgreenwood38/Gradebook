using System;
using Xunit;

namespace gradebook.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange data adn values
            int x = 5;
            int y = 2;
            int expect = 7;

            // act
            int actual = x + y;

            // assert
            Assert.Equal(expect, actual);
        }
    }
}
