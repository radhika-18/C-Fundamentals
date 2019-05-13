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

            int index = 0;
            do
            { 
                statObj.lowgrade = Math.Min(this._gradesList[index], statObj.lowgrade);
                statObj.highgrade = Math.Max(this._gradesList[index], statObj.highgrade);
                statObj.average += this._gradesList[index];
            }while(++index != this._gradesList.Count);
            statObj.average /= this._gradesList.Count;
            return statObj;
        }

        public void ShowStatistics(Statistics statObj)
        {
            Console.WriteLine(value: $"The average of the grades provides is {statObj.average}.\nThe highest grade being {statObj.highgrade} and the lowest grade being {statObj.lowgrade}.");
        }
    }
}