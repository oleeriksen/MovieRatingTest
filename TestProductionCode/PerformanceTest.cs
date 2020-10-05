using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductionCode;

namespace TestProductionCode
{
    [TestClass]
    public class PerformanceTest
    {
        private static IMovieRepository mRep;

        [ClassInitialize]
        public static void SetupRepo(TestContext tc)
        {
            mRep = new MovieRepositoryFileReader();
        }

        [TestMethod]
        [Timeout(4000)]
        public void Function1() {
            Functions f = new Functions(mRep);

            f.GetNumberOfReviewsFromReviewer(1);

        }
    }
}
