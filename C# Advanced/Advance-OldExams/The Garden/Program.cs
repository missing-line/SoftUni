namespace The_Garden
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int carrots = 0;     
        private static int lettuce = 0;     
        private static int potatoes = 0;    
        private static int mole = 0;    
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] harvest = new string[n][];

            FillMatrix(harvest);

            string commands;

            while ((commands = Console.ReadLine()) != "End of Harvest")
            {
                var arr = commands.Split(" ").ToArray();
                string innerCommand = arr[0];
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);

                if (innerCommand == "Harvest" && ValidateCoordinates(harvest, row, col))
                {
                    GetVegetable(harvest, row, col);
                }
                else if (innerCommand == "Mole" && ValidateCoordinates(harvest, row, col))
                {
                    MoleCollectiong(harvest, row, col, arr[3]);
                }
            }

            Print(harvest);
        }

        private static void Print(string[][] harvest)
        {
            for (int i = 0; i < harvest.Length; i++)
            {
                Console.WriteLine(string.Join(" ", harvest[i]).Trim());
            }
            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuce}");
            Console.WriteLine($"Harmed vegetables: {mole}");
        }

        private static void MoleCollectiong(string[][] harvest, int row, int col, string dir)
        {
            if (dir == "right")
            {
                for (int i = col; i < harvest[row].Length; i += 2)
                {
                    if (harvest[row][i] == "C" || harvest[row][i] == "P" || harvest[row][i] == "L")
                    {
                        Eat(harvest, row, i);
                    }
                }
            }
            else if (dir == "up")
            {

                for (int i = row; i >= 0; i -= 2)
                {
                    if (ValidateCoordinates(harvest, i, col) &&
                        (harvest[i][col] == "C" || harvest[i][col] == "P" || harvest[i][col] == "L"))
                    {
                        Eat(harvest, i, col);
                    }
                }
            }
            else if (dir == "left")
            {
                for (int i = col; i >= 0; i-=2)
                {
                    if (harvest[row][i] == "C" || harvest[row][i] == "P" || harvest[row][i] == "L")
                    {
                        Eat(harvest, row, i);
                    }
                }
            }
            else if (dir == "down")
            {
                for (int i = row; i < harvest.Length; i+=2)
                {
                    if (ValidateCoordinates(harvest, i, col) &&
                        (harvest[i][col] == "C" || harvest[i][col] == "P" || harvest[i][col] == "L"))
                    {
                        Eat(harvest, i, col);
                    }
                }
            }
        }

        private static void Eat(string[][] harvest, int row, int col)
        {
            mole++;
            harvest[row][col] = " ";
        }

        private static void GetVegetable(string[][] harvest, int row, int col)
        {
            string vegetable = harvest[row][col];
            switch (vegetable)
            {
                case "C":
                    carrots++;
                    break;
                case "L":
                    lettuce++;
                    break;
                case "P":
                    potatoes++;
                    break;
                default:
                    break;
            }
            harvest[row][col] = " ";
        }

        private static bool ValidateCoordinates(string[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix(string[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ").ToArray();
            }
        }
    }
}
