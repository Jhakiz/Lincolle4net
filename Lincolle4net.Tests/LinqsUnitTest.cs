using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace Lincolle4net.Tests
{
    [TestClass]
    public class LinqsUnitTest
    {

        [TestMethod]
        public void ValuedFilter()
        {
            var filter = "DRC";
            var countries = (new List<string>() { "USA", "DRC", "Uganda" })
                .AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);

            Assert.IsNotNull(filter);
            Assert.AreEqual(countries.Count(), 1);
        }

        [TestMethod]
        public void NullOrEmptyFilter()
        {
            var filter = string.Empty;
            var countries = (new List<string>() { "DRC", "Uganda", "USA" })
                .AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);

            Assert.IsTrue(string.IsNullOrEmpty(filter));
            Assert.AreEqual(countries.Count(), 3);
        }
    }
}