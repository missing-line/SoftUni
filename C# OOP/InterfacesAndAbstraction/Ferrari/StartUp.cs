namespace Ferrari
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Ferrari ferrari = new Ferrari(name);

            Console.WriteLine(ferrari);
        }
    }
}
