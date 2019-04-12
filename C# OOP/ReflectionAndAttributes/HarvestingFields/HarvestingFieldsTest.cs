namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    public class HarvestingFieldsTest
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                Type type = Type.GetType("HarvestingFields.HarvestingFields");

                FieldInfo[] fieldInfos = type.GetFields
                    (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                if (input == "protected")
                {

                    foreach (FieldInfo field in fieldInfos.Where(x => x.IsFamily))
                    {

                        Console.WriteLine($"{GetModifier(field)} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "private")
                {
                    foreach (FieldInfo field in fieldInfos.Where(x => x.IsPrivate))
                    {

                        Console.WriteLine($"{GetModifier(field)} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "public")
                {
                    foreach (FieldInfo field in fieldInfos.Where(x => x.IsPublic))
                    {

                        Console.WriteLine($"{GetModifier(field)} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (input == "all")
                {
                    foreach (FieldInfo field in fieldInfos)
                    {

                        Console.WriteLine($"{GetModifier(field)} {field.FieldType.Name} {field.Name}");
                    }
                }
            }
        }

        private static string GetModifier(FieldInfo field)
        {
            string accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";

            return accessModifier;
        }
    }
}
