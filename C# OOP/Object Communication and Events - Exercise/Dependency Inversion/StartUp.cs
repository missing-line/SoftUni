namespace Dependency
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICalculator primitiveCalculator = new PrimitiveCalculator(new AdditionStrategy());

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split()
                    .ToArray();

                if (tokens[0] == "mode")
                {
                    char operand = char.Parse(tokens[1]);
                    switch (operand)
                    {
                        case '+':
                            primitiveCalculator.ChangeStrategy(new AdditionStrategy());
                            break;
                        case '-':
                            primitiveCalculator.ChangeStrategy(new SubtractionStrategy());
                            break;
                        case '*':
                            primitiveCalculator.ChangeStrategy(new MultiplicationStrategy());
                            break;
                        case '/':
                            primitiveCalculator.ChangeStrategy(new DivisionStrategy());
                            break;
                        default:
                            break;
                    }
                   
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int secondOperand = int.Parse(tokens[1]);
                    int result = primitiveCalculator.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
