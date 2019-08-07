using System;
using System.Collections.Generic;

namespace cs_course
{
    // normally in a seperate file/class
    public delegate void GradeAddDelegate(object sender, EventArgs args);
    
    public class Book
    {
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

        public Book(string name) //contructor
        {
            //const int x = 1;
            
            //category = ""; // can only set a value in constructors
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade) //method
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
        public event GradeAddDelegate GradeAdded;

        public Stats GetStats() // method
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (int index = 0; index < grades.Count; index++)
            {
                if (grades[index] == 43.1)
                {
                    break; //continue;
                }
                
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            
            return result;
        }  

        private List<double> grades; // property
        
        // property member (better flexability)
        public string Name
        {
            get; 
            set;
        }

        // readonly string category = "Science"; // good for values that you do not want to have change

        public const string CATEGORY = "Science"; // treated as static
        // only can use from class and not objects
    }
}