using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;

namespace CollectionTests
{
    [TestClass]
    public class TestAL0 : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new AList0();
        }
    }

    [TestClass]
    public class TestAL1 : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class TestAL2 : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public class TestLL1 : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new LList1();
        }
    }

    [TestClass]
    public class TestALR : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new AListR();
        }
    }

    [TestClass]
    public class TestLL2 : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new LList2();
        }
    }

    [TestClass]
    public class TestLLF : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new LListF();
        }
    }

    [TestClass]
    public class TestLLR : TestListMSTests
    {
        internal override IList MakeList()
        {
            return new LListR();
        }
    }

    [TestClass]
    public abstract class TestListMSTests
    {
        internal abstract IList MakeList();
        IList li_obj;
        public TestListMSTests()
        {
            li_obj = MakeList();
        }
        [TestInitialize]
        public void Test_Init()
        {
            li_obj.Clear();
        }
        [DataTestMethod]
        [DataRow(null)]
        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void TestForeach(int[] input)
        {
            li_obj.Init(input);
            int i = 0;
            foreach (int item in li_obj)
            {
                Assert.AreEqual(input[i++], item);
            }
        }
    }
}
