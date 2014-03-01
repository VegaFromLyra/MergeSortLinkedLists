using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(5);
            Node n2 = new Node(1);
            Node n3 = new Node(6);
            Node n4 = new Node(3);
            Node n5 = new Node(10);

            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;

            Node result = MergeSort(n1);

            Node current = result;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }

        static Node MergeSort(Node n)
        {
            if (n == null || n.Next == null)
            {
                return n;
            }

            Node first = null;
            Node second = null;

            Split(n, ref first, ref second);

            first = MergeSort(first);
            second = MergeSort(second);

            return SortedMerge(first, second);
        }

        static void Split(Node n, ref Node first, ref Node second)
        {
            if (n == null)
            {
                return;
            }

            if (n.Next == null)
            {
                first = n;
                second = null;
                return;
            }

            Node prev = null;
            Node slow = n;
            Node runner = n;
            Node next = n.Next;

            while (runner != null && runner.Next != null)
            {
                prev = slow;
                slow = slow.Next;
                runner = runner.Next.Next;
            }

            first = n;

            // This means off number of elements
            if (runner != null)
            {
                second = slow.Next;
                slow.Next = null;
            }
            // This means even number of elements
            else
            {
                second = prev.Next;
                prev.Next = null;
            }
        }

        static Node SortedMerge(Node a, Node b)
        {
            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            Node result = null;

            if (a.Data < b.Data)
            {
                result = a;
                result.Next = SortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = SortedMerge(a, b.Next);
            }

            return result;
        }

    }

    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }
}
