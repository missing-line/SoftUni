using AnimalCentre.Core;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
                IEngine engine = new Engine();
                engine.Run();

                      
        }
    }
}
