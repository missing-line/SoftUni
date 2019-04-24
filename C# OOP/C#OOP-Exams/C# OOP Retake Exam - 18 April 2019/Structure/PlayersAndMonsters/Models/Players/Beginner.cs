namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    public class Beginner : Player
    {
        public Beginner(string username)
            : base(username, 50)
        {
        }
    }
}
