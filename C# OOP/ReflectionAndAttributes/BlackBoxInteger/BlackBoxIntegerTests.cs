namespace BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("BlackBoxInteger.BlackBoxInteger");

            Object instance = Activator.CreateInstance(type, true);

            

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input
                    .Split('_')
                    .ToArray();

                string commandMethod = arr[0];
                int value = int.Parse(arr[1]);

                type.GetMethod(commandMethod, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(instance, new object[] { value });

                var result = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .GetValue(instance);

                Console.WriteLine(result);
            }
        }
    }
}
