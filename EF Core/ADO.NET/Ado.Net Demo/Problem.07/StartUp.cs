namespace Problem._07
{
    using Ado.Net_Demo;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        private static List<string> minionNames = new List<string>();
        public static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add(
                                                (string)reader[0]
                                           );
                        }
                    }
                }
                sqlConnection.Close();
            }
            
            GetCollection(minionNames);
        }

        private static void GetCollection(List<string> minionNames)
        {
            var collection = new List<string>();

            var filteredNames = minionNames
                .Distinct()
                .ToList();

            for (int i = 0; i < filteredNames.Count / 2; i++)
            {
                Console.WriteLine(filteredNames[i]);
                Console.WriteLine(filteredNames[filteredNames.Count - 1 - i]);
                if (i == filteredNames.Count / 2 - 1 && 
                    filteredNames.Count % 2 != 0 )
                {
                    Console.WriteLine(filteredNames[filteredNames.Count - 1 - i - 1]);
                }
            }
        }
    }
}
