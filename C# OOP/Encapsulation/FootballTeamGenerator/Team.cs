namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        public List<Player> Players
        {
            get { return this.players; }
            private set { this.players = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty");
                }
                this.name = value;
            }
        }


        internal void Remove(string name)
        {
            if (!players.Any(x => x.Name == name))
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }
            this.players.RemoveAll(x => x.Name == name);

        }

        internal void Adding(Player player)
        {
            this.players.Add(player);
        }

        internal int Rating
        {
            get
            {
                return this.players.Count == 0 ? 0 : Convert.ToInt32((this.players.Average(p => p.SkillLevel())));
            }
        }
    }
}
