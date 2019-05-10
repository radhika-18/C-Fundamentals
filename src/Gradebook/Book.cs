using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Book
    {
        List<double> gradesList;

        public Book()
        {
            gradesList = new List<double>();
        }

        public void AddGrade(double number)
        {
            gradesList.Add(number);
        }

        public double CalculateAverage()
        {
            double result = 0.0;
            foreach(double grade in gradesList)
            { result += grade; }
            return result/gradesList.Count;
        }

    }
}