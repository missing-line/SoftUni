namespace LoggerLibrary
{
    using LoggerLibrary.Core;
    using LoggerLibrary.Core.Interface;

    public class Program
    {      

        public static void Main(string[] args)
        {
            ICommandInterpreter commandinterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandinterpreter);
            engine.Run();
        }
    }
}
