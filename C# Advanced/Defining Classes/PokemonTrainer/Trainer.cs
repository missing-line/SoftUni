namespace PokemonTrainer
{
    using System.Collections.Generic;
    public class Trainer
    {
        private string name;
        private List<Pokemon> pokemons;
        private int badges;
        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Pokemons = pokemons;
            this.Badges = 0;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Badges { get { return this.badges; } set { this.badges = value; } }
        public List<Pokemon> Pokemons { get { return this.pokemons; } set { this.pokemons = value; } }
    }
}
