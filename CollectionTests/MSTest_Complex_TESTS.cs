using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;

namespace ArrayListTests
{
    //а) Min, Max, MinPos, MaxPos
    //b) Get, Set
    //c) AddPos, Sort
    //d) AddBegin, Reverse
    //e) AddEnd, HalfReverse
    //f) DelPos, Sort
    //g) DelBegin, Reverse
    //h) DelEnd, HalfReverse
    // 7-10 тестов

    [TestClass]
    public class ArrList0_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new AList0();
        }
    }

    [TestClass]
    public class ArrList1_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class ArrList2_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public class LList1_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new LList1();
        }
    }

    [TestClass]
    public class LList2_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new LList2();
        }
    }

    [TestClass]
    public class LListF_ComplexTest : IArrList_ComplexTest
    {
        internal override IList MakeList()
        {
            return new LListF();
        }
    }

    [TestClass]
    public abstract class IArrList_ComplexTest
    {
        internal abstract IList MakeList();

        IList lst;

        public IArrList_ComplexTest()
        {
            lst = MakeList();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            lst.Clear();
        }

        //а) Min, Max, MinPos, MaxPos

        [DataTestMethod]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, new int[] { 1, -2, 3, 0, 5 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, new int[] { 5, -5, 17, 21, 86, -153, 390 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, new int[] { 5, -5, 17, 21, 86, -153, 390 })]
        public void TestMinMaxMinPosMaxPos(int[] ini, int[] expArr)
        {
            lst.Init(ini);

            lst.Min();
            lst.Max();
            lst.MinPos();
            lst.MaxPos();

            CollectionAssert.AreEqual(ini, lst.ToArray());
        }

        //b) Get, Set

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 0, 0, new int[] { 1 })]
        [DataRow(new int[] { 1, 2 }, 0, 1, new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 2, 3 }, 2, 0, new int[] { 3, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 1, 4, new int[] { 1, 2, 3, 4, 2 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, 4, 1, new int[] { 1, 5, 3, 0, 5 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 1, 6, new int[] { 5, -5, 17, 21, 86, -153, -5 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 5, 0, new int[] { -153, -5, 17, 21, 86, -153, 390 })]
        public void TestGetSet(int[] ini, int posGet, int posSet, int[] exp)
        {
            lst.Init(ini);
            lst.Set(posSet, lst.Get(posGet));

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //c) AddPos, Sort

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 0, 5, new int[] { 1, 5 })]
        [DataRow(new int[] { 1, 2 }, 1, -3, new int[] { -3, 1, 2 })]
        [DataRow(new int[] { 1, 2, 3 }, 2, 0, new int[] { 0, 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 1, 4, new int[] { 1, 2, 3, 4, 4, 5 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, 4, 1, new int[] { -2, 0, 1, 1, 3, 5 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 6, -3, new int[] { -153, -5, -3, 5, 17, 21, 86, 390 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 5, 0, new int[] { -153, -5, 0, 5, 17, 21, 86, 390 })]
        public void TestAddPosSort(int[] ini, int pos, int val, int[] exp)
        {
            lst.Init(ini);

            lst.AddPos(pos, val);
            lst.Sort();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //d) AddBegin, Reverse

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 5, new int[] { 1, 5 })]
        [DataRow(new int[] { 1, 2 }, -3, new int[] { 2, 1, -3 })]
        [DataRow(new int[] { 1, 2, 3 }, 0, new int[] { 3, 2, 1, 0 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5, 4, 3, 2, 1, 4 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, 1, new int[] { 5, 0, 3, -2, 1, 1 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, -3, new int[] { 390, -153, 86, 21, 17, -5, 5, -3 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 0, new int[] { 390, -153, 86, 21, 17, -5, 5, 0 })]
        public void TestAddStartReverse(int[] ini, int val, int[] exp)
        {
            lst.Init(ini);

            lst.AddStart(val);
            lst.Reverse();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //e) AddEnd, HalfReverse

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 5, new int[] { 5, 1 })]
        [DataRow(new int[] { 1, 2 }, -3, new int[] { -3, 2, 1 })]
        [DataRow(new int[] { 1, 2, 3 }, 0, new int[] { 3, 0, 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 4, 5, 4, 1, 2, 3 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, 1, new int[] { 0, 5, 1, 1, -2, 3 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, -3, new int[] { 86, -153, 390, -3, 5, -5, 17, 21 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 0, new int[] { 86, -153, 390, 0, 5, -5, 17, 21 })]
        public void TestAddEndHalfReverse(int[] ini, int val, int[] exp)
        {
            lst.Init(ini);

            lst.AddEnd(val);
            lst.HalfReverse();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //f) DelPos, Sort

        [DataTestMethod]
        [DataRow(new int[] { 1, 5 }, 0, new int[] { 5 })]
        [DataRow(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, 1, new int[] { 0, 1, 3, 5 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 3, new int[] { -153, -5, 5, 17, 86, 390 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, 6, new int[] { -153, -5, 5, 17, 21, 86 })]
        public void TestDelPosSort(int[] ini, int pos, int[] exp)
        {
            lst.Init(ini);

            lst.DelPos(pos);
            lst.Sort();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //g) DelBegin, Reverse

        [DataTestMethod]
        [DataRow(new int[] { 1, 5 }, new int[] { 5 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 2 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, new int[] { 5, 0, 3, -2 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, new int[] { 390, -153, 86, 21, 17, -5 })]
        [DataRow(new int[] { 5, -5, 17, 0, 86, -8, 390 }, new int[] { 390, -8, 86, 0, 17, -5 })]
        public void TestDelStratReverse(int[] ini, int[] exp)
        {
            lst.Init(ini);

            lst.DelStart();
            lst.Reverse();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        //h) DelEnd, HalfReverse

        [DataTestMethod]
        [DataRow(new int[] { 1, 5 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 2, 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 1, 2 })]
        [DataRow(new int[] { 1, -2, 3, 0, 5 }, new int[] { 3, 0, 1, -2 })]
        [DataRow(new int[] { 5, -5, 17, 21, 86, -153, 390 }, new int[] { 21, 86, -153, 5, -5, 17 })]
        [DataRow(new int[] { 5, -5, 17, 0, 86, -8, 390 }, new int[] { 0, 86, -8, 5, -5, 17 })]
        public void TestDelEndHalfReverse(int[] ini, int[] exp)
        {
            lst.Init(ini);

            lst.DelEnd();
            lst.HalfReverse();

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}
