using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INS201.Structures;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class DequeTest
    {
        [TestMethod]
        public void LengthShouldDefaultToZero()
        {
            var d = new Deque<int>();

            Assert.AreEqual(0, d.Length);
        }

        [TestMethod]
        public void LengthShouldIncreaseOnAddBack()
        {
            var d = new Deque<int>();

            d.AddBack(1);

            Assert.AreEqual(1, d.Length);

            d.AddBack(2);

            Assert.AreEqual(2, d.Length);

            d.AddBack(3);

            Assert.AreEqual(3, d.Length);
        }

        [TestMethod]
        public void LengthShouldIncreaseOnAddFront()
        {
            var d = new Deque<int>();

            d.AddFront(1);

            Assert.AreEqual(1, d.Length);

            d.AddFront(2);

            Assert.AreEqual(2, d.Length);

            d.AddFront(3);

            Assert.AreEqual(3, d.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BackShouldThrowExceptionIfDequeIsEmpty()
        {
            var d = new Deque<int>();

            d.Back();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FrontShouldThrowExceptionIfDequeIsEmpty()
        {
            var d = new Deque<int>();

            d.Front();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AtShouldThrowExceptionIfDequeIsEmpty()
        {
            var d = new Deque<int>();

            d.At(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AtShouldThrowExceptionIfIndexIsInvalid()
        {
            var d = new Deque<int>();
            d.AddBack(1);

            d.At(-1);
            d.At(1);
        }
    }
}
