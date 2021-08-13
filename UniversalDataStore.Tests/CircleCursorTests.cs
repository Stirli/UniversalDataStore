using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataStore.Tests
{
    class CircleCursorTests
    {
        [Test]
        public void IncrementTest()
        {
            CircleCursor cursor = new(8);
            cursor++;

            Assert.AreEqual(1, cursor.Value);
        }

        [Test]
        public void CircleIncrementTest()
        {
            CircleCursor cursor = new(8);
            cursor++;

            Assert.AreEqual(1, cursor.Value);
        }

        [Test]
        public void DecrementTest()
        {
            CircleCursor cursor = new(8, 1);
            cursor--;

            Assert.AreEqual(0, cursor.Value);
        }

        [Test]
        public void CircleDecrementTest()
        {
            CircleCursor cursor = new(8);
            cursor--;

            Assert.AreEqual(7, cursor.Value);
        }

        [Test]
        public void EqualsTrueTest()
        {
            CircleCursor c1 = new(5, 2);
            CircleCursor c2 = new(5, 2);

            Assert.True(c1.Equals(c2));
            Assert.True(c1 == c2);
        }

        [Test]
        public void EqualsFalseTest()
        {
            CircleCursor c1 = new(5, 2);
            CircleCursor c2 = new(5, 3);

            Assert.False(c1.Equals(c2));
            Assert.False(c1 == c2);
        }

        [Test]
        public void CastToIntTest()
        {
            CircleCursor c1 = new(5, 2);

            Assert.AreEqual(2, (int)c1);
        }
    }
}
