using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        private List<double> _gradesList;
        public string Name;

        public Book()
        {
            this._gradesList = new List<double>();
        }

        public Book(string name)
        {
            Name = name;
        }
        public void AddGrade(double grade)
        {
            this._gradesList.Add(grade);
        }

        public Statistics GetStatistics()
        {            
            Statistics statObj = new Statistics();
            statObj.average = 0.0;
            statObj.lowgrade = double.MaxValue;
            statObj.highgrade = double.MinValue;            

            foreach(double grade in this._gradesList)
            { 
                statObj.lowgrade = Math.Min(grade, statObj.lowgrade);
                statObj.highgrade = Math.Max(grade, statObj.highgrade);
                statObj.average += grade;
            }
            statObj.average /= this._gradesList.Count;
            return statObj;
        }

        public void ShowStatistics(Statistics statObj)
        {
            Console.WriteLine(value: $"The average of the grades provides is {statObj.average}.\nThe highest grade being {statObj.highgrade} and the lowest grade being {statObj.lowgrade}.");
        }
    }
}