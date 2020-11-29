using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Matrix
    {
        public int length;
        public int width;
        public int[,] matrix;
        public Matrix(int a, int b)
        {
            matrix = new int[a, b];
            length = a;
            width = b;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public void AddRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = rnd.Next(0, 2);
                }
            }
        }
        public void Output()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int NumberOfUnits(int a)
        {
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] == a)
                    {
                        num++;
                    }
                }
            }
            return num;
        }
        public int SumMartix()
        {
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    num += matrix[i, j];
                }
            }
            return num;
        }
    }
}
