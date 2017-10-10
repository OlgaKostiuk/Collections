using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Lists
{
    public class AList2 : IList
    {
        private int[] arr = new int[30];
        private int start = 15;
        private int end = 15;
        private void addMemory(int n)
        {
            double new_size = n * 1.3;
            double slide_left = n * 0.15;
            int[] temp = new int[(int)new_size];
            for (int i = 0, j = (int)slide_left; i < arr.Length; ++i, ++j)
            {
                temp[j] = arr[i];
            }
            if (start == end)
            {
                start = temp.Length / 2;
                end = temp.Length / 2;
            }
            if (start == 0 || end == arr.Length - 1)
            {
                start += (int)slide_left;
                end += (int)slide_left;
            }
            arr = temp;
        }
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            if (ini.Length > arr.Length)
                addMemory(ini.Length);
            start -= ini.Length / 2;
            end += ini.Length / 2;
            if (ini.Length % 2 == 1)
            {
                --start;
            }
            for (int i = start; i < end; ++i)
            {
                arr[i] = ini[i - start];
            }
        }
        public void Clear()
        {
            start = 15;
            end = 15;
        }
        public int Size()
        {
            return Math.Abs(start - end);
        }
        public int[] ToArray()
        {
            int length = Math.Abs(end - start);
            int[] temp = new int[length];
            for (int i = start; i < end; ++i)
            {
                temp[i - start] = arr[i];
            }
            return temp;
        }
        public override String ToString()
        {
            string answ = "";
            for (int i = start; i < end; ++i)
            {
                answ += arr[i] + " ";
            }
            return answ.Trim();
        }

        public void AddEnd(int val)
        {
            AddPos(Size(), val);
        }
        public void AddPos(int pos, int val)
        {
            if (pos > Size() || pos < 0)
                throw new ArgumentOutOfRangeException();

            if (start == 0 || end == arr.Length - 1)
            {
                addMemory(arr.Length);
            }
            if (start >= (arr.Length - end))
            {
                --start;
                for (int i = 0; i < pos; ++i)
                {
                    arr[i + start] = arr[i + start + 1];
                }
            }
            else
            {
                for (int i = 0; i < Size() - pos; ++i)
                {
                    arr[end - i] = arr[end - i - 1];
                }
                ++end;
            }
            arr[pos + start] = val;
        }
        public void AddStart(int val)
        {
            AddPos(0, val);
        }

        public int DelEnd()
        {
            return DelPos(Size() - 1);
        }
        public int DelPos(int pos)
        {
            if (pos >= Size() || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int t = arr[start + pos];
            if (start < (30 - end))
            {
                for (int i = 0; i < pos; ++i)
                {
                    arr[start + pos - i] = arr[start + pos - i - 1];
                }
                ++start;
            }
            else
            {
                --end;
                for (int i = 0; i < Size() - pos; ++i)
                {
                    arr[end - i - 1] = arr[end - i];
                }

            }
            return t;
        }
        public int DelStart()
        {
            return DelPos(0);
        }

        public int Get(int pos)
        {
            if (pos >= Size() || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return arr[start + pos];
        }
        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            arr[pos + start] = val;
        }

        public int Max()
        {
            return arr[MaxPos() + start];
        }
        public int MaxPos()
        {
            if (start == 15 && end == 15)
            {
                throw new Empty_array_EX();
            }

            int i_max = start;

            for (int i = start + 1; i < end; ++i)
            {
                if (arr[i] > arr[i_max])
                {
                    i_max = i;
                }
            }
            return i_max - start;
        }
        public int Min()
        {
            return arr[MinPos() + start];
        }
        public int MinPos()
        {
            if (start == 15 && end == 15)
            {
                throw new Empty_array_EX();
            }

            int i_min = start;

            for (int i = start + 1; i < end; ++i)
            {
                if (arr[i] < arr[i_min])
                {
                    i_min = i;
                }
            }
            return i_min - start;
        }

        public void Sort()
        {
            for (int i = start; i < end; ++i)
            {
                int j = i;
                while ((j > start) && (arr[j] < arr[j - 1]))
                {
                    AuxFunc.Swap(ref arr[j - 1], ref arr[j]);
                    --j;
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i + start], ref arr[end - i - 1]);
            }
        }
        public void HalfReverse()
        {
            int n = Size();
            int slide = n % 2 == 1 ? 1 : 0;
            for (int i = 0; i < n / 2; ++i)
            {
                AuxFunc.Swap(ref arr[i + start], ref arr[i + n / 2 + slide + start]);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = start; i < end; ++i)
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
