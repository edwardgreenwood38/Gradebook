using System;
using System.Collections.Generic;

namespace cs_course
{
    public class Book
    {
        public Book(string name) //contructor
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade) //method
        {
            grades.Add(grade);
        }

        public Stats GetStats() // method
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;
            
            return result;
        }  

        private List<double> grades; // property
        public string Name;        
    }
}