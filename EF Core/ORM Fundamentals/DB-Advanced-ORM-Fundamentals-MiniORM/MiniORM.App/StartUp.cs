namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    public class StartUp
    {
        public static void Main()
        {
            string connectionStr = "Server=SWADE\\SQLEXPRESS;DataBase=MiniORM;Integrated Security=True";

            SoftUniDbContext db = new SoftUniDbContext(connectionStr);

            db.Employees.Add(new Employee("MiniORM", "Inserted", db.Departments.First().Id, true));

            Employee employee = db.Employees.Last();
            employee.FirstName = "Modified1";

            db.SaveChanges();
        }
    }
}