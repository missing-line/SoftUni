namespace TrafficLights
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split()
                 .ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    Type type = Type.GetType($"TrafficLights.{input[j]}");

                    Object instance = Activator
                        .CreateInstance(type, true);

                    var result = type
                        .GetField("color", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(instance);

                    input[j] = result.ToString();
                }
                Print(input);
            }
        }

        private static void Print(string[] input)
        {
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
