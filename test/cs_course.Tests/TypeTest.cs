using System;
using Xunit;

namespace cs_course.tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }
        
        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange data adn values
            Book book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void CSharpPassByValue()
        {
            // arrange data adn values
            Book book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange data adn values
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        
        [Fact]
        public void StringBehaveLikeValue()
        {
            string name = "Edward";
            var upper = MakeUppercase(name);

            Assert.Equal("Edward", name);
            Assert.Equal("EDWARD", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
        
        [Fact]
        public void GetBookReturnsDifferntObjects()
        {
            // arrange data adn values
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act
            
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange data adn values
            Book book1 = GetBook("Book 1");
            Book book2 = book1;

            // act

            // assert
            //Assert.Equal("Book 1", book1.Name);
            //Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
