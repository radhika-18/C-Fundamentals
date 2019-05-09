using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length>0)
            {
                Console.WriteLine($"Hello there Mr {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello World! here for commit ");
            }
        }
    }
}
