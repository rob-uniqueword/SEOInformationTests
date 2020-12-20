using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SEOInformation.Utilities.Tests
{
    [TestClass()]
    public class HTMLRequestorTests
    {
        [TestMethod()]
        public void GetHtmlAsyncTest()
        {
            var htmlRequestor = new HTMLRequestor();
            var html = htmlRequestor.GetHtmlAsync("https://www.google.co.uk/search?num=100&q=land+registry+search").Result;
            Assert.IsFalse(String.IsNullOrWhiteSpace(html));
        }
    }
}