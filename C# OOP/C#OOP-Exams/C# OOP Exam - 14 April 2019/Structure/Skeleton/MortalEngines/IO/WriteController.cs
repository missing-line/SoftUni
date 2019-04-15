namespace MortalEngines.IO
{
    using MortalEngines.IO.Contracts;
    using System;
    public class WriteController : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
