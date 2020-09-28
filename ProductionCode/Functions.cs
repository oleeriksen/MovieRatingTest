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
