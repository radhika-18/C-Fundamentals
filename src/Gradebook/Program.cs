using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            Console.WriteLine("Keep entering number and stop by entering Q/q");
            
            string userInput = Console.ReadLine().ToString();
            double grade = 0;
            while(userInput.ToLower() != "q")
            {
                try
                { 
                    grade = double.Parse(userInput);
                    book.AddGrade(grade);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Give proper grade. Failed due to "+ex.Message);
                }
                userInput = Console.ReadLine();
            }

            var resultStatObj = book.GetStatistics();

            book.ShowStatistics(resultStatObj);
            Console.Read();
        }
    }
}
