using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Node
    {
        public Node(int value)
        {
            data = value;
        }

        public int data { get; set; }
        public Node next { get; set; } = null;
        public Node prev { get; set; } = null;
    }

    public class List : IEnumerable
    {
        public void PushFront(int value)
        {
            if (head == null)
            {
                CreateFirstNode(value);
            }
            else
            {
                Node node = new Node(value);
                node.data = value;
                node.next = head;

                head.prev = node;
                head = head.prev;

                emptyNode.next = head;
            }

            count++;
        }

        public void PushBack(int value)
        {
            if (tail == null)
            {
                CreateFirstNode(value);
            }
            else
            {
                Node node = new Node(value);
                node.data = value;
                node.prev = tail;

                tail.next = node;
                tail = tail.next;
            }

            count++;
        }

        public void PopFront()
        {
            if (count > 1)
            {
                head = head.next;
                head.prev = null;

                emptyNode.next = head;
                count--;
            }
            else if (count == 1)
            {
                DeletePointer();
                count--;
            }
        }

        public void PopBack()
        {
            if (count > 1)
            {
                tail = tail.prev;
                tail.next = null;
                count--;
            }
            else if (count == 1)
            {
                DeletePointer();
                count--;
            }
        }

        public void SwapHeadTail()
        {
            if (count > 2)
            {
                Node tempHeadNext = head.next;
                Node tempTailPrev = tail.prev;

                head.next = null;
                head.prev = tempTailPrev;
                tempTailPrev.next = head;


                tail.next = tempHeadNext;
                tail.prev = null;
                tempHeadNext.prev = tail;

                SwapPointer();
                emptyNode.next = head;
            }
            else if (count == 2)
            {
                SwapPointer();
                emptyNode.next = head;

                head.next = tail;
                head.prev = null;

                tail.next = null;
                tail.prev = head;
            }
        }

        public bool Empty()
        {
            return !(count > 0);
        }

        private void CreateFirstNode(int value)
        {
            emptyNode.next = head = tail = new Node(value);
        }

        private void SwapPointer()
        {
            Node node = head;
            head = tail;
            tail = node;
        }

        private void DeletePointer()
        {
            emptyNode.next = head = tail = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ListEnumerator GetEnumerator()
        {
            return new ListEnumerator(emptyNode);
        }

        private Node head { get; set; } = null;
        private Node tail { get; set; } = null;

        private Node emptyNode = new Node(0);
        public int count { get; private set; } = 0;
    }

    public class ListEnumerator : IEnumerator
    {
        public ListEnumerator(Node node)
        {
            initialElement = node;
            сurrentElement = node;
        }
   
        public bool MoveNext()
        {
            сurrentElement = сurrentElement.next;
            return сurrentElement != null;
        }

        public void Reset()
        {
            сurrentElement = initialElement;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Node Current
        {
            get
            {
                return сurrentElement;
            }
        }

        private Node initialElement { get; set; } = null;
        private Node сurrentElement { get; set; } = null;
    }
}