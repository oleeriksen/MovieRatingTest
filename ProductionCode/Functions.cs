using System;
namespace ProductionCode
{
    public class Functions
    {
        IMovieRepository mRep;
        public Functions(IMovieRepository movieRep)
        {
            mRep = movieRep;
        }

        // Q1: On input N, what are the number of reviews from reviewer N?
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int result = 0;
            foreach (BERating r in mRep.GetAll())
                if (r.Reviewer == reviewer)
                    result++;
            return result;
        }
    }
}
