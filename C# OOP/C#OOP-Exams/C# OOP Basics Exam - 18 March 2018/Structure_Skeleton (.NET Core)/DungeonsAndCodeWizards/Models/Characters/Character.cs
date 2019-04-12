namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;
    public abstract class Character : ICharacter
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return this.health; }
            internal set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if(value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                this.health = value;

                if (this.health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }


        public double BaseArmor { get; }

        public double Armor
        {
            get { return this.armor; }
            internal set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if(value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                this.armor = value;
            }
        }
        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; internal set; }

        public virtual double RestHealMultiplier => 0.2;

        public Faction Faction { get; internal set; }


        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive)
            {
                this.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                this.Health += (this.RestHealMultiplier * this.BaseHealth);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                double hitPointsAfterHit  = hitPoints - Armor;
                this.Armor -= hitPoints;

                if (hitPointsAfterHit > 0)
                {
                    this.Health -= hitPointsAfterHit;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string isAlifeCharacter = "";
            if (this.IsAlive)
            {
                isAlifeCharacter = "Alive";
            }
            else
            {
                isAlifeCharacter = "Dead";
            }
            //{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}," +
                $" Status: {isAlifeCharacter}";

        }
    }
}
