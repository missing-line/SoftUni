namespace FestivalManager.Core.IO.Contracts
{
    using System;
    class WriteController : IWriter
    {
        public void Write(string contents)
        {
            Console.WriteLine(contents);
        }

        public void WriteLine(string contents)
        {
            Console.Write(contents);
        }
    }
}
