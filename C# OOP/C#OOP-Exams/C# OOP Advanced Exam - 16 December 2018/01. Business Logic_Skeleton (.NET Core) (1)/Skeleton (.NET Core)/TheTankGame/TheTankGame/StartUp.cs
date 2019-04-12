namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using TheTankGame.IO;
    using TheTankGame.IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IManager manager = new TankManager();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);
            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}
