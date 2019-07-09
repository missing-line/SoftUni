namespace Space_Station_Establishment
{
    using System;
    public class Program
    {       
        private static int startsForShip = 0;
        private static int[] start = new int[2];
        private static string[,] space;
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            space = new string[size, size];

            FillSpace(space);

            while (true)
            {
                string command = Console.ReadLine();

                ExecuteCommand(command);
            }
        }

        private static void ExecuteCommand(string command)
        {
            space[start[0], start[1]] = "-";
            if (command == "right")
            {
                start[1]++;
                if (!VadidateCoordinates())
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Print();
                }
                else if (space[start[0], start[1]] == "O")
                {
                    space[start[0], start[1]] = "-";
                    FindHoll();
                    space[start[0], start[1]] = "S";

                }
                else if (space[start[0], start[1]] == "-")
                {
                    space[start[0], start[1]] = "S";
                }
                else
                {
                    startsForShip += int.Parse(space[start[0], start[1]]);
                    space[start[0], start[1]] = "S";
                }
            }
            else if (command == "left")
            {
                start[1]--;
                if (!VadidateCoordinates())
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Print();
                }
                else if (space[start[0], start[1]] == "O")
                {
                    space[start[0], start[1]] = "-";
                    FindHoll();
                    space[start[0], start[1]] = "S";

                }
                else if (space[start[0], start[1]] == "-")
                {
                    space[start[0], start[1]] = "S";
                }
                else
                {
                    startsForShip += int.Parse(space[start[0], start[1]]);
                    space[start[0], start[1]] = "S";
                }
            }
            else if (command == "up")
            {
                start[0]--;
                if (!VadidateCoordinates())
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Print();
                }
                else if (space[start[0], start[1]] == "O")
                {
                    space[start[0], start[1]] = "-";
                    FindHoll();
                    space[start[0], start[1]] = "S";

                }
                else if (space[start[0], start[1]] == "-")
                {
                    space[start[0], start[1]] = "S";
                }
                else
                {
                    startsForShip += int.Parse(space[start[0], start[1]]);
                    space[start[0], start[1]] = "S";
                }
            }
            else if (command == "down")
            {
                start[0]++;
                if (!VadidateCoordinates())
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Print();
                }
                else if (space[start[0], start[1]] == "O")
                {
                    space[start[0], start[1]] = "-";
                    FindHoll();
                    space[start[0], start[1]] = "S";

                }
                else if (space[start[0], start[1]] == "-")
                {
                    space[start[0], start[1]] = "S";
                }
                else
                {
                    startsForShip += int.Parse(space[start[0], start[1]]);
                    space[start[0], start[1]] = "S";
                }
            }

            if (startsForShip >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Print();
            }
        }

        private static void FindHoll()
        {
            bool isFind = false;
            for (int i = 0; i < space.GetLength(0); i++)
            {
               
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    if (space[i, j] == "O")
                    {
                        start[0] = i;
                        start[1] = j;
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine($"Star power collected: {startsForShip}");

            for (int i = 0; i < space.GetLength(0); i++)
            {
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    Console.Write(space[i, j]);
                }
                Console.WriteLine();
            }
            Environment.Exit(1);
        }

        private static bool VadidateCoordinates()
        {
            int row = start[0];
            int col = start[1];
            return row >= 0 && row < space.GetLength(0) && col >= 0 && col < space.GetLength(1);
        }

        private static void FillSpace(string[,] space)
        {
            for (int i = 0; i < space.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    space[i, j] = line[j].ToString();

                    if (space[i, j] == "S")
                    {
                        start[0] = i;
                        start[1] = j;
                    }
                }
            }
        }
    }

}
