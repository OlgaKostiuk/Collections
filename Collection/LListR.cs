using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists 
{
    public class LListR : IList
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
            Node temp = new Node(val);
            if (Size() == 0)
            {
                temp.next = temp;
                temp.prev = temp;
                root = temp;
            }
            else
            {
                temp.next = root;
                temp.prev = root.prev;
                root.prev.next = temp;
                root.prev = temp;
            }  
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new ArgumentOutOfRangeException();

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
                Node newNode = new Node(val);
                newNode.next = cur.next;
                newNode.prev = cur.prev;
                cur.next.prev = newNode;
                cur.next = newNode;
            }
        }

        public void AddStart(int val)
        {
            Node temp = new Node(val);
            if (Size() == 0)
            {
                temp.next = temp;
                temp.prev = temp;
            }
            else
            {
                temp.next = root;
                temp.prev = root.prev;
                root.prev.next = temp;
                root.prev = temp;
            }
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
                return DelStart();
            }
            else
            {
                ret = root.prev.val;
                root.prev.prev.next = root;
                root.prev = root.prev.prev;
            }
            return ret;
        }

        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            if (pos < 0 || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();

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
                root.next.prev = root.prev;
                root.prev.next = root.next;
                root = root.next;
            }
            else
                root = null;

            return ret;
        }

        public int Get(int pos)
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
            if (pos < 0 || pos > Size() - 1)
                throw new ArgumentOutOfRangeException();

            Node cur = root;
            for (int i = 0; i != pos; i++)
            {
                cur = cur.next;
            }
            return cur.val;
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

        private void nodeSwapVal(Node a, Node b)
        {
            int t = a.val;
            a.val = b.val;
            b.val = t;
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
            for (int i = 0; cur.next != root; i++)
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
            for (int i = 0; cur.next != root; i++)
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

            for (int i = 0; i < Size() / 2; ++i)
            {
                nodeSwapVal(getNode(i), getNode(Size() - 1 - i));
            }
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();
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
            while (cur.next != root)
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
                    nodeSwapVal(getNode(j - 1), getNode(j));
                    --j;
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            Node cur = root;
            for (int i = 0; i < Size(); i++)
            {
                temp[i] = cur.val;
                cur = cur.next;
            }
            return temp;
        }

        public override string ToString()
        {
            string ret = "";
            Node cur = root;
            for (int i = 0; i < Size(); i++)
            {
                ret += cur.val + ((i != Size() - 1) ? " " : "");
                cur = cur.next;
            }
            return ret;
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (root == null)
                yield break;

            Node tmp = root;
            do
            {
                yield return tmp.val;
                tmp = tmp.next;
            }
            while (tmp != root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
