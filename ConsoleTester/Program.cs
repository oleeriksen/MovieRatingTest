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
            Functions f = new Functions(rep);

            List<BEReviewer> rev = f.GetReviewers();

            for (int i = 0; i < Math.Min(rev.Count, 100); i++)
            {
                BEReviewer c = rev[i];
                Console.WriteLine("Reviewer = " + c.Id + " count = " + c.mRatings.Count);
            }
        }
    }
}
