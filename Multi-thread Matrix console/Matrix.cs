using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_thread_Matrix_console
{
    internal class Matrix
    {
        private readonly int[,] matrixA;
        private readonly int[,] matrixB;
        private readonly int[,] resultMatrix;

        public Matrix(int size)
        {
            matrixA = randomMatrix(size);
            matrixB = randomMatrix(size);
            resultMatrix = new int[size, size];
        }

        private int[,] randomMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(1, 25); 
                }
            }
            return matrix;
        }
        private void Multiply(int[,] a, int[,] b, int[,] result, int startRow = 0, int endRow = -1)
        {
            int size = a.GetLength(0);
            for (int i = startRow; i < endRow; i++)
            {
                if (endRow == -1) endRow = size;

                {
                    for (int j = 0; j < size; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < size; k++)
                        {
                            sum += a[i, k] * b[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
            }
        }
        public void displayAllMatrixes()
        {
            Console.WriteLine("Matrix A:");
            displayMatrix(matrixA);
            Console.WriteLine("Matrix B:");
            displayMatrix(matrixB);
            Console.WriteLine("Result Matrix:");
            displayMatrix(resultMatrix);
        }
        private void displayMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void threadMultiply(int n)
        {
            Thread[] threads = new Thread[n];
            int blockSize = resultMatrix.GetLength(0) / n;

            for (int i = 0; i < n; i++)
            {
                int start = i * blockSize;
                int end = (i == n - 1) ? resultMatrix.GetLength(0) : (i + 1) * blockSize;

                threads[i] = new Thread(() =>
                {
                    Multiply(matrixA, matrixB, resultMatrix, start, end);
                });;
            }
            foreach (Thread th in threads)
            {
                th.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        public void parallerMultiply (int n)
        {
            Parallel.For(0, n, i =>
            {
                int start = (resultMatrix.GetLength(0) / n) * i;
                int end = (i == n - 1) ? resultMatrix.GetLength(0) : (resultMatrix.GetLength(0) / n) * (i + 1);

                Multiply(matrixA, matrixB, resultMatrix, start, end);
            });
        }
    }
}
