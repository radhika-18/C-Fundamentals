using System;
using System.Collections.Generic;
using System.IO;

namespace Gradebook {
    public delegate void AddGradeDelegate (object sender, EventArgs gradeAddedEvent);
    public class InMemoryBook : Book {
        public override event AddGradeDelegate GradeAdded;
        private List<double> _gradesList;
        public InMemoryBook () {
            this._gradesList = new List<double> ();
        }
        public InMemoryBook (string name) : base (name) {
            this._gradesList = new List<double> ();
        }
        public override void AddGrade (double grade) {
            if (grade > 0 && grade <= 100) {
                this._gradesList.Add (grade);
                if (GradeAdded != null) {
                    GradeAdded (this, new EventArgs ());
                }
            } else {
                throw new ArgumentException ($"Invalid {nameof(grade)}");
            }
        }
        public override Statistics GetStatistics () {
            Statistics statObj = new Statistics ();
            foreach (double grade in _gradesList) { statObj.CalculateStatistics (grade); }
            return statObj;
        }

    }
    public class DiskBook : Book {
        public override event AddGradeDelegate GradeAdded;

        public DiskBook () { }

        public DiskBook (string name) : base (name) { }

        public override void AddGrade (double grade) {
            if (grade > 0 && grade <= 100) {
                using (var writerObject = File.AppendText ($"{Name}.txt")) {
                    writerObject.WriteLine (grade);
                    if (GradeAdded != null) {
                        GradeAdded (this, new EventArgs ());
                    }
                }
            } else {
                throw new ArgumentException ($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics () {
            Statistics statObj = new Statistics ();
            double grade = 0.0;
            using (var readerObj = File.OpenText ($"{Name}.txt")) {
                var line = readerObj.ReadLine ();
                while (!string.IsNullOrEmpty (line)) {
                    Double.TryParse (line, out grade);
                    statObj.CalculateStatistics (grade);
                    line = readerObj.ReadLine ();
                }
            }
            return statObj;
        }
    }
}