using System;
using System.Collections.Generic;
using System.Linq;

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
            int result = mRep.GetAll().Count(r => r.Reviewer == reviewer);
            
            return result;
        }

        // On input N, what is the average rate that reviewer N had given?
        public double GetAverageRateFromReviewer(int reviewer) {
            var s = (from r in mRep.GetAll().Where(r => r.Reviewer == reviewer)
                    select r.Grade);

            return s.Average(r => r);
        }

        public List<BEReviewer> GetReviewers()
        {
            Dictionary<int, BEReviewer> mReviewers = new Dictionary<int, BEReviewer>();
            foreach (BERating r in mRep.GetAll())
            {
                int id = r.Reviewer;
                if (mReviewers.ContainsKey(id) == false)
                {
                    BEReviewer rev = new BEReviewer();
                    rev.Id = id;
                    rev.mRatings = new List<BERating>();
                    rev.mRatings.Add(r);
                    mReviewers.Add(id, rev);
                }
                else
                    mReviewers[id].mRatings.Add(r);
            }
            
            return mReviewers.Values.ToList();

        }
    }
}
