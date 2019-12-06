namespace Problem._08
{
    using Ado.Net_Demo;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            using (SqlConnection sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();

                string query = @"UPDATE Minions
                                 SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                 WHERE Id = @Id";

                for (int i = 0; i < input.Length; i++)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", input[i]);
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                string querySelectorAllMinions = @"SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(querySelectorAllMinions, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }

                sqlConnection.Close();
            }
        }
    }
}
