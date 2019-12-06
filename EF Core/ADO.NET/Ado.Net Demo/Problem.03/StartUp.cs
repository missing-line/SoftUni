namespace Problem._03
{
    using Ado.Net_Demo;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();

                int id = int.Parse(Console.ReadLine());

                string sqlQuery = $@"SELECT Name FROM Villains WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    string result = (string)sqlCommand.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {result}");
                }

                string sqlQueryForData = $@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                  m.Name, 
                                                  m.Age
                                            FROM MinionsVillains AS mv
                                            JOIN Minions As m ON mv.MinionId = m.Id
                                            WHERE mv.VillainId = @id
                                            ORDER BY m.Name";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQueryForData, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine($"{(long)reader[0]}. {(string)reader[1]} {(int)reader[2]}");
                        }
                    }
                }
            }
        }
    }
}
