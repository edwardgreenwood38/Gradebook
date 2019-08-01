using System;
using System.Collections.Generic;

namespace cs_course
{
    class Program
    {
        static void Main(string[] args)
        { 

            Book book = new Book("Ed's grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            book.ShowStats();

            

            
        }
    }
}
