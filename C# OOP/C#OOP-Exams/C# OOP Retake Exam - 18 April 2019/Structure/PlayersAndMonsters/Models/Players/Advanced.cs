namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    public class Advanced : Player
    {
        public Advanced(string username)
            : base(username, 250)
        {
        }
    }
}
