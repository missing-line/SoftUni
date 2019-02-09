namespace Ladybugs
{
    using System;
    using System.Linq;
    public class Ladybugs
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] bugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[size];

            for (int i = 0; i < bugs.Length; i++)
            {
                if (bugs[i] >= 0 && bugs[i] < field.Length)
                {
                    field[bugs[i]] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] line = command.Split().ToArray();
                int index = int.Parse(line[0]);
                int flyLenght = int.Parse(line[2]);
                int flyStep = 0;
                if (line.Contains("right"))
                {
                    if (index >= 0 && index < field.Length)
                    {
                        if (field[index] == 1)
                        {
                            field[index] = 0;
                            for (int i = index + flyLenght; i < field.Length; i += flyStep)
                            {
                                if (field[i] == 0)
                                {
                                    field[i] = 1;
                                    break;
                                }
                                flyStep = flyLenght;
                            }
                        }

                    }
                }
                else
                {
                    if (index >= 0 && index < field.Length)
                    {
                        if (field[index] == 1)
                        {
                            field[index] = 0;
                            for (int i = index - (flyLenght); i >= 0; i -= (flyStep))
                            {
                                if (field[i] == 0)
                                {
                                    field[i] = 1;
                                    break;
                                }
                                flyStep = flyLenght;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}