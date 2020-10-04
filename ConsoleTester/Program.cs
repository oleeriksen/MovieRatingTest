using System;
using System.Collections.Generic;
using ProductionCode;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovieRepository rep = new MovieRepositoryFileReader();
            List<BERating> ratings = (List<BERating>)rep.GetAll();
            for (int i = 0; i < 10; i++)
            {
                BERating c = ratings[i];
                Console.WriteLine("Reviewer = " + c.Reviewer + " date = " + c.Date);
            }
        }
    }
}
