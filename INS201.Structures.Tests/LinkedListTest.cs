using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INS201.Structures;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void LengthShouldDefaultToZero()
        {
            var l = new LinkedList<int>();

            Assert.AreEqual(0, l.Length);
        }
        [TestMethod]
        public void LengthShouldIncreaseOnAddFirst()
        {
            var l = new LinkedList<int>();

            l.AddFirst(new Node<int>(1));

            Assert.AreEqual(1, l.Length);

            l.AddFirst(new Node<int>(2));

            Assert.AreEqual(2, l.Length);

            l.AddFirst(new Node<int>(3));

            Assert.AreEqual(3, l.Length);
        }

        [TestMethod]
        public void LengthShouldIncreaseOnAddLast()
        {
            var l = new LinkedList<int>();

            l.AddLast(new Node<int>(1));

            Assert.AreEqual(1, l.Length);

            l.AddLast(new Node<int>(2));

            Assert.AreEqual(2, l.Length);

            l.AddLast(new Node<int>(3));

            Assert.AreEqual(3, l.Length);
        }

        [TestMethod]
        public void LengthShouldDecreaseOnRemoveFirst()
        {
            var l = new LinkedList<int>();

            l.AddFirst(new Node<int>(1));
            l.AddFirst(new Node<int>(2));
            l.AddFirst(new Node<int>(3));

            Assert.AreEqual(3, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(2, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(1, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(0, l.Length);
        }

        [TestMethod]
        public void LengthShouldDecreaseOnRemoveLast()
        {
            var l = new LinkedList<int>();

            l.AddLast(new Node<int>(1));
            l.AddLast(new Node<int>(2));
            l.AddLast(new Node<int>(3));

            Assert.AreEqual(3, l.Length);

            l.RemoveLast();

            Assert.AreEqual(2, l.Length);

            l.RemoveLast();

            Assert.AreEqual(1, l.Length);

            l.RemoveLast();

            Assert.AreEqual(0, l.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstShouldThrowExceptionIfListIsEmpty()
        {
            var l = new LinkedList<int>();

            l.RemoveFirst();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastShouldThrowExceptionIfListIsEmpty()
        {
            var l = new LinkedList<int>();

            l.RemoveLast();
        }
    }
}
