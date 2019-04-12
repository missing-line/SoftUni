namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input
                    .Split()
                    .ToArray();
                string typeSordier = arr[0];

                if (typeSordier == "Engineer")
                {
                    if (!(arr[5] == "Airforces" || arr[5] == "Marines"))
                    {
                        continue;
                    }
                    GetRerapirs(soldiers, arr);
                }
                else if (typeSordier == "Private")
                {
                    Private @private = new Private(arr[1], arr[2], arr[3], decimal.Parse(arr[4]));
                    soldiers.Add(@private);
                }
                else if (typeSordier == "Spy")
                {
                    Spy spy = new Spy(arr[1], arr[2], arr[3], int.Parse(arr[4]));
                    soldiers.Add(spy);
                }
                else if (typeSordier == "Commando")
                {

                    if (!(arr[5] == "Airforces" || arr[5] == "Marines"))
                    {
                        continue;
                    }
                    GetCommando(soldiers, arr);
                }
                else if (typeSordier == "LieutenantGeneral")
                {
                    GetLieutenantGeneral(soldiers, arr);
                }
            }
            soldiers.ForEach(x => Console.WriteLine(x));
        }

        private static void GetLieutenantGeneral(List<Soldier> soldiers, string[] arr)
        {
            var lieutenatnt = new LieutenantGeneral(arr[1], arr[2], arr[3], decimal.Parse(arr[4]));

            for (int i = 5; i < arr.Length; i++)
            {
                Private privat = (Private)soldiers.Single(s => s.Id == arr[i]);
                lieutenatnt.AddPrivate(privat);
            }
            soldiers.Add(lieutenatnt);
        }

        private static void GetCommando(List<Soldier> soldiers, string[] arr)
        {
            var newCommando = new Commando(arr[1], arr[2], arr[3], decimal.Parse(arr[4]), arr[5]);

            for (int i = 6; i < arr.Length - 1; i += 2)
            {
                if (arr[i + 1] == "Finished" || arr[i + 1] == "inProgress")
                {
                    newCommando.AddMission(new Mission(arr[i], arr[i + 1]));
                }
            }

            soldiers.Add(newCommando);
        }

        private static void GetRerapirs(List<Soldier> soldiers, string[] arr)
        {
            var newEnginner = new Engineer(arr[1], arr[2], arr[3], decimal.Parse(arr[4]), arr[5]);

            for (int i = 6; i < arr.Length - 1; i += 2)
            {
                
                    newEnginner.AddReprair(new Repair(arr[i], double.Parse(arr[i + 1])));
                
            }
            soldiers.Add(newEnginner);
        }
    }
}
