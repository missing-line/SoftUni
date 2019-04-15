namespace MortalEngines
{
    using MortalEngines.Core;
    using MortalEngines.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine =  new Engine();
            engine.Run();
        }
    }
}