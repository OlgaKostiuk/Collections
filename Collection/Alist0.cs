using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class AList0 : IList
    {
        private int[] arr = new int[0];
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            arr = new int[ini.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = ini[i];
            }
        }
        public int Size()
        {
            return arr.Length;
        }
        public void Clear()
        {
            arr = new int[0];
        }
        public override String ToString()
        {
            string t = "";
            for (int i = 0; i < arr.Length; ++i)
            {
                t += arr[i] + " ";
            }
            return t.Trim();
        }
        public int[] ToArray()
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                temp[i] = arr[i];
            }
            return temp;
        }
        public void AddStart(int val)
        {
            AddPos(0, val);
        }
        public void AddEnd(int val)
        {
            AddPos(arr.Length, val);
        }
        public void AddPos(int pos, int val)
        {
            if (pos > arr.Length || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] temp = new int[arr.Length + 1];
            temp[pos] = val;

            for(int i=0;i<arr.Length;++i)
            {
                if(i<pos)
                {
                    temp[i] = arr[i];
                }
                else
                {
                    temp[i + 1] = arr[i];
                }
            }
            arr = temp;
        }
        public int DelPos(int pos)
        {
            if (pos > arr.Length - 1 || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int t = arr[pos];
            int[] temp = new int[arr.Length - 1];

            for(int i=0;i<temp.Length;++i)
            {
                if (i < pos)
                {
                    temp[i] = arr[i];
                }
                else
                {
                    temp[i] = arr[i + 1];
                }
            }
            arr = temp;
            return t;
        }
        public int DelStart()
        {
            return DelPos(0);
        }
        public int DelEnd()
        {
            return DelPos(arr.Length - 1);
        }
        public int MaxPos()
        {
            if (arr.Length == 0)
            {
                throw new Empty_array_EX();
            }

            int i_max = 0;
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] > arr[i_max])
                {
                    i_max = i;
                }
            }
            return i_max;
        }
        public int Max()
        {
            return arr[MaxPos()];
        }
        public int MinPos()
        {
            if (arr.Length == 0)
            {
                throw new Empty_array_EX();
            }

            int i_min = 0;
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < arr[i_min])
                {
                    i_min = i;
                }
            }
            return i_min;
        }
        public int Min()
        {
            return arr[MinPos()];
        }
        public void Set(int pos, int val)
        {
            if (pos >= arr.Length || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (pos >= arr.Length || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return arr[pos];
        }
        public void Sort()
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                int j = i;
                while ((j > 0) && (arr[j] < arr[j - 1]))
                {
                    AuxFunc.Swap(ref arr[j - 1], ref arr[j]);
                    --j;
                }
            }
        }
        public void Reverse()
        {
            for (int i = 0; i < arr.Length / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i], ref arr[arr.Length - 1 - i]);
            }
        }
        public void HalfReverse()
        {
            int n = arr.Length;
            int slide = n % 2 == 1 ? 1 : 0;
            for (int i = 0; i < n / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i], ref arr[i + n / 2 + slide]);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int item in arr)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
