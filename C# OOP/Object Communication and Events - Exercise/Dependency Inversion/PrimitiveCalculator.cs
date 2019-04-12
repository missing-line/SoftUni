namespace Dependency
{
    public class PrimitiveCalculator : ICalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            ChangeStrategy(strategy);
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
