namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Models;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Characters.Factory;
    using DungeonsAndCodeWizards.Models.Items.ItemFactory;
    using DungeonsAndCodeWizards.Models.SpecialClass;
    using DungeonsAndCodeWizards.Models.SpecialClass.Factory;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> pool;
        private CharacterFactory charasterFactory;
        private ItemFactory itemFactory;
        private IAttackFactory attackFactory;
        private IHealFactory healFactory;
        private int lastCharacter;
        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.charasterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.pool = new List<Item>();
            this.attackFactory = new AttackFactory();
            this.healFactory = new HealFactory();
            this.lastCharacter = 0;
        }

        public string JoinParty(string[] data)
        {
            string faction = data[0];
            string type = data[1];
            string name = data[2];
            Character character = this.charasterFactory.CreateCharacter(faction, type, name);

            this.characters.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] data)
        {
            string type = data[0];

            Item item = this.itemFactory.CreateItem(type);

            this.pool.Add(item);

            return $"{item.GetType().Name} added to pool.";
        }

        public string PickUpItem(string[] data)
        {
            string name = data[0];

            return this.charasterFactory.PickUpItem(name, this.pool, this.characters);
        }

        public string UseItem(string[] data)
        {

            string name = data[0];
            string itemName = data[1];

            Character ch = this.charasterFactory.InstansedCharacter(this.characters, name);

            Item item = ch.Bag.GetItem(itemName);

            ch.UseItem(item);

            return $"{ch.Name} used {itemName}.";
        }

        public string UseItemOn(string[] data)
        {
            string giverName = data[0];
            string receiverName = data[1];
            string itemName = data[2];

            Character chGiver = this.charasterFactory.InstansedCharacter(this.characters, giverName);

            Character chReceiver = this.charasterFactory.InstansedCharacter(this.characters, receiverName);

            Item item = chGiver.Bag.GetItem(itemName);

            chReceiver.UseItem(item);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] data)
        {
            string giverName = data[0];
            string receiverName = data[1];
            string itemName = data[2];

            Character chGiver = this.charasterFactory.InstansedCharacter(this.characters, giverName);

            Character chReceiver = this.charasterFactory.InstansedCharacter(this.characters, receiverName);

            Item item = chGiver.Bag.GetItem(itemName);

            chReceiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var ch in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(ch.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] data)
        {
            string attackerName = data[0];
            string receiverName = data[1];

            Character chAttcker = this.charasterFactory.InstansedCharacter(this.characters, attackerName);

            Character chReceiver = this.charasterFactory.InstansedCharacter(this.characters, receiverName);

            return this.attackFactory.AttackCommand(chAttcker, chReceiver, this.characters);
        }

        public string Heal(string[] data)
        {
            string healName = data[0];
            string receiverName = data[1];

            Cleric heal = (Cleric)this.charasterFactory.InstansedCharacter(this.characters, healName);

            Character receiver = this.charasterFactory.InstansedCharacter(this.characters, receiverName);

            return this.healFactory.HealCommand(heal, receiver, this.characters);

        }

        public string EndTurn()
        {
            StringBuilder sb = new StringBuilder();
            //{character.Name} rests ({healthBeforeRest} => {currentHealth})
            int count = 0;
            foreach (var character in this.characters.Where(x => x.IsAlive))
            {
                var healthBeforeRest = character.Health;

                character.Rest();

                var currentHealth = character.Health;

                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {currentHealth})");
                count++;
            }
            if (count <= 1)
            {
                this.lastCharacter++;
            }
            else
            {
                this.lastCharacter = 0;
            }
            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver() => this.lastCharacter > 1;      

    }
}
