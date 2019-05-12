using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.AddGrade(12.5);
            book.AddGrade(22.5);
            book.AddGrade(32.5);

            var resultStatObj = book.GetStatistics();

            book.ShowStatistics(resultStatObj);
        }
    }
}
