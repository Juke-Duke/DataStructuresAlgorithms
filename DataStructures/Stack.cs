using System;

namespace DataStructuresAlgorithms
{
    public class Stack<T>
    {
        private Node<T> top;
        private int count;

        public Stack() { }

        public Stack(Node<T> top)
        {
            this.top = top;
            ++count;
        }

        public Stack(T data)
        {
            top = new(data);
            ++count;
        }

        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Checks to see if there are no more Nodes in the stack
        /// </summary>
        /// <returns>True if top is NULL, otherwise False</returns>
        public bool IsEmpty()
        {
            return top == null;
        }

        /// <summary>
        /// Finds the newest Node
        /// </summary>
        /// <returns>Top Node</returns>
        public Node<T> Peek()
        {
            return top;
        }

        /// <summary>
        /// Places a new Node with given data as the new top Node
        /// </summary>
        /// <param name="data">Data value</param>
        public void Pile(T data)
        {
            Node<T> node = new(data);
            node.Next = top;
            top = node;
            ++count;
        }

        /// <summary>
        /// Removes the top Node and sets the top Node pointer to the next Node
        /// </summary>
        public void Pop()
        {
            top = top.Next;
            --count;
        }

        /// <summary>
        /// Empties out the stack
        /// </summary>
        public void Clear()
        {
            top = null;
            count = 0;
        }

        /// <summary>
        /// Visual representation of the stack
        /// </summary>
        public void Print()
        {
            Node<T> curr = top;

            while (curr != null)
            {
                if (curr == top)
                    if (curr.Next == null)
                        Console.WriteLine($"[Top: {curr.Data}]\n[NULL]");
                    else
                        Console.WriteLine($"[Top: {curr.Data}]");
                else if (curr.Next == null)
                    Console.WriteLine($"[{curr.Data}]\n[NULL]");
                else
                    Console.WriteLine($"[{curr.Data}]");

                curr = curr.Next;
            }
        }
    }
}