using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void LengthDefaultsToZeroTest()
        {
            var s = new Stack<int>();

            Assert.AreEqual(0, s.Length);
        }

        [TestMethod]
        public void Length()
        {
            var s = new Stack<int>();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.AreEqual(3, s.Length);
        }
        [TestMethod]
        public void PushTest()
        {
            var s = new Stack<int>();

            s.Push(1);
            s.Push(2);
            s.Push(3);
        }

        [TestMethod]
        public void PopTest()
        {
            var s = new Stack<int>();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.AreEqual(3, s.Pop());
            Assert.AreEqual(2, s.Length);
            Assert.AreEqual(2, s.Pop());
            Assert.AreEqual(1, s.Length);
            Assert.AreEqual(1, s.Pop());
            Assert.AreEqual(0, s.Length);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopIsGuardedTest()
        {
            var s = new Stack<int>();

            s.Pop();
        }

        [TestMethod]
        public void PeekTest()
        {
            var s = new Stack<int>();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.AreEqual(3, s.Peek());
            Assert.AreEqual(3, s.Length);

            s.Pop();

            Assert.AreEqual(2, s.Peek());
            Assert.AreEqual(2, s.Length);

            s.Pop();

            Assert.AreEqual(1, s.Peek());
            Assert.AreEqual(1, s.Length);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekIsGuardedTest()
        {
            var s = new Stack<int>();

            s.Peek();
        }
    }
}
