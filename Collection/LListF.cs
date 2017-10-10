using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class LListF : IList
    {
        class Node
        {
            public int val;
            public Node next = null;
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
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = new Node(val);
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
                cur.next = newNode;
            }
        }

        public void AddStart(int val)
        {
            Node temp = new Node(val);
            temp.next = root;
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
            }
            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new ArgumentOutOfRangeException();


            int ret = root.val;

            if (Size() != 1)
                root = root.next;
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
            return NodeMax(root);
        }

        private int NodeMax(Node p)
        {
            if (p == null)
                throw new Empty_array_EX();
            if (p.next == null)
                return p.val;
            if (p.val > NodeMax(p.next))
                return p.val;
            else
                return NodeMax(p.next);
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
            return NodeMin(root);
        }

        private int NodeMin(Node p)
        {
            if (p == null)
                throw new Empty_array_EX();
            if (p.next == null)
                return p.val;
            if (p.val < NodeMin(p.next))
                return p.val;
            else
                return NodeMin(p.next);
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
            return NodeSize(root);
        }

        private int NodeSize(Node p)
        {
            if (p == null)
                return 0;

            return 1 + NodeSize(p.next);
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
            for (int i = 0; i < Size(); i++)
            {
                temp[i] = Get(i);
            }
            return temp;
        }

        public override String ToString()
        {
            return NodeToString(root);
        }


        private String NodeToString(Node p)
        {
            if (p == null)
                return "";

            String str = "";
            str += p.val + (p.next != null ? " " : "");
            str += NodeToString(p.next);
            //str += p.val + " ";
            return str;
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
