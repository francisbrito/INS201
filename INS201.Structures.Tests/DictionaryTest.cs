using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void LengthDefaultsToZeroTest()
        {
            var d = new Dictionary<string, int>();

            Assert.AreEqual(0, d.Length);
        }

        [TestMethod]
        public void LengthShouldIncreaseOnInsert()
        {
            var d = new Dictionary<string, int>();

            d.Insert("1", 1);

            Assert.AreEqual(1, d.Length);

            d.Insert("2", 2);

            Assert.AreEqual(2, d.Length);

            d.Insert("3", 3);

            Assert.AreEqual(3, d.Length);
        }

        [TestMethod]
        public void LengthShouldDecreaseOnRemove()
        {
            var d = new Dictionary<string, int>();

            d.Insert("1", 1);
            d.Insert("2", 2);
            d.Insert("3", 3);

            Assert.AreEqual(3, d.Length);

            d.Remove("1");

            Assert.AreEqual(2, d.Length);

            d.Remove("2");

            Assert.AreEqual(1, d.Length);

            d.Remove("3");

            Assert.AreEqual(0, d.Length);
        }
    }
}
