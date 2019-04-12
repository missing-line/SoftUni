namespace Crossroads
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int timeOnGreen = int.Parse(Console.ReadLine());

            int freeWindow = int.Parse(Console.ReadLine());

            string command;

            Queue<string> queue = new Queue<string>();
            int crossTheRoad = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                    continue;
                }

                int greenLight = timeOnGreen;
                int extraSeconds = freeWindow;

                string passingCar = null;
                while (greenLight > 0 && queue.Any())
                {
                    passingCar = queue.Dequeue();
                    greenLight -= passingCar.Length;
                    crossTheRoad++;
                }

                int freeWindowLeft = freeWindow + greenLight;
                if (freeWindowLeft < 0)
                {
                    int symbolsThatDidntPass = Math.Abs(freeWindowLeft);
                    int indexOfHitSymbol = passingCar.Length - symbolsThatDidntPass;
                    char symbolHit = passingCar[indexOfHitSymbol];
                    Crash(passingCar, symbolHit);
                }


            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{crossTheRoad} total cars passed the crossroads.");
        }

        private static void Crash(string car, char symbolHit)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {symbolHit}.");
            Environment.Exit(0);
        }
    }
}
