using System;
using System.Collections.Generic;

namespace cs_course
{
    class Program
    {
        static void Main(string[] args)
        { 
            double[] numbers = new [] {12.7, 56.2, 32.1, 4.1};
            
            double result;
            List<double> grades = new List<double>() {12.7, 56.2, 32.1, 4.1};
            grades.Add(27.9);

            result = 0.0;
            foreach(double number in grades)
            {
                result += number;
            }

            Console.WriteLine(result / grades.Count);
            
            
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
