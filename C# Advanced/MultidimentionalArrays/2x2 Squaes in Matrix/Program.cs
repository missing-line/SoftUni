namespace _2x2_Squares_in_Matrix
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            int count = 0;

            FillMatrix(matrix);
            
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                string[,] currMatrix = new string[2, 2];
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    currMatrix[0, 0] = matrix[i, j];
                    currMatrix[0, 1] = matrix[i, j + 1];
                    currMatrix[1, 0] = matrix[i + 1, j];
                    currMatrix[1, 1] = matrix[i + 1, j + 1];
                    bool findMatrix = Equals(currMatrix);
                    if (findMatrix)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
        public static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] array = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }
            }
        }
        public static bool Equals(string[,] matrix)
        {
            bool isEquals = false;
            if (matrix[0, 0] == matrix[0, 1] &&
                matrix[1, 0] == matrix[1, 1] &&
                matrix[0, 0] == matrix[1, 0] &&
                matrix[0, 1] == matrix[1, 1])
            {
                isEquals = true;
            }
            return isEquals;
        }
    }
}
