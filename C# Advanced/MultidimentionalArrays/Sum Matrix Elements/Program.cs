namespace Sum_Matrix_Elements
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0],size[1]];

            int sumMatrixValues = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] array = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                    sumMatrixValues += array[j];
                }
            }
            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            Console.WriteLine(sumMatrixValues);
        }
    }
}
