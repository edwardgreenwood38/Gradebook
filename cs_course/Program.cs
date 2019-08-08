using System;
using System.Collections.Generic;

namespace cs_course
{
    class Program
    {
        static void Main(string[] args)
        {

            InMemoryBook book = new InMemoryBook("Ed's grade book");

            book.GradeAdded += OnGradeAdded; // method for event


            EnterGrade(book);

            var stats = book.GetStats();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrade(IBook book)
        {
            // grade input loop
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }

                try
                {
                    double grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // always runs after try block even with errors
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
