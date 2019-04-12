namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        
        public void Run()
        {
            string input;

            while (!string.IsNullOrEmpty(input = Console.ReadLine()) && !this.dungeonMaster.IsGameOver())
            {
                string[] tokens = input
                    .Split()
                    .ToArray();

                string command = tokens[0];

                string[] data = tokens
                    .Skip(1)
                    .ToArray();
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(this.dungeonMaster.JoinParty(data));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(this.dungeonMaster.AddItemToPool(data));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(this.dungeonMaster.PickUpItem(data));
                            break;
                        case "UseItem":
                            Console.WriteLine(this.dungeonMaster.UseItem(data));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(this.dungeonMaster.UseItemOn(data));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(this.dungeonMaster.GiveCharacterItem(data));
                            break;
                        case "Attack":
                            Console.WriteLine(this.dungeonMaster.Attack(data));
                            break;
                        case "Heal":
                            Console.WriteLine(this.dungeonMaster.Heal(data));
                            break;
                        case "GetStats":
                            Console.WriteLine(this.dungeonMaster.GetStats());
                            break;
                            case "EndTurn":
                            Console.WriteLine(this.dungeonMaster.EndTurn());
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }             
            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
