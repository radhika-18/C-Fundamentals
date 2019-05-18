using System;
using Xunit;

namespace Gradebook.Tests {
    public class BookTests {
        [Fact]
        public void StatisticsTests () {
            var book = new InMemoryBook ();
            book.AddGrade (89.1);
            book.AddGrade (90.5);
            book.AddGrade (77.3);

            var result = book.GetStatistics ();
            Assert.Equal (85.6, result.average, 1);
        }
    }
}