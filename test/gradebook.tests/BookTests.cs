using System;
using Xunit;

namespace gradebook.tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange data adn values
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.1);

            // act
            book.ShowStats();
            

            // assert
            Assert.Equal(expect, actual);
        }
    }
}
