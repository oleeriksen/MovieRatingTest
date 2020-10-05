using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductionCode;

namespace TestProductionCode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IMovieRepository> m = new Mock<IMovieRepository>();

            List<BERating> returnValue = new List<BERating>();
            returnValue.Add(new BERating { Reviewer = 1, Movie = 2, Grade = 3 });
            returnValue.Add(new BERating { Reviewer = 2, Movie = 2, Grade = 4 });

            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            Functions mService = new Functions(m.Object);

            int actualResult = mService.GetNumberOfReviewsFromReviewer(3);

            //m.Verify(m => m.GetAll(), Times.Once);

            Assert.IsTrue(actualResult == 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Mock<IMovieRepository> m = new Mock<IMovieRepository>();

            BERating[] returnValue = { new BERating { Reviewer = 1, Movie = 2, Grade = 3 },
                                       new BERating { Reviewer = 1, Movie = 5, Grade = 4 },
                                       new BERating { Reviewer = 2, Movie = 5, Grade = 4 }
            };

            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            Functions mService = new Functions(m.Object);

            double actualResult = mService.GetAverageRateFromReviewer(1);

            //m.Verify(m => m.GetAll(), Times.Once);

            Assert.IsTrue(actualResult == 3.5);
        }
    }
}
