namespace CreateCustomClassAttribute
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Type classType = Type.GetType("CreateCustomClassAttribute.Weapon");

            var attr = classType.GetCustomAttributes(false);


            foreach (var currAtt in attr)
            {
                var getClassAttr = currAtt as CustomAttribute;

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {getClassAttr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {getClassAttr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {getClassAttr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {string.Join(", ", getClassAttr.Reviewers)}");
                            break;
                    }
                }

            }           
        }
    }
}

