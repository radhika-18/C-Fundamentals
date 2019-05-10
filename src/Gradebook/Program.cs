using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            double result;
            Book book = new Book();
            book.AddGrade(12.5);
            book.AddGrade(22.5);
            book.AddGrade(32.5);

            result = book.CalculateAverage();
            Console.WriteLine($"The average grade is {result:n3}!");
        }
    }
}
