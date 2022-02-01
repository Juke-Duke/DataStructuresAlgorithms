using System;

namespace DataStructuresAlgorithms
{
    public class Matrix
    {

        public static int[,] MatrixAddition2X2(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.Length != matrix2.Length)
                return null;

            int[,] newMatrix = new int[2, 2];

            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++ j)
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

            return newMatrix;
        }
    }   
}