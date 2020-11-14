using System;
using System.Text;
using NUnit.Framework;
using DataDataStructures.LL;

namespace NUnitTestProject1
{
    class LinkedListTests
    {
        [TestCase (new int[] {1,2,3,4,5}, 0,1)]
        [TestCase (new int[] {1,2,3,4,5}, 2,3)]
        [TestCase (new int[] {1,2,3,4,5}, 4,5)]
        [TestCase (new int[] {-1,-2,-3,-4,-5}, 4,-5)]
        [TestCase (new int[] {1}, 0,1)]
        public void GetByIndexTest(int[] array, int index, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            
            int actual = linkedList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2,-3, -4, -100 })]
        [TestCase(new int[] { 1 }, 0,0, new int[] {0})]
        public void SetByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual[index] = value;

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3}, new int[] { 3,2,1})]
        [TestCase(new int[] { 1, 2, 3,4 }, new int[] { 4,3, 2, 1 })]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }, new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] {-33,2,-55 }, new int[] {-55,2,-33 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 },5,4 )]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -1)]
        [TestCase(new int[] { 1 }, 1, 0)]
        public void IndexByValueIndexTest(int[] array, int value, int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.AreEqual(expected, actual.IndexByValue(value));

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10,3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9,5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100,-5 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0,1 })]
        [TestCase(new int[] { }, 0, 0, new int[] { 0 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 50, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -50, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
        public void AddByIndexNegativTests(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value)) ;
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4,  new int[] { 1, 2, 3, 4, })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4,  new int[] { -1, -2, -3, -4, })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void PopByIndexTest(int[] array, int index, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.PopByIndex(index);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 50, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -50, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, new int[] { 1, 2, 10, 3, 4, 5 })]
        public void PopByIndexNegativTests(int[] array, int index, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.PopByIndex(index));
        }
    } 
}