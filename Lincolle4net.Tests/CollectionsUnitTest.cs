using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace Lincolle4net.Tests
{
    [TestClass]
    public class CollectionsUnitTest
    {
        [TestMethod]
        public void ValuedEnumerableFilter()
        {
            var filter = "DRC";
            var countries = (new List<string>() { "USA", "DRC", "Uganda" })
                .AsEnumerable()
                .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);

            Assert.IsNotNull(filter);
            Assert.AreEqual(countries.Count(), 1);
        }

        [TestMethod]
        public void NullOrEmptyEnumerableFilter()
        {
            var filter = string.Empty;
            var countries = (new List<string>() { "DRC", "Uganda", "USA" })
                .AsEnumerable()
                .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);

            Assert.IsTrue(string.IsNullOrEmpty(filter));
            Assert.AreEqual(countries.Count(), 3);
        }

        [TestMethod]
        public void NullOrEmptyListFilter()
        {
            var filter = string.Empty;
            var countries = (new List<string>() { "DRC", "Uganda", "USA" })
                .WhereIf(!string.IsNullOrEmpty(filter), c => c == filter);

            Assert.IsTrue(string.IsNullOrEmpty(filter));
            Assert.AreEqual(countries.Count(), 3);
        }

        [TestMethod]
        public void ValuedCollectionFilter()
        {
            var filter = "da";
            var data = new List<string>() { "Canada", "DRC", "Uganda", "USA" };
            
            var countries = ((ICollection<string>)(data))
                .WhereIf(!string.IsNullOrEmpty(filter), c => c.Contains(filter));

            Assert.IsFalse(string.IsNullOrEmpty(filter));
            Assert.AreEqual(countries.Count(), 2);
        }

        [TestMethod]
        public void ValuedDictionaryFilter()
        {
            var dic = new Dictionary<string, string>
            {
                { "test", "val" },
                { "test2", "val2" }
            };
            var filter = "va";

            var data = dic
                .WhereIf(!string.IsNullOrEmpty(filter), c => c.Value.StartsWith(filter));

            Assert.IsFalse(string.IsNullOrEmpty(filter));
            Assert.AreEqual(data.Count(), 2);

            filter = "val";
             data = dic
                .WhereIf(!string.IsNullOrEmpty(filter), c => c.Value == filter);

            Assert.AreEqual(data.Count(), 1);
            Assert.AreNotEqual(data.Count(), 2);
        }

        [TestMethod]
        public void ValuedStackFilter()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            //
            var filter = 2;

            var data = stk
                .WhereIf(filter > 0, c => c == filter);

            Assert.AreEqual(data.Count(), 1);

            filter = 3;
            data = stk
               .WhereIf(filter > 0, c => c < filter);

            Assert.AreEqual(data.Count(), 2);
        }

    }
}
