using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;
namespace MyArray_TESTS
{
    [TestClass]
    public class TestAL0_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new AList0();
        }
    }

    [TestClass]
    public class TestAL1_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class TestAL2_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public class TestLL1_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new LList1();
        }
    }

    [TestClass]
    public class TestLL2_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new LList2();
        }
    }

    [TestClass]
    public class TestALR_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new AListR();
        }
    }

    [TestClass]
    public class TestLLF_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new LListF();
        }
    }

    [TestClass]
    public class TestLLR_I : Important_tests
    {
        internal override IList MakeList()
        {
            return new LListR();
        }
    }

    [TestClass]
    public class TestAL0 : Arr_tests
    {
        internal override IList MakeList()
        {
            return new AList0();
        }
    }

    [TestClass]
    public class TestAL1 : Arr_tests
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class TestAL2 : Arr_tests
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public class TestLL1 : Arr_tests
    {
        internal override IList MakeList()
        {
            return new LList1();
        }
    }

    [TestClass]
    public class TestALR : Arr_tests
    {
        internal override IList MakeList()
        {
            return new AListR();
        }
    }

    [TestClass]
    public class TestLL2 : Arr_tests
    {
        internal override IList MakeList()
        {
            return new LList2();
        }
    }

    [TestClass]
    public class TestLLF : Arr_tests
    {
        internal override IList MakeList()
        {
            return new LListF();
        }
    }

    [TestClass]
    public class TestLLR : Arr_tests
    {
        internal override IList MakeList()
        {
            return new LListR();
        }
    }

    [TestClass]
    public abstract class Important_tests
    {
        internal abstract IList MakeList();
        IList li_obj;
        public Important_tests()
        {
            li_obj = MakeList();
        }
        [TestInitialize]
        public void Test_Init()
        {
            li_obj.Clear();
        }

        [DataTestMethod]
        [DataRow(null, new int[] { })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void Init_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1, 2 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7)]
        public void Size_TEST(int[] init, int expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.Size());
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void Clear_TEST(int[] init)
        {
            li_obj.Init(init);
            li_obj.Clear();
            Assert.AreEqual(0, li_obj.Size());
        }
    }
    [TestClass]
    public abstract class Arr_tests
    {
        internal abstract IList MakeList();
        IList li_obj;
        public Arr_tests()
        {
            li_obj = MakeList();
        }
        [TestInitialize]
        public void Test_Init()
        {
            li_obj.Clear();
        }

        [DataTestMethod]
        [DataRow(null, "")]
        [DataRow(new int[] { }, "")]
        [DataRow(new int[] { 1 }, "1")]
        [DataRow(new int[] { 1, 2 }, "1 2")]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, "1 2 3 4 5 6 7")]
        public void ToString_TEST(int[] init, string expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.ToString());
        }

        [DataTestMethod]
        [DataRow(null, new int[] { 1 })]
        [DataRow(new int[] { }, new int[] { 1 })]
        [DataRow(new int[] { 1 }, new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 1, 2, 3, 4, 5, 6, 7 })]
        public void AddStart_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.AddStart(1);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, new int[] { 1 })]
        [DataRow(new int[] { }, new int[] { 1 })]
        [DataRow(new int[] { 1 }, new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2, 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 1 })]
        public void AddEnd_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.AddEnd(1);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, new int[] { 1 }, 0, 1)]
        [DataRow(new int[] { 1 }, new int[] { 2, 1 }, 0, 2)]
        [DataRow(new int[] { 1 }, new int[] { 1, 3 }, 1, 3)]
        [DataRow(new int[] { 1, 2 }, new int[] { 4, 1, 2 }, 0, 4)]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 5, 2 }, 1, 5)]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2, 6 }, 2, 6)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 7 }, 7, 7)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 8, 1, 2, 3, 4, 5, 6, 7 }, 0, 8)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 9, 4, 5, 6, 7 }, 3, 9)]
        public void AddPos_TEST(int[] init, int[] expected, int pos, int val)
        {
            li_obj.Init(init);
            li_obj.AddPos(pos, val);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, -1)]
        [DataRow(new int[] { 1 }, 2)]
        [DataRow(new int[] { 1, 2 }, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPos_TEST_EX(int[] init, int pos)
        {
            li_obj.Init(init);
            li_obj.AddPos(pos, 1);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, new int[] { })]
        [DataRow(new int[] { 1, 2 }, new int[] { 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 })]
        public void DellStart_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.DelStart();
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DellStart_TEST_EX()
        {
            li_obj.Init(new int[] { });
            li_obj.DelStart();
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, new int[] { })]
        [DataRow(new int[] { 1, 2 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void DellEnd_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.DelEnd();
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DellEnd_TEST_EX()
        {
            li_obj.Init(new int[] { });
            li_obj.DelEnd();
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, new int[] { }, 0, 1)]
        [DataRow(new int[] { 1, 2 }, new int[] { 1 }, 1, 2)]
        [DataRow(new int[] { 1, 2 }, new int[] { 2 }, 0, 1)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 }, 0, 1)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, 8)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6, 7)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, 3, 4)]
        public void DelPos_TEST(int[] init, int[] expected, int pos, int el)
        {
            li_obj.Init(init);
            Assert.AreEqual(el, li_obj.DelPos(pos));//удалённый елемент
            Assert.AreEqual(expected.Length, li_obj.Size());//размеры массива
            CollectionAssert.AreEqual(expected, li_obj.ToArray());//сами массивы
        }

        [DataTestMethod]
        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { }, -1)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1, 2 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DelPos_TEST_EX(int[] init, int pos)
        {
            li_obj.Init(init);
            li_obj.DelPos(pos);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1, 4 }, 4)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 1 }, 7)]
        public void Max_TEST(int[] init, int expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.Max());
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [ExpectedException(typeof(Empty_array_EX))]
        public void Max_TEST_EX(int[] init)
        {
            li_obj.Init(init);
            li_obj.Max();
        }

        [DataTestMethod]
        [DataRow(new int[] { 4 }, 0)]
        [DataRow(new int[] { 3, 4 }, 1)]
        [DataRow(new int[] { 4, 3, 2, 1, 0, -1 }, 0)]
        public void IMax(int[] init, int expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.MaxPos());
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [ExpectedException(typeof(Empty_array_EX))]
        public void IMax_EX(int[] init)
        {
            li_obj.Init(init);
            li_obj.MaxPos();
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1, 2 }, 1)]
        [DataRow(new int[] { 5, 4, 3, 2, 1, 0 }, 0)]
        public void Min_TEST(int[] init, int expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.Min());
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [ExpectedException(typeof(Empty_array_EX))]
        public void Min_TEST_EX(int[] init)
        {
            li_obj.Init(init);
            li_obj.Min();
        }

        [DataTestMethod]
        [DataRow(new int[] { 4 }, 0)]
        [DataRow(new int[] { 3, 4 }, 0)]
        [DataRow(new int[] { 5, 4, 3, 2, 1, 0 }, 5)]
        public void IMin_TEST(int[] init, int expected)
        {
            li_obj.Init(init);
            Assert.AreEqual(expected, li_obj.MinPos());
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [ExpectedException(typeof(Empty_array_EX))]
        public void IMin_TEST_EX(int[] init)
        {
            li_obj.Init(init);
            li_obj.MinPos();
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 0, 10, new int[] { 10 })]
        [DataRow(new int[] { 1, 2 }, 1, 10, new int[] { 1, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 2, 22, new int[] { 1, 2, 22, 4, 5 })]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, 4, 15, new int[] { 5, 4, 3, 2, 15 })]
        public void Set_TEST(int[] init, int pos, int val, int[] expected)
        {
            li_obj.Init(init);
            li_obj.Set(pos, val);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, 0, 1)]
        [DataRow(new int[] { }, 0, 1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_TEST_EX(int[] init, int pos, int val)
        {
            li_obj.Init(init);
            li_obj.Set(pos, val);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 }, 0, 1)]
        [DataRow(new int[] { 1, 2 }, 1, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 3, 4)]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, 4, 1)]
        public void Get_TEST(int[] init, int pos, int val)
        {
            li_obj.Init(init);
            Assert.AreEqual(val, li_obj.Get(pos));
        }

        [DataTestMethod]
        [DataRow(null, 0, 1)]
        [DataRow(new int[] { }, 0, 1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_TEST_EX(int[] init, int pos, int val)
        {
            li_obj.Init(init);
            li_obj.Get(pos);
        }

        [DataTestMethod]
        [DataRow(null, new int[] { })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 3, 1 }, new int[] { 1, 3 })]
        [DataRow(new int[] { 5, 7, 3, 3, 1 }, new int[] { 1, 3, 3, 5, 7 })]
        public void Sort_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.Sort();
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, new int[] { })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 3, 1 }, new int[] { 1, 3 })]
        [DataRow(new int[] { 5, 7, 3, 3, 1 }, new int[] { 1, 3, 3, 7, 5 })]
        public void Reverse_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.Reverse();
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(null, new int[] { })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        public void HalfReverse_TEST(int[] init, int[] expected)
        {
            li_obj.Init(init);
            li_obj.HalfReverse();
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }
    }
}
