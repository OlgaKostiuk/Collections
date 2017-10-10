using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lists;
using NUnit.Framework;

namespace CollectionTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    [TestFixture(typeof(LListF))]
    public class ListNUnitTests<TPage> where TPage : IList, new()
    {

        IList list = new TPage();

        [SetUp]
        public void SetUp()
        {
            list.Clear();
        }


        [TestCase(null)]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void TestForeach(int[] input)
        {
            list.Init(input);
            int i = 0;
            foreach (int item in list)
            {
                Assert.AreEqual(input[i++], item);
            }
        }

    }
}
