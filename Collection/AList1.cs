using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class AList1 : IList
    {
        private int[] arr = new int[10];
        private int top = 0;
        private void addMemory(int n)
        {
            double new_size = n * 1.3;
            int[] temp = new int[(int)new_size];
            for (int i = 0; i < arr.Length; ++i)
            {
                temp[i] = arr[i];
            }
            arr = temp;
        }
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            top = ini.Length;
            if (top >= arr.Length)
                addMemory(ini.Length);
            for (int i = 0; i < top; ++i)
            {
                arr[i] = ini[i];
            }
        }
        public int Size()
        {
            return top;
        }
        public void Clear()
        {
            top = 0;
        }
        public override String ToString()
        {
            string t = "";
            for (int i = 0; i < top; ++i)
            {
                t += arr[i] + " ";
            }
            return t.Trim();
        }
        public int[] ToArray()
        {
            int[] temp = new int[top];
            for (int i = 0; i < top; ++i)
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
            AddPos(top, val);
        }
        public void AddPos(int pos, int val)
        {
            if (pos > top || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (top >= Size() - 1)
                addMemory(arr.Length);
            for (int i = top - 1; i >= pos; --i)
            {
                arr[i + 1] = arr[i];
            }
            arr[pos] = val;
            ++top;
        }
        public int DelPos(int pos)
        {
            if (pos >= top || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int t = arr[pos];
            for (int i = pos; i < top; ++i)
            {
                arr[i] = arr[i + 1];
            }
            --top;
            return t;
        }
        public int DelStart()
        {
            return DelPos(0);
        }
        public int DelEnd()
        {
            return DelPos(top - 1);
        }
        public int MaxPos()
        {
            if (top == 0)
            {
                throw new Empty_array_EX();
            }

            int i_max = 0;
            for (int i = 1; i < top; ++i)
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
            if (top == 0)
            {
                throw new Empty_array_EX();
            }

            int i_min = 0;
            for (int i = 1; i < top; ++i)
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
            if (pos >= top || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (pos >= top || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return arr[pos];
        }
        public void Sort()
        {
            for (int i = 1; i < top; ++i)
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
            for (int i = 0; i < top / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i], ref arr[top - 1 - i]);
            }
        }
        public void HalfReverse()
        {
            int n = top;
            int slide = n % 2 == 1 ? 1 : 0;
            for (int i = 0; i < n / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i], ref arr[i + n / 2 + slide]);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < top; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
