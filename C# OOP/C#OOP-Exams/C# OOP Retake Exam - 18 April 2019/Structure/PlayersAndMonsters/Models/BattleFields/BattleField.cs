namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            int attackerBonusHealth = attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            attackPlayer.Health += attackerBonusHealth;

            int enemyBonusHealth = enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyBonusHealth;

            while (true)
            {

                int attacker = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

                enemyPlayer.TakeDamage(attacker);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemy = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

                attackPlayer.TakeDamage(enemy);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
