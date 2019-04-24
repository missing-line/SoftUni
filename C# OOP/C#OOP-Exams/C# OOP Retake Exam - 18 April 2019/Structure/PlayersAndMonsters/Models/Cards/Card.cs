﻿namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;

    public abstract class Card : ICard
    {
        private string name;
        private int gamagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }
                this.name = value;
            }
        }
        
        public int DamagePoints
        {
            get => this.gamagePoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                this.gamagePoints = value;
            }
        }


        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                this.healthPoints = value;
            }
        }
    }
}
