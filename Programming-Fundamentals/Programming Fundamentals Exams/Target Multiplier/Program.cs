using System;
using System.Linq;

namespace Target_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demention = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            int r = demention[0];
            int c = demention[1];

            int[,] matrix = new int[r, c];
            int sum = 0;

            for (int i = 0; i < r; i++)
            {
                int[] line = Console.ReadLine()
                    .Split().Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int[] startDemention = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            int startR = startDemention[0];
            int startC = startDemention[1];

            while (true)
            {
                if (startR - 1 >= 0 && startR - 1 < r &&
                    startC - 1 >= 0 && startC - 1 < c)
                {
                   
                    sum += matrix[startR - 1, startC - 1];
                    matrix[startR - 1, startC - 1] *= matrix[startR, startC];
                }
                if (startR - 1 >= 0 && startR - 1 < r &&
                    startC + 1 >= 0 && startC + 1 < c)
                {
                   
                    sum += matrix[startR - 1, startC + 1];
                    matrix[startR - 1, startC + 1] *= matrix[startR, startC];
                }
                if (startR - 1 >= 0 && startR - 1 < r &&
                    startC >= 0 && startC < c)
                {
                    sum += matrix[startR - 1, startC];
                    matrix[startR - 1, startC] *= matrix[startR, startC];

                }
                if (startR >= 0 && startR < r &&
                    startC - 1 >= 0 && startC - 1 < c)
                {
                    sum += matrix[startR, startC - 1];
                    matrix[startR, startC - 1] *= matrix[startR, startC];

                }
                if (startR >= 0 && startR < r &&
                    startC +1 >= 0 && startC + 1 < c)
                {
                    
                    sum += matrix[startR, startC + 1];
                    matrix[startR, startC + 1] *= matrix[startR, startC];

                }
                if (startR + 1 >= 0 && startR + 1 < r &&
                   startC - 1 >= 0 && startC - 1 < c)
                {
                    sum += matrix[startR + 1, startC - 1];
                    matrix[startR + 1, startC - 1] *= matrix[startR, startC];

                }
                if (startR + 1 >= 0 && startR + 1 < r &&
                   startC >= 0 && startC < c)
                {
                    sum += matrix[startR + 1, startC];
                    matrix[startR + 1, startC] *= matrix[startR, startC];

                }
                if (startR + 1 >= 0 && startR + 1 < r &&
                   startC + 1>= 0 && startC + 1< c)
                {
                    sum += matrix[startR + 1, startC + 1];
                    matrix[startR + 1, startC + 1] *= matrix[startR, startC];
                }
                break;
            }           
            matrix[startR, startC] *= sum;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
