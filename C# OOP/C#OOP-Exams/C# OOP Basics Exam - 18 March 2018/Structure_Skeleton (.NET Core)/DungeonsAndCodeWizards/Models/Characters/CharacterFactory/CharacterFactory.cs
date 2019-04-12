namespace DungeonsAndCodeWizards.Models.Characters.Factory
{
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.SpecialClass;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterFactory : ICharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
           
            switch (characterType)
            {
                case "Cleric":
                    Cleric cleric = new Cleric(name, factionResult);
                    return cleric;
                case "Warrior":
                    Warrior warrior = new Warrior(name, factionResult);
                    return warrior;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

        }

        public Character InstansedCharacter(List<Character> characters, string name)
        {
            Character ch = characters.FirstOrDefault(x => x.Name == name);

            if (ch == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return ch;
        }

        public string PickUpItem(string characterName, List<Item> pool, List<Character> characters)
        {
            if (characters.All(x => x.Name != characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Character character = characters.FirstOrDefault(x => x.Name == characterName);

            Item item = pool[pool.Count - 1];

            character.ReceiveItem(item);

            pool.RemoveAt(pool.Count - 1);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }
    }
}
