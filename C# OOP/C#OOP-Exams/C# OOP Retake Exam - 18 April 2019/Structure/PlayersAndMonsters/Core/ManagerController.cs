namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    using System;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;
        private IBattleField battleField;
        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);

            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,player.Username,player.Health, player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,card.Name,card.DamagePoints));
                }
                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
