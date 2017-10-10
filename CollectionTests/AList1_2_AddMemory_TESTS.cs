using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;
namespace MyArray_TESTS
{
    [TestClass]
    public class AL1_Add : AList1_2_AddMemory
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class AL2_Add : AList1_2_AddMemory
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public class ALR_Add : AList1_2_AddMemory
    {
        internal override IList MakeList()
        {
            return new AListR();
        }
    }

    [TestClass]
    public abstract class AList1_2_AddMemory
    {
        internal abstract IList MakeList();
        IList li_obj;
        public AList1_2_AddMemory()
        {
            li_obj = MakeList();
        }
        [DataTestMethod]
        [DataRow(30)]
        [DataRow(40)]
        [DataRow(50)]
        public void InitMore30(int n)
        {
            int[] arr = new int[n];
            int[] expected = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = i;
                expected[i] = i;
            }
            li_obj.Init(arr);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(20, 10)]
        [DataRow(20, 20)]
        [DataRow(20, 30)]
        public void AddMore30(int ini_n,int add)
        {
            int[] arr = new int[ini_n];
            int[] expected = new int[ini_n+add];
            for (int i = 0; i < ini_n; ++i)//начальные
            {
                arr[i] = i;
                expected[i] = i;
            }
            li_obj.Init(arr);//инициализация
            for (int i = ini_n; i < ini_n + add; ++i)//вносим в li_obj и в expected
            {
                expected[i] = i;
                li_obj.AddEnd(i);
            }
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }
    }
}
