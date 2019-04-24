namespace PlayersAndMonsters.Core.Factories
{

    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type player =
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var instance = Activator.CreateInstance(player, new object[] { username });

            return (IPlayer)instance;
        }
    }
}
