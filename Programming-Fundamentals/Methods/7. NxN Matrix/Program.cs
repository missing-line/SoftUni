using System;

namespace _7._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Matrix(size);         
        }
       public static void Matrix(int size)
        {
            int[] matrix = new int[size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[j] = size;
                }
                Console.WriteLine(string.Join(" ", matrix));
            }
        }
    }
    
}
