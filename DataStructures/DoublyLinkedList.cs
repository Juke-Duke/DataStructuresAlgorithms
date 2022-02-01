using System;

namespace DataStructuresAlgorithms
{
    public class DNode<T>
    {
        private T data;
        private DNode<T> prev, next;

        public DNode(T data, DNode<T> prev = null, DNode<T> next = null)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public DNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public DNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Output DNode's data, aswell as the previous and next pointers data
        /// </summary>
        public void Info()
        {
            try
            {
                Console.WriteLine($"Information:\nData:\t\t[{data}]\nPreviousData:\t[{prev.Data}]\nNextData:\t[{next.Data}]\n");
            }
            catch (NullReferenceException)
            {
                if (prev == null && next == null)
                    Console.WriteLine($"Information:\nData:\t\t[{data}]\nPreviousData:\t[NULL]\nNextData:\t[NULL]\n");
                else if (prev == null)
                    Console.WriteLine($"Information:\nData:\t\t[{data}]\nPreviousData:\t[NULL]\nNextData:\t[{next.Data}]\n");
                else if (next == null)
                    Console.WriteLine($"Information:\nData:\t\t[{data}]\nPreviousData:\t[{prev.Data}]\nNextData:\t[NULL]\n");
            }
        }
    }

    public class DoublyLinkedList<T>
    {
        private DNode<T> head;
        private int count;

        public DoublyLinkedList(DNode<T> head)
        {
            this.head = head;
            ++count;
        }

        public DoublyLinkedList(T data)
        {
            head = new(data);
            ++count;
        }

        public DNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Checks to see if head DNode pointer is NULL
        /// </summary>
        /// <returns>True if pointer is NULL, otherwise False</returns>
        public bool IsEmpty()
        {
            return head.Next == null;
        }

        /// <summary>
        /// Finds the DNode that holds the given data
        /// </summary>
        /// <param name="data">Data value</param>
        /// <returns>DNode with given data</returns>
        public DNode<T> Search(T data)
        {
            DNode<T> curr = head;

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
        /// Finds the DNode at a given index
        /// </summary>
        /// <param name="index">1 based index to return DNode</param>
        /// <returns>Node at given index</returns>
        public DNode<T> At(int index)
        {
            if (index == 1)
                return head;
            if (index > count)
                return null;

            DNode<T> curr = head;

            int at = 1;

            while (count < index)
            {
                curr = curr.Next;
                ++at;
            }

            return curr;
        }

        /// <summary>
        /// Inserts a DNode with given data to the front of the doubly list, setting the head pointer to it
        /// </summary>
        /// <param name="data">Data value</param>
        public void Front(T data)
        {
            DNode<T> newHead = new(data, null, head);
            head.Prev = newHead;
            head = newHead;
            ++count;
        }

        /// <summary>
        /// Inserts a DNode with given data to the back of the doubly list, setting its pointer to NULL
        /// </summary>
        /// <param name="data">Data value</param>
        public void Add(T data)
        {
            DNode<T> newTail = new(data);
            DNode<T> curr = head;

            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            newTail.Prev = curr;
            curr.Next = newTail;
            ++count;
        }

        /// <summary>
        /// Inserts a DNode with given data to the desired index of the doubly list
        /// </summary>
        /// <param name="data">Data value</param>
        /// <param name="index">1 based index to place new DNode</param>
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

            DNode<T> newNode = new(data);
            DNode<T> curr = head;
            int at = 1;

            while (count < index)
            {
                curr = curr.Next;
                ++at;
            }

            curr.Prev.Next = newNode;
            newNode.Prev = curr.Prev;
            newNode.Next = curr;
            ++count;
        }

        /// <summary>
        /// Removes the first DNode that includes the given data
        /// </summary>
        /// <param name="data">Data value</param>
        public void Remove(T data)
        {
            DNode<T> curr = head;
            bool found = false;

            if (curr == head && curr.Data.Equals(data))
            {
                found = true;
                head = curr.Next;
                head.Prev = null;
            }

            while (curr != null && !found)
            {
                if (curr.Data.Equals(data))
                {
                    found = true;
                    curr.Prev.Next = curr.Next;
                    curr.Next.Prev = curr.Prev;
                }
                else
                    curr = curr.Next;
            }

            --count;
        }

        /// <summary>
        /// Removes the DNode at the given index
        /// </summary>
        /// <param name="index">1 based index of the removed Node</param>
        public void RemoveAt(int index)
        {
            if (index == 1)
            {
                head = head.Next;
                head.Prev = null;
            }

            DNode<T> curr = head.Next;
            int at = 2;

            while (curr != null && at <= index)
            {
                curr = curr.Next;
                ++at;
            }

            curr.Prev.Next = curr.Next;
            --count;
        }

        /// <summary>
        /// Removes last DNode in the doubly list
        /// </summary>
        public void Pop()
        {
            if (count == 1)
                return;

            DNode<T> curr = head;

            while (curr.Next.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = null;
            --count;
        }

        /// <summary>
        /// Reverses the doubly list
        /// </summary>
        public void Reverse()
        {
            DNode<T> prev = head.Prev;
            DNode<T> curr = head;
            DNode<T> next = head.Next;

            while (curr != null && next != null)
            {
                curr.Prev = next;
                curr.Next = prev;
                prev = curr;
                curr = next;
                next = curr.Next;
            }

            curr.Prev = null;
            curr.Next = prev;
            head = curr;
        }

        /// <summary>
        /// Visual representation of the list
        /// </summary>
        public void Print()
        {
            DNode<T> curr = head;

            while (curr != null)
            {
                if (curr == head)
                    if (curr.Next == null)
                        Console.WriteLine($"[NULL]<-[Head: {curr.Data}]->[NULL]");
                    else
                        Console.Write($"[NULL]<-[Head: {curr.Data}]<->");
                else if (curr.Next == null)
                    Console.WriteLine($"[Tail: {curr.Data}]->[NULL]");
                else
                    Console.Write($"[{curr.Data}]<->");

                curr = curr.Next;
            }
        }
    }
}