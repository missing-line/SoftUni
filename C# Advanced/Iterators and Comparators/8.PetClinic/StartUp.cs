namespace _8.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Pet> pets = new List<Pet>();
            List<Clinic> clinics = new List<Clinic>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = input[0];
                if (command == "Create")
                {
                    if (input[1] == "Pet")
                    {
                        if (input.Length != 5)
                        {
                            continue;
                        }
                        string namePet = input[2];
                        int agePet = int.Parse(input[3]);
                        string type = input[4];
                        Pet currentPet = new Pet(namePet, agePet, type);
                        pets.Add(currentPet);
                    }
                    else if (input[1] == "Clinic")
                    {
                        string name = input[2];
                        int rooms = int.Parse(input[3]);
                        if (rooms % 2 == 0)
                        {
                            Console.WriteLine("Invalid Operation!");
                        }
                        else
                        {
                            Clinic curretntClinic = new Clinic(name, rooms);
                            clinics.Add(curretntClinic);
                        }
                    }
                }
                else if (command == "Add")
                {
                    string namePet = input[1];
                    string nameClinic = input[2];

                    if (pets.Any(x => x.Name == namePet) &&
                        clinics.Any(x => x.Name == nameClinic))
                    {
                        if (clinics.First(x => x.Name == nameClinic)
                            .AddPet(pets.First(x => x.Name == namePet)))
                        {
                            pets.Remove(pets.First(x => x.Name == namePet));
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "HasEmptyRooms")
                {
                    string nameClinic = input[1];
                    if (!clinics.Any(x => x.Name == nameClinic))
                    {
                        Console.WriteLine("False");
                        continue;
                    }

                    Clinic extClinic = clinics.First(x => x.Name == nameClinic);
                    if (extClinic.HasEmptyRooms(extClinic.Rooms))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Print")
                {
                    string nameOfClinic = input[1];
                    if (!clinics.Any(x => x.Name == nameOfClinic))
                    {
                        continue;
                    }
                    if (input.Length == 3)
                    {
                        int index = int.Parse(input[2]);
                        clinics.First(x => x.Name == nameOfClinic)
                                                .PrintCurrentRoom(index - 1);
                    }
                    else
                    {
                        if (clinics.Any(x => x.Name == input[1]))
                        {
                            var arrOfPets = clinics.First(x => x.Name == input[1]).Rooms;

                            for (int j = 0; j <= arrOfPets.Length + 1; j++)
                            {
                                clinics.First(x => x.Name == input[1]).PrintCurrentRoom(j - 1);
                            }
                        }
                    }
                }
                else if (command == "Release")
                {
                    string nameClinic = input[1];
                    if (!clinics.Any(x => x.Name == nameClinic))
                    {
                        Console.WriteLine("False");
                        continue;
                    }
                    Clinic extClinic = clinics.First(x => x.Name == nameClinic);
                    if (extClinic.Release())
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }

                }
            }
        }
    }
}
