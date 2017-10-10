using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class LList2 : IList
    {
        class Node
        {
            public int val;
            public Node next = null;
            public Node prev = null;
            public Node(int val)
            {
                this.val = val;
            }
        }
        Node root = null;
        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                Node cur = root;
                Node t = root;
                while (cur.next != null)
                {
                    t = cur;
                    cur = cur.next;
                }
                cur.next = new Node(val);
                cur.prev = t;
            }
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
            {
                throw new ArgumentOutOfRangeException();
            }

            if (pos == 0)
            {
                AddStart(val);
            }
            else if (pos == Size())
            {
                AddEnd(val);
            }
            else
            {
                Node cur = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    cur = cur.next;
                }
                Node t = cur.next;
                Node newNode = new Node(val);
                newNode.next = cur.next;
                newNode.prev = cur;
                cur.next = newNode;
                t.prev = newNode;
                
            }
        }

        public void AddStart(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return;
            }
            Node temp = new Node(val);
            temp.next = root;
            root.prev = temp;
            root = temp;
        }

        public void Clear()
        {
            root = null;
        }

        public int DelEnd()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();

            int ret = 0;

            if (Size() == 1)
            {
                ret = DelStart();
                return ret;
            }
            else
            {
                Node cur = root;
                while (cur.next.next != null)
                {
                    cur = cur.next;
                }
                ret = cur.next.val;
                cur.next = null;
            }
            return ret;
        }

        public int DelPos(int pos)
        {
            if (pos < 0 || pos > Size() - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            int ret = 0;
            if (pos == 0)
            {
                ret = DelStart();
            }
            else if (pos == Size() - 1)
            {
                ret = DelEnd();
            }
            else
            {
                Node cur = root;
                for (int i = 0; i != pos - 1; i++)
                {
                    cur = cur.next;
                }
                ret = cur.next.val;
                cur.next = cur.next.next;
                cur.next.prev = cur;
            }
            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();


            int ret = root.val;

            if (Size() != 1)
            {
                root = root.next;
                root.prev = null;
            }
                
            else
                root = null;

            return ret;
        }

        public int Get(int pos)
        {
            if (pos < 0 || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();

            Node cur = root;
            for (int i = 0; i != pos; i++)
            {
                cur = cur.next;
            }
            return cur.val;
        }

        private void nodeSwapVal(Node a,Node b)
        {
            int t = a.val;
            a.val = b.val;
            b.val = t;
        }

        private Node getNode(int i)
        {
            Node t = root;
            for (int j = 0; j < i; ++j)
            {
                t = t.next;
            }
            return t;
        }

        public void HalfReverse()
        {
            if (Size() <= 1)
                return;

            int n = Size();
            int slide = n % 2 == 1 ? 1 : 0;
            for (int i = 0; i < n / 2; ++i)
            {
                nodeSwapVal(getNode(i), getNode(i + n / 2 + slide));
            }
        }

        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public int Max()
        {
            if (Size() == 0)
                throw new Empty_array_EX();

            int max = root.val;
            Node cur = root;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
                if (cur.val > max)
                    max = cur.val;
            }
            return max;
        }

        public int MaxPos()
        {
            if (Size() == 0)
                throw new Empty_array_EX();

            int ret = 0;
            Node cur = root;
            while (cur.next != null)
            {
                if (cur.val == Max())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public int Min()
        {
            if (Size() == 0)
                throw new Empty_array_EX();

            int min = root.val;
            Node cur = root;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
                if (cur.val < min)
                    min = cur.val;
            }
            return min;
        }

        public int MinPos()
        {
            if (Size() == 0)
                throw new Empty_array_EX();

            int ret = 0;
            Node cur = root;
            while (cur.next != null)
            {
                if (cur.val == Min())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Reverse()
        {
            if (Size() <= 1)
            {
                return;
            }

            for (int i = 0; i < Size()/2; ++i)
            {
                nodeSwapVal(getNode(i), getNode(Size() - 1 - i));
            }
        }
        public void Set(int pos, int val)
        {
            if (pos < 0 || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();

            Node cur = root;
            for (int i = 0; i != pos; i++)
            {
                cur = cur.next;
            }
            cur.val = val;
        }

        public int Size()
        {
            if (root == null)
                return 0;

            int ret = 1;
            Node cur = root;
            while (cur.next != null)
            {
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Sort()
        {
            for (int i = 1; i < Size(); ++i)
            {
                int j = i;
                while ((j > 0) && (Get(j) < Get(j - 1)))
                {
                    nodeSwapVal( getNode(j - 1), getNode(j) );
                    --j;
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            for (int i = 0; i < Size(); i++)
            {
                temp[i] = Get(i);
            }
            return temp;
        }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < Size(); i++)
            {
                ret += Get(i) + ((i != Size() - 1) ? " " : "");
            }
            return ret;
        }

        public IEnumerator<int> GetEnumerator()
        {
            Node temp = root;
            while (temp != null)
            {
                yield return temp.val;
                temp = temp.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
