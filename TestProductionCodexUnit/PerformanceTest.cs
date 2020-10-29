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

        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }

        [Fact]
        public void Test2()
        {
            Functions f = new Functions(mRep);
            CheckPerformance(() => f.GetNumberOfReviewsFromReviewer(1), 4000);

        }

        [Fact]
        public void Test3()
        {
            Functions f = new Functions(mRep);
            CheckPerformance(() => f.GetAverageRateFromReviewer(1), 4000);

        }

    }

    
}
