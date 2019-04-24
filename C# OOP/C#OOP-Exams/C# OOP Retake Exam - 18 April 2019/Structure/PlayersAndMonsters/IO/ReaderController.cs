namespace PlayersAndMonsters.IO
{
    using PlayersAndMonsters.IO.Contracts;
    using System;
    public class ReaderController : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
