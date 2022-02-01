using System;

namespace DataStructuresAlgorithms
{
    /// <summary>
    /// A block of data that points and has access to the next block
    /// </summary>
    public class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node(T data, Node<T> next = null)
        {
            this.data = data;
            this.next = next;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Output Node's data, aswell as the next pointers data
        /// </summary>
        public void Info()
        {
            try
            {
                Console.WriteLine($"Information:\nData:\t\t[{data}]\nNextData:\t[{next.Data}]\n");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Information:\nData:\t\t[{data}]\nNextData:\t[NULL]\n");
            }
        }
    }

    /// <summary>
    /// A sequence of Nodes that can be stored, altered, accessed, and removed
    /// </summary>
    public class LinkedList<T>
    {
        private Node<T> head;
        private int count;

        public LinkedList(Node<T> head)
        {
            this.head = head;
            ++count;
        }

        public LinkedList(T data)
        {
            head = new(data);
            ++count;
        }

        public Node<T> Head
        {
            get { return head; }
        }

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Checks to see if head Node pointer is NULL
        /// </summary>
        /// <returns>True if pointer is NULL, otherwise False</returns>
        public bool IsEmpty()
        {
            return head.Next == null;
        }

        /// <summary>
        /// Finds the Node that holds the given data
        /// </summary>
        /// <param name="data">Data value</param>
        /// <returns>Node with given data</returns>
        public Node<T> Search(T data)
        {
            Node<T> curr = head;

            while (curr != null)
            {
                if (curr.Data.Equals(data))
                    return curr;
                else
                    curr = curr.Next;
            }

            return null;
        }

        /// <summary>
        /// Finds the Node at a given index
        /// </summary>
        /// <param name="index">1 based index to return Node</param>
        /// <returns>Node at given index</returns>
        public Node<T> At(int index)
        {
            if (index == 1)
                return head;
            if (index > count)
                return null;

            Node<T> curr = head;

            int at = 1;

            while (at < index)
            {
                curr = curr.Next;
                ++at;
            }

            return curr;
        }

        /// <summary>
        /// Inserts a Node with given data to the front of the list, setting the head pointer to it
        /// </summary>
        /// <param name="data">Data value</param>
        public void Front(T data)
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
                Front(data);
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

            while (curr.Next != null)
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

            while (curr != null && !found)
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
        public void RemoveAt(int index)
        {
            if (index == 1)
                head = head.Next;

            Node<T> curr = head.Next;
            Node<T> prev = null;
            int at = 2;

            while (curr != null && at <= index)
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

            while (curr.Next.Next != null)
            {
                curr = curr.Next;
            }

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
        /// Visual representation of the list
        /// </summary>
        public void Print()
        {
            Node<T> curr = head;

            while (curr != null)
            {
                if (curr == head)
                    if (curr.Next == null)
                        Console.WriteLine($"[Head: {curr.Data}]->[NULL]");
                    else
                        Console.Write($"[Head: {curr.Data}]->");
                else if (curr.Next == null)
                    Console.WriteLine($"[Tail: {curr.Data}]->[NULL]");
                else
                    Console.Write($"[{curr.Data}]->");

                curr = curr.Next;
            }
        }
    }
}