namespace Ado.Net_Demo
{
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection(Configuretion.connection))
            {
                sqlConnection.Open();
                string createDataBase = "CREATE DATABASE MinionsDB";

                ExecNonQuery(sqlConnection, createDataBase);
            }

            using (var sqlConnection = new SqlConnection(Configuretion.connectionString))
            {
                sqlConnection.Open();
                         
                string[] statments =
                {
                    "create table Countries (id int primary key identity,name varchar(50))",
                    "create table Towns(id int primary key identity,name varchar(50), countrycode int foreign key references countries(id))",
                    "create table Minions(id int primary key identity,name varchar(30), age int, townid int foreign key references towns(id))",
                    "create table Evilnessfactors(id int primary key identity, name varchar(50))",
                    "create table Villains (id int primary key identity, name varchar(50), evilnessfactorid int foreign key references evilnessfactors(id))",
                    "create table Minionsvillains (minionid int foreign key references minions(id),villainid int foreign key references villains(id),constraint pk_minionsvillains primary key (minionid, villainid))"
                };

                foreach (var stat in statments)
                {
                    ExecNonQuery(sqlConnection, stat);
                }

                string[] insertinto =
                {
                    "insert into Countries ([name]) values('bulgaria'),('england'),('cyprus'),('germany'),('norway')",
                    "insert into Towns([name], countrycode) values('plovdiv', 1),('varna', 1),('burgas', 1),('sofia', 1),('london', 2),('southampton', 2),('bath', 2),('liverpool', 2),('berlin', 3),('frankfurt', 3),('oslo', 4)",
                    "insert into minions(name, age, townid) values('bob', 42, 3),('kevin', 1, 1),('bob ', 32, 6),('simon', 45, 3),('cathleen', 11, 2),('carry ', 50, 10),('becky', 125, 5),('mars', 21, 1),('misho', 5, 10),('zoe', 125, 5),('json', 21, 1)",
                    "insert into Evilnessfactors(name) values('super good'),('good'),('bad'), ('evil'),('super evil')",
                    "insert into Villains(name, evilnessfactorid) values('gru', 2),('victor', 1),('jilly', 3),('miro', 4),('rosen', 5),('dimityr', 1),('dobromir', 2)",
                    "insert into Minionsvillains(minionid, villainid) values(4, 2),(1, 1),(5, 7),(3, 5),(2, 6),(11, 5),(8, 4),(9, 7),(7, 1),(1, 3),(7, 3),(5, 3),(4, 3),(1, 2),(2, 1),(2, 7)"
                };

                foreach (var insertinfo in insertinto)
                {
                    ExecNonQuery(sqlConnection, insertinfo);
                }
            }
        }

        private static void ExecNonQuery(SqlConnection sqlConnection, string cmdText)
        {
            using (SqlCommand command = new SqlCommand(cmdText, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

