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
        public void LengthIncreasesOnInsert()
        {
            var d = new Dictionary<string, int>();

            
        }
    }
}
