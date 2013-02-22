using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void LengthDefaultsToZeroTest()
        {
            var q = new Queue<int>();

            Assert.AreEqual(0, q.Length);
        }

        [TestMethod]
        public void HeadDefaultsToZeroTest()
        {
            var q = new Queue<int>();

            Assert.AreEqual(0, q.Head);
        }

        [TestMethod]
        public void TailDefaultsToZeroTest()
        {
            var q = new Queue<int>();

            Assert.AreEqual(0, q.Tail);
        }

        [TestMethod]
        public void EnqueueTest()
        {
            var q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual(3, q.Length);
        }

        [TestMethod]
        public void DequeueTest()
        {
            var q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual(3, q.Length);

            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(2, q.Length);
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(1, q.Length);
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(0, q.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueIsGuardedTest()
        {
            var q = new Queue<int>();

            q.Dequeue();
        }

        [TestMethod]
        public void PeekTest()
        {
            var q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual(1, q.Peek());

            q.Dequeue();

            Assert.AreEqual(2, q.Peek());

            q.Dequeue();

            Assert.AreEqual(3, q.Peek());

            q.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekIsGuardedTest()
        {
            var q = new Queue<int>();

            q.Peek();
        }
    }
}
