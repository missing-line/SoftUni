namespace Problem._05
{
    using Ado.Net_Demo;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private static List<string> towns = new List<string>();
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();

                string query = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                 WHERE CountryCode = 
                                                    (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int rows = command.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    Console.WriteLine($"{rows} town names were affected. ");
                }

                string getAllTownsQuery = @"SELECT t.Name
                                             FROM Towns as t
                                             JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = @countryName";

                using (SqlCommand sqlCommand = new SqlCommand(getAllTownsQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine("[" + string.Join(", ", towns) + "]");
            }
        }
    }
}
