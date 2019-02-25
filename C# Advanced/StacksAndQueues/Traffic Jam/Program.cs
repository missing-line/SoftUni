namespace Traffic_Jam
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string car = Console.ReadLine();

            Queue<string> passed = new Queue<string>();
            Queue<string> waitingGreen = new Queue<string>();

            while (car != "end")
            {
                if (car == "green")
                {
                    int count = 0;
                    while (waitingGreen.Count > 0 && count != n)
                    {
                        count++;
                        string currCar = waitingGreen.Dequeue();
                        passed.Enqueue(currCar);
                        Console.WriteLine($"{currCar} passed!");
                    }
                }
                else
                {
                    waitingGreen.Enqueue(car);
                }
                car = Console.ReadLine();
            }
            Console.WriteLine($"{passed.Count} cars passed the crossroads.");
        }
    }
}
