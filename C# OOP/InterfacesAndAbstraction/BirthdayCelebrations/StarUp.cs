namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static void Main()
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input
                    .Split()
                    .ToArray();
                if (arr[0] == "Citizen")
                {
                    birthdates.Add
                        (
                        new Citizen(arr[1],
                        int.Parse(arr[2]),
                        arr[3],
                        arr[4]
                        ));
                }
                else if (arr[0] == "Pet")
                {
                    birthdates.Add
                        (
                        new Pet(arr[1],
                        arr[2]
                        ));
                }

            }

            string findDate = Console.ReadLine();

            foreach (var birth in birthdates)
            {
                if (GetEquals(birth, findDate))
                {
                    Console.WriteLine(birth.Birthdate);
                }
            }
        }

        private static bool GetEquals(IBirthdate birth, string findDate)
        {
            string[] arr = birth.Birthdate
                .Split('/')
                .ToArray();

            if (arr[2] == findDate)
            {
                return true;
            }

            return false;
        }
    }
}
