namespace Helen_s_Abduction
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int energy;
        private static string ParisIsDead = "Paris died at";
        private static string ParisEscapeWithHelena = "Paris has successfully abducted Helen!";
        public static void Main(string[] args)
        {
            energy = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            string[][] field = new string[n][];

            int[] parisCoordinates = new int[2];

            GetMatrix(field, parisCoordinates);

            string msg = SearchingHelena(field, parisCoordinates);

            if (msg == ParisIsDead)
            {
                Console.WriteLine($"{msg} {parisCoordinates[0]};{parisCoordinates[1]}.");
                Print(field);
            }
            else
            {
                Console.WriteLine($"{msg} Energy left: {energy}");
                Print(field);
            }
        }

        private static void Print(string[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(string.Join("", field[i]));
            }
        }

        private static string SearchingHelena(string[][] field, int[] parisCoordinates)
        {
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                string parisMovePosition = command[0];

                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                if (IsValid(field, enemyRow, enemyCol))
                {
                    field[enemyRow][enemyCol] = "S";
                }

                energy--;

                if (parisMovePosition == "up")
                {
                    if (IsValid(field, parisCoordinates[0] - 1, parisCoordinates[1]))
                    {
                        field[parisCoordinates[0]][parisCoordinates[1]] = "-";
                        parisCoordinates[0]--;
                        
                        if (field[parisCoordinates[0]][parisCoordinates[1]] == "-")
                        {
                            if (energy <= 0)
                            {                              
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "P";
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "S")
                        {
                            energy -= 2;
                            if (energy <= 0)
                            {                               
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "H")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            
                            field[parisCoordinates[0]][parisCoordinates[1]] = "-";

                            return ParisEscapeWithHelena;
                        }                      
                    }
                    else
                    {
                        if (energy <= 0)
                        {
                            field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                            return ParisIsDead; 
                        }
                    }
                }
                else if (parisMovePosition == "down")
                {
                    if (IsValid(field, parisCoordinates[0] + 1, parisCoordinates[1]))
                    {
                        field[parisCoordinates[0]][parisCoordinates[1]] = "-";
                        parisCoordinates[0]++;

                        if (field[parisCoordinates[0]][parisCoordinates[1]] == "-")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "P";
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "S")
                        {
                            energy -= 2;
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "H")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "-";

                            return ParisEscapeWithHelena;
                        }
                    }
                    else
                    {
                        if (energy <= 0)
                        {
                            field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                            return ParisIsDead;
                        }
                    }
                }
                else if (parisMovePosition == "left")
                {
                    if (IsValid(field, parisCoordinates[0], parisCoordinates[1] - 1))
                    {
                        field[parisCoordinates[0]][parisCoordinates[1]] = "-";
                        parisCoordinates[1]--;

                        if (field[parisCoordinates[0]][parisCoordinates[1]] == "-")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "P";
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "S")
                        {
                            energy -= 2;
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "H")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "-";

                            return ParisEscapeWithHelena;
                        }
                    }
                    else
                    {
                        if (energy <= 0)
                        {
                            field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                            return ParisIsDead;
                        }
                    }
                }
                else if (parisMovePosition == "right")
                {
                    if (IsValid(field, parisCoordinates[0], parisCoordinates[1] + 1))
                    {
                        field[parisCoordinates[0]][parisCoordinates[1]] = "-";
                        parisCoordinates[1]++;

                        if (field[parisCoordinates[0]][parisCoordinates[1]] == "-")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            field[parisCoordinates[0]][parisCoordinates[1]] = "P";
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "S")
                        {
                            energy -= 2;
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                        }
                        else if (field[parisCoordinates[0]][parisCoordinates[1]] == "H")
                        {
                            if (energy <= 0)
                            {
                                field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                                return ParisIsDead;
                            }
                            
                            field[parisCoordinates[0]][parisCoordinates[1]] = "-";

                            return ParisEscapeWithHelena;
                        }
                    }
                    else
                    {
                        if (energy <= 0)
                        {
                            field[parisCoordinates[0]][parisCoordinates[1]] = "X";

                            return ParisIsDead;
                        }
                    }
                }
            }
        }

        private static bool IsValid(string[][] field, int enemyRow, int enemyCol)
        {
            return enemyRow >= 0 && enemyRow < field.Length &&
                enemyCol >= 0 && enemyCol < field[enemyRow].Length;
        }

        private static void GetMatrix(string[][] field, int[] parisCoordinates)
        {
            for (int i = 0; i < field.Length; i++)
            {
                string line = Console.ReadLine();
                field[i] = new string[line.Length];

                for (int j = 0; j < field[i].Length; j++)
                {
                    field[i][j] = line[j].ToString();

                    if (line[j].ToString() == "P")
                    {
                        parisCoordinates[0] = i;
                        parisCoordinates[1] = j;
                    }
                }
            }
        }
    }
}
