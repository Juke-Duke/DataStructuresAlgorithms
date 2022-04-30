using System;

namespace DataStructuresAlgorithms
{
    /// <summary>
    /// A block of data that points and has access to the next block
    /// </summary>
    public class Node<T>
    {
        private T data;
        public T Data { get => data; set => data = value; }

        private Node<T> next;
        public Node<T> Next { get => next; set => next = value; }

        public Node() => this.next = null;

        public Node(T data, Node<T> next = null)
        {
            this.data = data;
            this.next = next;
        }

        /// <summary>
        /// Output Node's data, aswell as the next pointers data
        /// </summary>
        public void Info()
        {
            if (next is not null)
                Console.WriteLine($"Information:\nData:\t\t[{Data}]\nNextData:\t[{Next.Data}]\n");
            else
                Console.WriteLine($"Information:\nData:\t\t[{Data}]\nNextData:\t[NULL]\n");
        }
    }

    /// <summary>
    /// A sequence of Nodes that can be stored, altered, accessed, and removed
    /// </summary>
    public class LinkedList<T>
    {
        private Node<T> head;
        public Node<T> Head { get => head; }

        private int count;
        public int Count { get => count; }

        public LinkedList(T data)
        {
            head = new(data);
            ++count;
        }

        public LinkedList(Node<T> head)
        {
            this.head = head;
            ++count;
        }

        public LinkedList(LinkedList<T> copy)
        {
            head = copy.head;
            count = copy.count;
        }

        /// <summary>
        /// Checks to see if head Node pointer is NULL
        /// </summary>
        /// <returns>True if the head is NULL, otherwise False</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Finds the Node at a given index
        /// </summary>
        /// <param name="index">1 based index to return Node</param>
        /// <returns>Node at given index</returns>
        public Node<T> this[int index]
        {
            get
            {
                if (index < 1 || index > count)
                    return null;

                Node<T> curr = head;
                int at = 1;

                while (at < index)
                {
                    curr = curr!.Next;
                    ++at;
                }

                return curr;
            }
        }

        /// <summary>
        /// Finds the Node that holds the given data
        /// </summary>
        /// <param name="data">Data value</param>
        /// <returns>Node with given data</returns>
        public Node<T> Search(T data)
        {
            Node<T> curr = head;

            while (curr is not null)
                if (curr.Data.Equals(data))
                    return curr;
                else
                    curr = curr.Next;

            return null;
        }

        /// <summary>
        /// Inserts a Node with given data to the front of the list, setting the head pointer to it
        /// </summary>
        /// <param name="data">Data value</param>
        public void SetHead(T data)
        {
            Node<T> newHead = new(data, head);
            head = newHead;
            ++count;
        }

        /// <summary>
        /// Inserts a Node with given data to the desired index of the list
        /// </summary>
        /// <param name="data">Data value</param>
        /// <param name="index">1 based index to place new Node</param>
        public void Insert(T data, int index)
        {
            if (index == 1)
            {
                SetHead(data);
                return;
            }

            else if (index - count > 1)
            {
                Add(data);
                return;
            }

            Node<T> newNode = new(data);
            Node<T> prev = null;
            Node<T> curr = head;
            int at = 1;

            while (at < index)
            {
                prev = curr;
                curr = curr.Next;
                ++at;
            }

            prev.Next = newNode;
            newNode.Next = curr;
            ++count;
        }

        /// <summary>
        /// Inserts a Node with given data to the back of the list, setting its pointer to NULL
        /// </summary>
        /// <param name="data">Data value</param>
        public void Add(T data)
        {
            Node<T> newTail = new(data);
            Node<T> curr = head;

            if (curr is null)
            {
                head = newTail;
                ++count;
                return;
            }

            while (curr.Next is not null)
                curr = curr.Next;

            curr.Next = newTail;
            ++count;
        }

        /// <summary>
        /// Removes the first Node that includes the given data
        /// </summary>
        /// <param name="data">Data value</param>
        public void Remove(T data)
        {
            Node<T> curr = head;
            Node<T> prev = null;
            bool found = false;

            if (curr == head && curr.Data.Equals(data))
            {
                found = true;
                head = curr.Next;
            }

            while (curr is not null && !found)
            {
                if (curr.Data.Equals(data))
                {
                    found = true;
                    prev.Next = curr.Next;
                }
                else
                {
                    prev = curr;
                    curr = curr.Next;
                }
            }

            --count;
        }

        /// <summary>
        /// Removes the Node at the given index
        /// </summary>
        /// <param name="index">1 based index of the removed Node</param>
        public void RemoveAt(int index = 1)
        {
            if (index < 1 || index > count)
                throw new IndexOutOfRangeException();

            Node<T> curr = head;
            Node<T> prev = null;
            int at = 1;

            while (curr is not null && at < index)
            {
                prev = curr;
                curr = curr.Next;
                ++at;
            }

            prev.Next = curr.Next;
            --count;
        }

        /// <summary>
        /// Removes last Node in the list
        /// </summary>
        public void Pop()
        {
            if (count == 1)
                return;

            Node<T> curr = head;

            while (curr.Next.Next is not null)
                curr = curr.Next;

            curr.Next = null;
            --count;
        }

        /// <summary>
        /// Reverses the list
        /// </summary>
        public void Reverse()
        {
            Node<T> prev = null;
            Node<T> curr = head;
            Node<T> next = head;

            while (curr != null)
            {
                next = next.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            head = prev;
        }

        /// <summary>
        /// Clears and empties the list
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Visual representation of the list
        /// </summary>
        public void Print()
        {
            Node<T> curr = head;

            while (curr is not null)
            {
                if (curr == head)
                    if (curr.Next is null)
                        Console.WriteLine($"[Head: {curr.Data}]->[NULL]");
                    else
                        Console.Write($"[Head: {curr.Data}]->");
                else if (curr.Next is null)
                    Console.WriteLine($"[Tail: {curr.Data}]->[NULL]");
                else
                    Console.Write($"[{curr.Data}]->");

                curr = curr.Next;
            }
        }
    }
}