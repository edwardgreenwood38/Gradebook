using System;
using System.Collections.Generic;

namespace cs_course
{
    class Program
    {
        static void Main(string[] args)
        { 
            double result;
            List<double> grades = new List<double>() {12.75, 56.23, 32.1, 4.19};
            grades.Add(27.9);

            result = 0.0;
            foreach(double number in grades)
            {
                result += number;
            }

            Console.WriteLine($"The average grade is {result / grades.Count:N1}");
            
            
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
