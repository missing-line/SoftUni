namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] arr = input.Split().ToArray();
                string trainerName = arr[0];
                string pokemonName = arr[1];
                string pokemonElement = arr[2];
                int health = int.Parse(arr[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, health);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = new Trainer
                        (
                            trainerName,
                            new List<Pokemon>()
                        );
                    trainers.Add(trainer);
                }

                Trainer currTraner = trainers.First(x => x.Name == trainerName);
                currTraner.Pokemons.Add(pokemon);

            }

            string elements;

            while ((elements = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.All(x => x.Element != elements))
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                    else
                    {
                        trainer.Badges++;
                    }
                    trainer.Pokemons.RemoveAll(x=>x.Health <= 0);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
            }
        }
    }
}
