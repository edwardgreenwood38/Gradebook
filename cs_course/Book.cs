using System;
using System.Collections.Generic;
using System.IO;

namespace cs_course
{
    // normally in a seperate file/class
    public delegate void GradeAddDelegate(object sender, EventArgs args);

    // best practice to put in own file
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        // property member (better flexability)
        public string Name 
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name { get; }
        event GradeAddDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var Writer = File.AppendText($"{Name}.txt"))
            {
                Writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Stats GetStats()
        {
            var result = new Stats();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddDelegate GradeAdded;

        // abstract method
        public abstract void AddGrade(double grade);

        public abstract Stats GetStats();
        
    }

    public class InMemoryBook : Book
    {
         // contructor
         public InMemoryBook(string name) : base(name) 
        {
            //const int x = 1;
            
            //category = ""; // can only set a value in constructors
            grades = new List<double>();
            Name = name;
        }
        
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade) //method
        {
            if (grade <= 100 && grade >= 0)
            { 
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        // a field on book class. a delegate that annousese that a grade has been added
        public override event GradeAddDelegate GradeAdded;

        public override Stats GetStats() // method
        {
            var result = new Stats();
            
            for (int index = 0; index < grades.Count; index++)
            {   
                result.Add(grades[index]);
            }
            
            return result;
        }  

        private List<double> grades; // property


        // readonly string category = "Science"; // good for values that you do not want to have change

        public const string CATEGORY = "Science"; // treated as static
        // only can use from class and not objects
    }
}