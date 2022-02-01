using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public class Graph
    {
        private bool[,] matrix;
        private List<char> vertices;
        private int size = 0;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Graph(int size)
        {
            this.size = size;
            matrix = new bool[size, size];
            vertices = new List<char>();
        }

        public void AddVertex(char vertex)
        {
            if (vertices.Count < size)
                vertices.Add(vertex);
        }

        public void AddEdge(int vertex, int connection)
        {
            if (vertex >= vertices.Count || connection >= vertices.Count)
                return;
            if (vertex == connection)
            {
                Console.WriteLine("Cant connect a vertex to itself!");
                return;
            }
            matrix[vertex, connection] = true;
        }

        public bool CheckEdge(int vertex, int connection)
        {
            return matrix[vertex, connection];
        }

        public void Print()
        {
            Console.Write("  ");
            foreach (char vertex in vertices)
                Console.Write($"{vertex} ");
            Console.WriteLine();
            for (int i = 0; i < vertices.Count; ++i)
            {
                Console.Write($"{vertices[i]} ");
                for (int j = 0; j < vertices.Count; ++j)
                    Console.Write($"{Convert.ToInt32(matrix[i, j])} ");
                Console.WriteLine();
            }

        }
    }
}
