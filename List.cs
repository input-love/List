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
        public Node(int value) => Data = value;
        public Node() => Data = default(int);

        public int Data { get; set; }
        public Node Next { get; set; } = null;
        public Node Prev { get; set; } = null;
    }

    public class List : IEnumerable
    {
        public void PushFront(int value)
        {
            if (Head == null)
            {
                CreateFirstNode(value);
            }
            else
            {
                Node node = new Node(value);
                node.Data = value;
                node.Next = Head;

                Head.Prev = node;
                Head = Head.Prev;

                EmptyNode.Next = Head;
            }

            Count++;
        }

        public void PushBack(int value)
        {
            if (Tail == null)
            {
                CreateFirstNode(value);
            }
            else
            {
                Node node = new Node(value);
                node.Data = value;
                node.Prev = Tail;

                Tail.Next = node;
                Tail = Tail.Next;
            }

            Count++;
        }

        public void PopFront()
        {
            if (Count > 1)
            {
                Head = Head.Next;
                Head.Prev = null;

                EmptyNode.Next = Head;
                Count--;
            }
            else if (Count == 1)
            {
                DeletePointer();
                Count--;
            }
        }

        public void PopBack()
        {
            if (Count > 1)
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                Count--;
            }
            else if (Count == 1)
            {
                DeletePointer();
                Count--;
            }
        }

        public void SwapHeadTail()
        {
            if (Count > 2)
            {
                Node tempHeadNext = Head.Next;
                Node tempTailPrev = Tail.Prev;

                Head.Next = null;
                Head.Prev = tempTailPrev;
                tempTailPrev.Next = Head;


                Tail.Next = tempHeadNext;
                Tail.Prev = null;
                tempHeadNext.Prev = Tail;

                SwapPointer();
                EmptyNode.Next = Head;
            }
            else if (Count == 2)
            {
                SwapPointer();
                EmptyNode.Next = Head;

                Head.Next = Tail;
                Head.Prev = null;

                Tail.Next = null;
                Tail.Prev = Head;
            }
        }

        public bool Empty()
        {
            return !(Count > 0);
        }

        private void CreateFirstNode(int value)
        {
            EmptyNode.Next = Head = Tail = new Node(value);
        }

        private void SwapPointer()
        {
            Node node = Head;
            Head = Tail;
            Tail = node;
        }

        private void DeletePointer()
        {
            EmptyNode.Next = Head = Tail = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ListEnumerator GetEnumerator()
        {
            return new ListEnumerator(EmptyNode);
        }

        private Node Head { get; set; } = null;
        private Node Tail { get; set; } = null;

        private Node EmptyNode = new Node();
        public int Count { get; private set; } = 0;
    }

    public class ListEnumerator : IEnumerator
    {
        public ListEnumerator(Node node)
        {
            InitialElement = node;
            CurrentElement = node;
        }
   
        public bool MoveNext()
        {
            CurrentElement = CurrentElement.Next;
            return CurrentElement != null;
        }

        public void Reset()
        {
            CurrentElement = InitialElement;
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
                return CurrentElement;
            }
        }

        private Node InitialElement { get; set; } = null;
        private Node CurrentElement { get; set; } = null;
    }
}