namespace LoggerLibrary.Loggers
{
    using LoggerLibrary.Loggers.Contracts;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string msg)
        {
            this.Size += msg.Where(char.IsLetter).Sum(x => x);
        }
    }
}
