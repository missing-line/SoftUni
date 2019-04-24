namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System.Linq;
    using System.Reflection;
    using System;
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var card =
                Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x=>x.Name == type + "Card");

            var instance = Activator.CreateInstance(card,new object[] { name });

            return (ICard)instance;
        }
    }
}
