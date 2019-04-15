namespace MortalEngines.IO
{
    using MortalEngines.IO.Contracts;
    using System;
    public class ReadController : IReader
    {       
        public string ReadCommands()
        {
           return  Console.ReadLine();           
        }
    }
}
