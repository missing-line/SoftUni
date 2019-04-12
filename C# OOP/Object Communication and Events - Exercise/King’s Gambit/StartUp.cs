namespace King_s_Gambit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();


            King king = new King(Console.ReadLine());

            string[] royals = Console.ReadLine()
                .Split()
                .ToArray();

            string[] panicked = Console.ReadLine()
               .Split()
               .ToArray();

            foreach (var name in royals)
            {
                var soldier = new RoyalGuard(name);
                soldiers.Add(soldier);
                king.kingAttacked += soldier.KingUnderAttack;
            }

            foreach (var name in panicked)
            {
                var soldier = new Footman(name);
                soldiers.Add(soldier);
                king.kingAttacked += soldier.KingUnderAttack;
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();

                string command = tokens[0];

                switch (command)
                {
                    case "Attack":
                        king.OnAttack();
                        break;
                    case "Kill":
                        var currentSoldier = soldiers.FirstOrDefault(x => x.Name == tokens[1]);
                        if (currentSoldier != null)
                        {
                            currentSoldier.GetHit();
                            if (currentSoldier.IsDead)
                            {
                                king.kingAttacked -= currentSoldier.KingUnderAttack;
                                soldiers.Remove(currentSoldier);
                            }
                        }
                        
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
