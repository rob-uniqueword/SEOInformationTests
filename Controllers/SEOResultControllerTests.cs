using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SEOInformation.Utilities;
using System.Collections.Generic;

namespace SEOInformation.Controllers.Tests
{
    [TestClass()]
    public class SEOResultControllerTests
    {
        [TestMethod()]
        public void SEOResultControllerTest()
        {
            var searchString = "testSearchString";
            var targetURL = "testTargetURL";

            var seoResult = new SEOResult("Google", searchString, targetURL, new List<int> { 1 });
            var mockSearchScraper = new Mock<ISearchScraper>();
            var mockSearchScraperFactory = new Mock<ISearchScraperFactory>();
            var mockLogger = new Mock<ILogger<SEOResultController>>();

            mockSearchScraper.Setup(x => x.GetSEOResults(It.IsAny<string>(), It.IsAny<string>())).Returns(seoResult);
            mockSearchScraperFactory.Setup(x => x.GetSearchScraper(It.IsAny<SearchProvider>())).Returns(mockSearchScraper.Object);

            var seoResultController = new SEOResultController(mockLogger.Object, mockSearchScraperFactory.Object);

            var result = seoResultController.Get("Google", searchString, targetURL);

            mockSearchScraperFactory.Verify(x => x.GetSearchScraper(SearchProvider.Google), Times.Once);
            mockSearchScraper.Verify(x => x.GetSEOResults(searchString, targetURL));
            Assert.AreEqual(result, seoResult);
        }
    }
}