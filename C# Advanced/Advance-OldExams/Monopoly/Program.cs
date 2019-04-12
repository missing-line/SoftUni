namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];
            GetMatrix(matrix);

            List<string> resultOfCells = new List<string>();

            long money = 50;
            int count = 0;
            int turn = 0;
            bool isLeft = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (isLeft)
                {
                    isLeft = false;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "H" && money >= 0)
                        {
                            resultOfCells.Add($"Bought a hotel for {money}. Total hotels: {++count}.");
                            money = 0;

                        }
                        else if (matrix[i, j] == "J")
                        {
                            resultOfCells.Add($"Gone to jail at turn {turn}.");
                            money += count * 20;
                            turn += 2;
                        }
                        else if (matrix[i, j] == "S")
                        {

                            var neededMoney = (i + 1) * (j + 1);
                            if (money - neededMoney >= 0)
                            {
                                money -= neededMoney;
                                resultOfCells.Add($"Spent {neededMoney} money at the shop.");
                            }
                            else
                            {
                                resultOfCells.Add($"Spent {money} money at the shop.");
                                money = 0;
                            }
                        }
                        money += count * 10;
                        turn++;
                    }
                }
                else if (!isLeft)
                {
                    isLeft = true;
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (matrix[i, j] == "H" && money >= 0)
                        {
                            resultOfCells.Add($"Bought a hotel for {money}. Total hotels: {++count}.");
                            money = 0;

                        }
                        else if (matrix[i, j] == "J")
                        {
                            resultOfCells.Add($"Gone to jail at turn {turn}.");
                            money += count * 20;
                            turn += 2;
                        }
                        else if (matrix[i, j] == "S")
                        {

                            var neededMoney = (i + 1) * (j + 1);
                            if (money - neededMoney >= 0)
                            {
                                money -= neededMoney;
                                resultOfCells.Add($"Spent {neededMoney} money at the shop.");
                            }
                            else
                            {
                                resultOfCells.Add($"Spent {money} money at the shop.");
                                money = 0;
                            }
                        }
                        money += count * 10;
                        turn++;
                    }
                }
            }

            foreach (var line in resultOfCells)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"Turns {turn}");
            Console.WriteLine($"Money {money}");
        }

        private static void GetMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string curr = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = curr[j].ToString();
                }
            }
        }
    }
}
