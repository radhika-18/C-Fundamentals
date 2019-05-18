namespace Gradebook {
    public class NamedObject {
        public NamedObject () {

        }

        public NamedObject (string name) {
            Name = name;
        }

        public string Name {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook {
        public Book () { }

        public Book (string name) : base (name) { }

        public abstract event AddGradeDelegate GradeAdded;

        public abstract void AddGrade (double grade);

        public abstract Statistics GetStatistics ();
    }

    public interface IBook {
        void AddGrade (double grade);
        Statistics GetStatistics ();
        string Name { get; }
        event AddGradeDelegate GradeAdded;
    }
}