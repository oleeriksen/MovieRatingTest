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

            BERating[] returnValue = { new BERating { Reviewer = 1, Movie = 2, Grade = 3 },
                                       new BERating { Reviewer = 2, Movie = 2, Grade = 4 } };

            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            Functions mService = new Functions(m.Object);

            int actualResult = mService.GetNumberOfReviewsFromReviewer(1);

            m.Verify(m => m.GetAll(), Times.Once);

            Assert.IsTrue(actualResult == 1);
        }
    }
}
