using System;
using System.Collections.Generic;

namespace cs_course
{
    public class Book
    {
        public Book(string name) //contructor
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade) //method
        {
            grades.Add(grade);
        }

        public void ShowStats() // method
        {
            double result = 0.0;
            double highGrade = double.MinValue;
            double lowGrade = double.MaxValue;

            foreach(double number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            result /= grades.Count;
            Console.WriteLine($"{name}");
            Console.WriteLine($"The average grade is {result:N1}");
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
        }  

        private List<double> grades; // property
        private string name;        
    }
}