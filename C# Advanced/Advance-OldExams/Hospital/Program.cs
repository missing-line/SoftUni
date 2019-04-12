namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string[,]> capacity = new Dictionary<string, string[,]>();
            Dictionary<string, Dictionary<string, List<string>>> departments = new Dictionary<string, Dictionary<string, List<string>>>();

            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] arr = input.Split().ToArray();
                string department = arr[0];
                string doctor = $"{arr[1]} {arr[2]}";
                string pacient = arr[3];

                if (!capacity.ContainsKey(department))
                {
                    capacity.Add(department, new string[20, 3]);
                }

                if (GetPacient(capacity, department, pacient)) ;
                {
                    if (!departments.ContainsKey(department))
                    {
                        departments.Add(department, new Dictionary<string, List<string>>());
                    }
                    if (!departments[department].ContainsKey(doctor))
                    {
                        departments[department].Add(doctor, new List<string>());
                    }
                    departments[department][doctor].Add(pacient);
                }
            }

            string[] info = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (string.Join("", info) != "End")
            {
                List<string> pacients = new List<string>();
                if (capacity.ContainsKey(info[0]))
                {
                    if (info.Length == 1)
                    {
                        foreach (var department in capacity)
                        {
                            if (department.Key == info[0])
                            {
                                string[,] matrix = department.Value;
                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (matrix[i, j] != null)
                                        {
                                            pacients.Add(matrix[i, j]);
                                        }
                                    }
                                }
                            }
                        }
                        Console.WriteLine(string.Join("\n", pacients));
                    }
                    else
                    {
                        int room = int.Parse(info[1]);

                        foreach (var department in capacity)
                        {
                            if (department.Key == info[0])
                            {
                                string[,] matrix = department.Value;
                                for (int i = room - 1; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        if (matrix[i, j] != null)
                                        {
                                            pacients.Add(matrix[i, j]);
                                        }
                                    }
                                    Console.WriteLine(string.Join("\n", pacients.OrderBy(x => x)));
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    string doctorName = $"{info[0]} {info[1]}";

                    foreach (var department in departments)
                    {
                        foreach (var doctor in department.Value)
                        {
                            if (doctor.Key == doctorName)
                            {
                                pacients.AddRange(doctor.Value);
                            }
                        }
                    }

                    Console.WriteLine(string.Join("\n", pacients.OrderBy(x => x)));
                }
                info = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }

        public static bool GetPacient(Dictionary<string, string[,]> capacity, string department, string pacient)
        {
            bool hospitalGetPacient = false;
            foreach (var room in capacity)
            {
                if (room.Key == department)
                {
                    hospitalGetPacient = GivePacientBad(room.Value, pacient);
                }
            }
            return hospitalGetPacient;
        }

        public static bool GivePacientBad(string[,] matrix, string pacient)
        {

            bool badIsSelected = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == null)
                    {
                        matrix[i, j] = pacient;
                        badIsSelected = true;
                        break;
                    }
                }
                if (badIsSelected)
                {
                    break;
                }
            }
            return badIsSelected;
        }
    }
}
