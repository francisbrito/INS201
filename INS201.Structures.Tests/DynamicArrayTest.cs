using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class DynamicArrayTest
    {
        [TestMethod]
        public void LengthDefaultsToZeroTest()
        {
            var d = new DynamicArray<int>();

            Assert.AreEqual(0, d.Length);
        }

        [TestMethod]
        public void LengthTest()
        {
            var d = new DynamicArray<int>();

            d.Add(1);
            d.Add(2);
            d.Add(3);

            Assert.AreEqual(3, d.Length);
        }

        [TestMethod]
        public void AddTest()
        {
            var d = new DynamicArray<int>();

            d.Add(1);
            d.Add(2);
            d.Add(3);

            Assert.AreEqual(1, d.At(0));
            Assert.AreEqual(2, d.At(1));
            Assert.AreEqual(3, d.At(2));

            Assert.AreEqual(3, d.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AtCorrectlyBoundedTest()
        {
            var d = new DynamicArray<int>();

            d.At(-1);
            d.At(1);
        }

        [TestMethod]
        public void PopTest()
        {
            var d = new DynamicArray<int>();

            d.Add(1);
            d.Add(2);
            d.Add(3);

            Assert.AreEqual(3, d.Length);

            Assert.AreEqual(3, d.Pop());
            Assert.AreEqual(2, d.Length);

            Assert.AreEqual(2, d.Pop());
            Assert.AreEqual(1, d.Length);

            Assert.AreEqual(1, d.Pop());
            Assert.AreEqual(0, d.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopIsGuardedTest()
        {
            var d = new DynamicArray<int>();

            d.Pop();
        }

        [TestMethod]
        public void HasTest()
        {
            var d = new DynamicArray<int>();

            Assert.IsFalse(d.Has(1));

            d.Add(1);

            Assert.IsTrue(d.Has(1));
        }

        [TestMethod]
        public void ReplaceTest()
        {
            var d = new DynamicArray<int>();

            d.Add(1);
            d.Add(2);
            d.Add(3);

            d.Replace(0, -1);
            Assert.AreEqual(-1, d.At(0));

            d.Replace(1, -2);
            Assert.AreEqual(-2, d.At(1));

            d.Replace(2, -3);
            Assert.AreEqual(-3, d.At(2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReplaceIsBoundedTest()
        {
            var d = new DynamicArray<int>();

            d.Replace(-1, -1);
            d.Replace(0, -1);
        }

        [TestMethod]
        public void ArrayIndexOperatorTest()
        {
            var d = new DynamicArray<int>();

            d.Add(1);
            d.Add(2);
            d.Add(3);

            Assert.AreEqual(1, d[0]);

            d[0] = -1;

            Assert.AreEqual(-1, d[0]);
        }
    }
}
