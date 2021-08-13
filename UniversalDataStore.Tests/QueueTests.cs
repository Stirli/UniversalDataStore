using NUnit.Framework;
using System;

namespace UniversalDataStore.Tests
{
    public class QueueTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void BufferEncapsulationTest()
        {
            var b = new[] { 1, 2, 3, 4 };
            var q = new Queue<int>(b);
            b[0] = 4;
            Assert.AreNotEqual(4, q.Peek());
        }

        [Test]
        public void PeekWhileEmptyThrowsException()
        {
            var q = new Queue<int>();

            Assert.Throws<InvalidOperationException>(() => q.Peek());
        }
        [Test]
        public void DequeueWhileEmptyThrowsException()
        {
            var q = new Queue<int>();

            Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        }

        [Test]
        public void PeekReturnsFirstWithoutRemovingElement()
        {
            var q = new Queue<int>(new[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(5, q.Count);
            Assert.AreEqual(1, q.Peek());
        }

        [Test]
        public void DequeueRemovesFirstElemnt()
        {
            var q = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(4, q.Count);
        }

        [Test]
        public void EnqueueAddsElement()
        {
            var q = new Queue<int>();
            q.Enqueue(5);
            Assert.AreEqual(5, q.Peek());
        }

        [Test]
        [TestCaseSource(nameof(MakeIntArays))]
        public void EnqueueExtendsBuffer(int[] array)
        {
            var q = new Queue<int>(array);
            q.Enqueue(69);
            Assert.True(q.Contains(69));
        }

        [Test]
        public void ContainsInCircleBufferCheck()
        {
            var q = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            q.Dequeue();
            q.Enqueue(69);
            Assert.True(q.Contains(69));
        }


        private static int[][] MakeIntArays => new[] {
            new int[0],
            new int[] { 1, 2, 3 }
        };
    }
}
