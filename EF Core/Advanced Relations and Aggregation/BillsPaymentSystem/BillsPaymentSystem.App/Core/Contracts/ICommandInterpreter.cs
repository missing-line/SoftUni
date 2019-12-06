namespace BillsPaymentSystem.App.Core.Contracts
{
    using BillsPaymentSystem.Data;
    public interface ICommandInterpreter
    {
        string Read(string[] args , BillsPlaymentSystemContext context);
    }
}
