namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.App.Core;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            // intputCommand : --->  UserInfo ${setUserId}; ---> PayBill {userId} {amount}; exitCommand ----> End          
            IEngine engine = new Engine();
            engine.Run();



            //// use to Seed data in database
            //using (var context = new BillsPlaymentSystemContext())
            //{
            //    DbInitializer.Seed(context);
            //}
        }
    }
}
