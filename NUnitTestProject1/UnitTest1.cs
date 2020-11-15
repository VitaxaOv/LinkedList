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
        [TestCase(new int[] { 1, 2, 3, 4, 5 },0)]
        [TestCase(new int[] { 1, 2, -3, 4, 5 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, -555,-555 },4)]
        public void FindMinIndexTest(int[] array,int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.AreEqual(expected,actual.FindMinIndex());
        }
        [TestCase(new int[] {}, 4)]
        public void FindMinNegativTests(int[] array, int expected )
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<Exception>(() => actual.FindMinIndex());
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2, 333, 4, 5 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, -555, -555 }, 3)]
        public void FindMaxIndexTest(int[] array, int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.AreEqual(expected, actual.FindMaxIndex());
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 333, 4, 5 }, 333)]
        [TestCase(new int[] { 1, 2, 3, 4, -555, -555 }, 4)]
        public void FindMaxTest(int[] array, int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.AreEqual(expected, actual.FindMax());
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 2, 333, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, -555, -555 }, -555)]
        public void FindMinTest(int[] array, int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.AreEqual(expected, actual.FindMin());
        }
        [TestCase(new int[] { }, 4)]
        public void FindMaxNegativTests(int[] array, int expected)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<Exception>(() => actual.FindMaxIndex());
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
        [TestCase(new int[] { 1, 2, 3, 4, 5 },  new int[] {1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, -3, 4, 5 },new int[] {-3, 1, 2,4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, -5 },new int[] {-5, 1, 2, 3, 4,})]
        [TestCase(new int[] {}, new int[] {})]
        public void ArraySortTest(int[] array,int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.ArraySort();

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5,4,3,2,1 })]
        [TestCase(new int[] { 1, 2, -3, 4, 5 }, new int[] { 5,4,2,1,-3 })]
        [TestCase(new int[] { 1, 2, 3, 4, -5 }, new int[] { 4,3,2,1,-5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ArraySortReverseTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.ArraySortReverse();

            Assert.AreEqual(expected, actual);

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
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 4}, new int[] {1,4, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 0, -4 }, new int[] { 1, 2, 0,-4, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 4 }, new int[] { 1, 2, 3, 4, 1,4, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 5, new int[] { 1, 4 }, new int[] { -1, -2, -3, -4, -5,1,4 })]
        public void AddByIndexArrayTest(int[] array, int index, int[] value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddByIndexArray(index, value);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0,3, new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4,1,  new int[] { 1, 2, 3, 4, })]
        public void PopByIndexArrayTest(int[] array, int index, int size, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.PopByIndexArray(index, size);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5, new int[] { 1, 2, 3, 4, })]
        public void PopByIndexArrayNegativTests(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.PopByIndexArray(index, value));
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
        [TestCase(new int[] { 1, 2, 3, 4, 1 },new int[] { 1,2,3,4 })]
        [TestCase(new int[] { 1, 2, 1, 1, 1 }, new int[] { 1,2})]
        [TestCase(new int[] { 1, 2, 3, 4, 5 },new int[] { 1, 2, 3, 4,5 })]
        [TestCase(new int[] { -5, 2, 3, -5, -5 }, new int[] { -5, 2, 3})]
        public void DeleteBiFirstTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteByFirst();
            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 1, 2, 2, 55,22,1 }, new int[] { 1, 2,55,22 })]
        [TestCase(new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 1, 1}, new int[] { 1})]
        [TestCase(new int[] { 1, 2, 3,4 }, new int[] { 1,2,3,4 })]
        public void DeleteEqualTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteEqual();
            Assert.AreEqual(expected, actual);

        }
    } 
}