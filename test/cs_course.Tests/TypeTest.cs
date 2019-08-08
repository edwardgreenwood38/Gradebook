using System;
using Xunit;

namespace cs_course.tests
{
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests
    {
        int count = 0;
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            // allow any varible that returns a string or takes a string method
            //log = new WriteLogDelegate(ReturnMessage);
            // log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello"); //invoke as a method
            //Assert.Equal("Hello", result);
            Assert.Equal(3, count);

        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
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
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
        [Fact]
        public void CSharpPassByValue()
        {
            // arrange data adn values
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
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

        private void SetName(InMemoryBook book, string name)
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
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;

            // act

            // assert
            //Assert.Equal("Book 1", book1.Name);
            //Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
