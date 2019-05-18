using System;

namespace Gradebook {
    class Program {
        static void Main (string[] args) {

            IBook iBookObj = null;
            Console.WriteLine ("In Memory or Disk. \n1.Memory\n2.Disk");
            string input = Console.ReadLine ();
            switch (input) {
                case "1":
                    iBookObj = new InMemoryBook ("my Memory Book");
                    break;
                case "2":
                    iBookObj = new DiskBook ("Mydisk Book");
                    break;
                default:
                    break;
            }
            GetStatisticsReport (iBookObj);
        }

        private static void GetStatisticsReport (IBook iBookObj) {
            if (iBookObj.GetType () == typeof (InMemoryBook))
                iBookObj.GradeAdded += OnGradeAddedToMemory;
            else
                iBookObj.GradeAdded += OnGradeAddedToDisk;

            EnterGrades (iBookObj);

            Statistics resultStatObj = iBookObj.GetStatistics ();
            string output = String.Format ($"Book name is {iBookObj.Name}" +
                $"\nThe average of the grades provides is {resultStatObj.average:n2}." +
                $"\nThe highest grade being {resultStatObj.highgrade}" +
                $"\nand the lowest grade being {resultStatObj.lowgrade}.");
            Console.WriteLine (output);
            Console.Read ();
        }

        private static void EnterGrades (IBook book) {
            Console.WriteLine ("Keep entering number and stop by entering Q/q");

            string userInput = Console.ReadLine ().ToString ();
            double grade = 0;
            while (userInput.ToLower () != "q") {
                try {
                    grade = double.Parse (userInput);
                    book.AddGrade (grade);

                } catch (Exception ex) {
                    Console.WriteLine ("Give proper grade. Failed due to " + ex.Message);
                }
                userInput = Console.ReadLine ();
            }
        }

        public static void OnGradeAddedToMemory (object sender, EventArgs e) {
            Console.WriteLine ("GRADE ADDED");
        }

        public static void OnGradeAddedToDisk (object sender, EventArgs e) {
            Console.WriteLine ("GRADE ADDED To File");
        }
    }
}