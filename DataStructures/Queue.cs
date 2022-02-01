using System;

namespace DataStructuresAlgorithms
{
    public class Queue<T>
    {
        private Node<T> front, back;
        private int count;

        public Queue(Node<T> front)
        {
            this.front = front;
            back = front;
            ++count;
        }

        public Queue(T data)
        {
            front = new(data);
            back = front;
            ++count;
        }

        public Node<T> Front
        {
            get { return front; }
        }

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Checks to see if there are no more Nodes in the queue
        /// </summary>
        /// <returns>True if front is NULL, otherwise False</returns>
        public bool IsEmpty()
        {
            return front == null;
        }

        /// <summary>
        /// Finds the oldest Node
        /// </summary>
        /// <returns>front Node</returns>
        public Node<T> Peek()
        {
            return front;
        }

        /// <summary>
        /// Places a new Node with given data as the new back Node
        /// </summary>
        /// <param name="data">Data value</param>
        public void Enqueue(T data)
        {
            Node<T> node = new(data);
            back.Next = node;
            back = node;
            if (front == null)
                front = node;
            ++count;
        }

        /// <summary>
        /// Removes the front Node and sets the front Node pointer to the next Node
        /// </summary>
        public void Dequeue()
        {
            front = front.Next;
            if (front == null)
                back = front;
            --count;
        }

        /// <summary>
        /// Empties out the queue
        /// </summary>
        public void Clear()
        {
            front = null;
            back = null;
            count = 0;
        }

        /// <summary>
        /// Visual representation of the queue
        /// </summary>
        public void Print()
        {
            Node<T> curr = front;

            while (curr != null)
            {
                if (curr == front)
                    if (curr.Next == null)
                        Console.WriteLine($"[Front: {curr.Data}]->[NULL]");
                    else
                        Console.Write($"[Front: {curr.Data}]->");
                else if (curr == back)
                    Console.WriteLine($"[Back: {curr.Data}]->[NULL]");
                else
                    Console.Write($"[{curr.Data}]->");

                curr = curr.Next;
            }
        }

    }
}