namespace Problem._06
{
    using Ado.Net_Demo;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private static int effectedRows = 0;
        private static string name;
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();

                string queryCheckId = @"SELECT Name FROM Villains WHERE Id = @villainId";

                using (SqlCommand sqlCommand = new SqlCommand(queryCheckId, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);

                    name = (string)sqlCommand.ExecuteScalar();

                    if (name == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                string deleteQueryMinionsVillains = @"DELETE FROM MinionsVillains 
                                                      WHERE VillainId = @villainId";

                using (SqlCommand command = new SqlCommand(deleteQueryMinionsVillains, sqlConnection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    effectedRows += command.ExecuteNonQuery();
                }

                string deleteQueryVillains = @"DELETE FROM Villains 
                                             WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(deleteQueryVillains, sqlConnection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    effectedRows += command.ExecuteNonQuery();
                }

                Console.WriteLine($"{name} was deleted.");
                Console.WriteLine($"{effectedRows} minions were released.");
            }
        }
    }
}
