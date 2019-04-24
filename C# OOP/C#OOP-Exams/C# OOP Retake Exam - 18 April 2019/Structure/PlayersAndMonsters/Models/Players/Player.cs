namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;
        protected Player(string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.cardRepository = new CardRepository();

        }

        public ICardRepository CardRepository
            => this.cardRepository;

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }
                this.health = value;
            }
        }

        public bool IsDead => this.Health == 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (this.Health - damagePoints >= 0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;               
            }                         
        }
    }
}
