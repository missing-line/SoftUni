namespace Problem._04
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

                var minionInfo = Console.ReadLine()
                    .Split(' ');
               
                string minionName = minionInfo[1];
                int age = int.Parse(minionInfo[2]);
                string town = minionInfo[3];

                var villainInfo = Console.ReadLine()
                    .Split(' ');

                string nameOfEvel = villainInfo[1];

                string query = @"SELECT Id FROM Towns WHERE Name = @townName";

                int? townId = GetTownId(sqlConnection, town, query);          

                int? evelId = GetEvelId(sqlConnection, nameOfEvel);

                int? minionId = GetMinionId(sqlConnection, minionName, age, townId);

                InsertToMinionsVillains(sqlConnection, evelId, minionId, minionName, nameOfEvel);
            }

        }     

        private static void InsertToMinionsVillains(SqlConnection sqlConnection, int? evelId, int? minionId, string minionName, string nameOfEvel)
        {
            string query = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@villainId", evelId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();            
            }
            Console.WriteLine($"Successfully added {minionName} to be minion of {nameOfEvel}.");
        }

        private static int? GetMinionId(SqlConnection sqlConnection, string minionName, int age, int? townId)
        {
            string query = @"SELECT Id FROM Minions WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", minionName);

                int? minionId = (int)command.ExecuteScalar();          
                if (minionId == null)
                {
                    InsertMinion(sqlConnection, minionName, age, townId);
                    minionId = (int?)command.ExecuteScalar();
                }

                return minionId;
            }
        }    

        private static int? GetEvelId(SqlConnection sqlConnection, string nameOfEvel)
        {
            string query = @"SELECT Id FROM Villains WHERE Name = @nameOfEvel";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@nameOfEvel", nameOfEvel);
                int? evelId = (int?)command.ExecuteScalar();
                if (evelId == null)
                {
                    InsertEvel(sqlConnection, nameOfEvel);
                    evelId = (int?)command.ExecuteScalar();
                }               
                return evelId;
            }
            
        }

        private static void InsertEvel(SqlConnection sqlConnection, string villainName)
        {
            string query = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@villainName", @villainName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static void InsertMinion(SqlConnection sqlConnection, string minionName, int age, int? townId)
        {
            string query = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@name",minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }
        }

        private static int? GetTownId(SqlConnection sqlConnection, string town, string query)
        {
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@townName", town);
                int? townId = (int?)command.ExecuteScalar();
                if (townId == null)
                {
                    InsertTown(sqlConnection, town);
                    townId = (int?)command.ExecuteScalar();
                }
               
                return townId;
            }
        }

        private static void InsertTown(SqlConnection sqlConnection, string town)
        {
            string query = @"INSERT INTO Towns (Name) VALUES (@townName)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@townName", town);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Town {town} was added to the database.");
        }
    }
}
