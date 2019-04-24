namespace PlayersAndMonsters.IO
{
    using PlayersAndMonsters.IO.Contracts;
    using System;

    public class WriterController : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
