using System;
using Xunit;

namespace Gradebook.Tests {
    public class TypeTests {
        [Fact]
        public void ReturnTypeBookObjects () {
            var book1 = GetBook ("Book1");
            var book2 = GetBook ("Book2");

            Assert.Equal ("Book1", book1.Name);
            Assert.Equal ("Book2", book2.Name);
        }

        [Fact]
        public void DifferentObjectTest () {
            var book1 = GetBook ("Book1");
            var book2 = book1;

            Assert.Equal ("Book1", book1.Name);
            // Assert.Equal("Book2", book2.Name);
            Assert.Same (book1, book2);
        }

        [Fact]
        public void PassTwoDifferentObject () {
            var book1 = GetBook ("Book1");
            SetName (book1, "New Name");

            Assert.Equal ("New Name", book1.Name);
        }

        [Fact]
        public void PassByValue () {
            var book1 = GetBook ("Book1");
            GetBookSetName (book1, "New Name");

            Assert.Equal ("Book1", book1.Name);
        }

        [Fact]
        public void PassByRef () {
            var book1 = GetBook ("Book1");
            GetBookSetName (ref book1, "New Name");

            // Assert.Equal("Book1", book1.Name);  
            Assert.Equal ("New Name", book1.Name);
        }

        private void GetBookSetName (ref InMemoryBook book, string name) {
            book = new InMemoryBook (name);
        }
        private void SetName (InMemoryBook book, string name) {
            book.Name = name;
        }

        private InMemoryBook GetBook (string name) {
            return new InMemoryBook (name);
        }

        private void GetBookSetName (InMemoryBook book, string name) {
            book = new InMemoryBook (name);
        }
    }
}