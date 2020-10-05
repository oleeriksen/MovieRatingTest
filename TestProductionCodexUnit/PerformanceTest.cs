using System;
using ProductionCode;
using Xunit;

namespace TestProductionCodexUnit
{

    public class PerformanceTest
    {
        private IMovieRepository mRep;

        public PerformanceTest()
        {
            mRep = new MovieRepositoryFileReader();

        }

        [Fact]
        public void Test1()
        {
            Functions f = new Functions(mRep);
            DateTime start = DateTime.Now;
            f.GetNumberOfReviewsFromReviewer(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);

        }

       
    }

    
}
