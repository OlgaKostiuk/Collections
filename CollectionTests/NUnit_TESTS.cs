using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lists;
using NUnit.Compatibility;
using NUnit.Extensions;

namespace TestArrColect
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LListF))]
    [TestFixture(typeof(LListR))]
    public class NUnitTests<TPage> where TPage : IList, new()
    {
        IList list = new TPage();

        [SetUp]
        public void SetUp()
        {
            list.Clear();
        }

        [Test]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1 })]
        public void TestInit(int[] input, int[] res)
        {
            list.Init(input);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestSize(int[] input, int res)
        {
            list.Init(input);
            Assert.AreEqual(res, list.Size());
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 2 })]
        [TestCase(new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 })]
        public void TestClear(int[] input)
        {
            list.Init(input);
            list.Clear();
            Assert.AreEqual(0, list.Size());
        }

        [Test]
        [TestCase(new int[] { }, new int[] { })]
        //[TestCase(new int[] { 2 }, new int[] { 2 })]
        //[TestCase(new int[] { 5, 6 }, new int[] { 5, 6 })]
        //[TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1 })]
        public void TestToArray(int[] input, int[] res)
        {
            list.Init(input);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 2 }, "2")]
        [TestCase(new int[] { 5, 6 }, "5 6")]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, "3 7 4 9 1")]
        public void TestToString(int[] input, string res)
        {
            list.Init(input);
            Assert.AreEqual(res, list.ToString());
        }


        [Test]
        [TestCase(0, new int[] { }, new int[] { 0 }, 1)]
        [TestCase(3, new int[] { 2 }, new int[] { 3, 2 }, 2)]
        [TestCase(7, new int[] { 5, 6 }, new int[] { 7, 5, 6 }, 3)]
        [TestCase(9, new int[] { 3, 7, 4, 9, 1 }, new int[] { 9, 3, 7, 4, 9, 1 }, 6)]
        public void TestAddStart(int elem, int[] input, int[] res, int size)
        {
            list.Init(input);
            list.AddStart(elem);
            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(elem, list.Get(0));
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(3, new int[] { 2 }, new int[] { 2, 3 })]
        [TestCase(4, new int[] { 5, 6 }, new int[] { 5, 6, 4 })]
        [TestCase(8, new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1, 8 })]
        public void TestAddEnd(int elem, int[] input, int[] res)
        {
            list.Init(input);
            list.AddEnd(elem);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null, -1)]
        [TestCase(null, 1)]
        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { }, 1)]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 6)]
        public void TestAddPosExEmpty(int[] input, int pos)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.AddPos(pos, 5));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(0, 1, new int[] { }, new int[] { 1 }, 1)]
        [TestCase(1, 0, new int[] { 2 }, new int[] { 2, 0 }, 2)]
        [TestCase(0, 0, new int[] { 2 }, new int[] { 0, 2 }, 2)]
        [TestCase(0, 3, new int[] { 5, 6 }, new int[] { 3, 5, 6 }, 3)]
        [TestCase(1, 3, new int[] { 5, 6 }, new int[] { 5, 3, 6 }, 3)]
        [TestCase(2, 3, new int[] { 5, 6 }, new int[] { 5, 6, 3 }, 3)]
        [TestCase(0, 4, new int[] { 3, 7, 4, 9, 1 }, new int[] { 4, 3, 7, 4, 9, 1 }, 6)]
        [TestCase(3, 4, new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 4, 9, 1 }, 6)]
        [TestCase(5, 4, new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1, 4 }, 6)]
        public void TestAddPos(int pos, int elem, int[] input, int[] res, int size)
        {
            list.Init(input);
            list.AddPos(pos, elem);
            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(elem, list.Get(pos));
            CollectionAssert.AreEqual(res, list.ToArray());
        }



        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestDelStartExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.DelStart());
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(2, new int[] { 2 }, new int[] { }, 0)]
        [TestCase(5, new int[] { 5, 6 }, new int[] { 6 }, 1)]
        [TestCase(3, new int[] { 3, 7, 4, 9, 1 }, new int[] { 7, 4, 9, 1 }, 4)]
        public void TestDelStart(int val, int[] input, int[] res, int size)
        {
            list.Init(input);
            int delVal = list.DelStart();
            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(val, delVal);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestDelEndExEmpty(int[] input)
        {
            list.Init(input);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.DelEnd());
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(2, new int[] { 2 }, new int[] { }, 0)]
        [TestCase(6, new int[] { 5, 6 }, new int[] { 5 }, 1)]
        [TestCase(1, new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9 }, 4)]
        public void TestDelEnd(int val, int[] input, int[] res, int size)
        {
            list.Init(input);
            int delVal = list.DelEnd();
            Assert.AreEqual(size, list.Size());
            Assert.AreEqual(val, delVal);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 6)]
        public void TestDelPosExIoR(int[] input, int pos)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.DelPos(pos));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestDelPosExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.DelPos(0));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }


        [Test]
        [TestCase(0, 2, new int[] { 2 }, new int[] { }, 0)]
        [TestCase(0, 4, new int[] { 4, 8 }, new int[] { 8 }, 1)]
        [TestCase(1, 8, new int[] { 4, 8 }, new int[] { 4 }, 1)]
        [TestCase(0, 1, new int[] { 1, 9, 2, 4, 7 }, new int[] { 9, 2, 4, 7 }, 4)]
        [TestCase(2, 2, new int[] { 1, 9, 2, 4, 7 }, new int[] { 1, 9, 4, 7 }, 4)]
        [TestCase(4, 7, new int[] { 1, 9, 2, 4, 7 }, new int[] { 1, 9, 2, 4 }, 4)]
        public void TestDelPos(int pos, int val, int[] input, int[] res, int size)
        {
            list.Init(input);
            int delVal = list.DelPos(pos);
            Assert.AreEqual(val, delVal);
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMinExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<Empty_array_EX>(() => list.Min());
            Assert.AreEqual(typeof(Empty_array_EX), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 12, 3 }, 3)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, -15)]
        public void TestMin(int[] arr, int res)
        {
            list.Init(arr);
            Assert.AreEqual(res, list.Min());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMaxExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<Empty_array_EX>(() => list.Max());
            Assert.AreEqual(typeof(Empty_array_EX), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 12, 3 }, 12)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 80)]
        public void TestMax(int[] arr, int res)
        {
            list.Init(arr);
            Assert.AreEqual(res, list.Max());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMinPosExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<Empty_array_EX>(() => list.MinPos());
            Assert.AreEqual(typeof(Empty_array_EX), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 12, 3 }, 1)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 5)]
        public void TestMinPos(int[] arr, int res)
        {
            list.Init(arr);
            Assert.AreEqual(res, list.MinPos());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMaxPosExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<Empty_array_EX>(() => list.MaxPos());
            Assert.AreEqual(typeof(Empty_array_EX), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 12, 3 }, 0)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 4)]
        public void TestMaxPos(int[] arr, int res)
        {
            list.Init(arr);
            Assert.AreEqual(res, list.MaxPos());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestSetExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Set(1, 0));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }


        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestSetExOutRange(int[] input, int pos)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Set(pos, 0));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(0, new int[] { 2 }, new int[] { 0 })]
        [TestCase(0, new int[] { 12, 3 }, new int[] { 0, 3 })]
        [TestCase(1, new int[] { 12, 3 }, new int[] { 12, 0 })]
        [TestCase(0, new int[] { 2, 1, 5, -10 }, new int[] { 0, 1, 5, -10 })]
        [TestCase(2, new int[] { 2, 1, 5, -10 }, new int[] { 2, 1, 0, -10 })]
        [TestCase(3, new int[] { 2, 1, 5, -10 }, new int[] { 2, 1, 5, 0 })]
        public void TestSet(int pos, int[] arr, int[] res)
        {
            list.Init(arr);
            list.Set(pos, 0);
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestGetExEmpty(int[] input)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(0));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestGetExOutRange(int[] input, int pos)
        {
            list.Init(input);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(pos));
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(0, new int[] { 2 }, 2)]
        [TestCase(0, new int[] { 4, 22 }, 4)]
        [TestCase(1, new int[] { 4, 22 }, 22)]
        [TestCase(0, new int[] { 4, 66, 12, 8, 7 }, 4)]
        [TestCase(2, new int[] { 4, 66, 12, 8, 7 }, 12)]
        [TestCase(4, new int[] { 4, 66, 12, 8, 7 }, 7)]
        public void TestGet(int pos, int[] arr, int res)
        {
            list.Init(arr);
            Assert.AreEqual(res, list.Get(pos));
        }


        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, 5 }, new int[] { 5, 9, -15, 80, -10, 0, 1, 2 })]
        public void TestReverse(int[] arr, int[] res)
        {
            list.Init(arr);
            list.Reverse();
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, 80, -15, 9, 5 }, new int[] { -15, 9, 5, 80, 2, 1, 0 })]
        public void SwapHalfesTest(int[] arr, int[] res)
        {
            list.Init(arr);
            list.HalfReverse();
            CollectionAssert.AreEqual(res, list.ToArray());
        }


        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, 80, -15, 9, -15 }, new int[] { -15, -15, 0, 1, 2, 9, 80 })]
        public void TestSort(int[] arr, int[] res)
        {
            list.Init(arr);
            list.Sort();
            CollectionAssert.AreEqual(res, list.ToArray());
        }
    }
}

