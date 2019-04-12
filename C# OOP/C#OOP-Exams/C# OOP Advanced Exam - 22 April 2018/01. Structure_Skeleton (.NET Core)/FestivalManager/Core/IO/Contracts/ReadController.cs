namespace FestivalManager.Core.IO.Contracts
{
    using System;
    public class ReadController : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
