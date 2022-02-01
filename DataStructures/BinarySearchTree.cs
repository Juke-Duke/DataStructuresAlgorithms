using System;

namespace DataStructuresAlgorithms
{
    public class TNode
    {
        private int data;
        private TNode left, right;

        public TNode(int data, TNode left = null, TNode right = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public TNode Left
        {
            get { return left; }
            set { left = value; }
        }

        public TNode Right
        {
            get { return right; }
            set { right = value; }
        }
    }

    public class BinarySearchTree
    {
        TNode root;

        public BinarySearchTree(TNode root)
        {
            this.root = root;
        }

        public BinarySearchTree(int data)
        {
            root = new(data);
        }

        public TNode Root
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>
        /// Places TNode at appropriate spot in the tree
        /// </summary>
        /// <param name="data">Data value</param>
        public void Place(int data)
        {
            TNode curr = root;
            bool placed = false;

            while (!placed)
            {
                if (data >= curr.Data)
                {
                    if (curr.Right != null)
                        curr = curr.Right;
                    else
                    {
                        curr.Right = new(data);
                        placed = true;
                    }
                }
                else
                {
                    if (curr.Left != null)
                        curr = curr.Left;
                    else
                    {
                        curr.Left = new(data);
                        placed = true;
                    }
                }
            }
        }
    }
}