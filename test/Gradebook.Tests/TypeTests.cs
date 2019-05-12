using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ReturnTypeBookObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void DifferentOBjectTest()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Equal("Book1", book1.Name);
           // Assert.Equal("Book2", book2.Name);
           Assert.Same(book1, book2);
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
