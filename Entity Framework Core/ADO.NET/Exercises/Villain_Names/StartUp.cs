namespace ADO.NET
{
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using VillainNames;

    public static class StartUp
    {
       public static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            string result = GetVillianNameMinionCount(sqlConnection);

            Console.WriteLine(result);
            sqlConnection.Close();
        }

        private static string GetVillianNameMinionCount(SqlConnection sqlConnection)
        {
            var output = new StringBuilder();

            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                              HAVING COUNT(mv.VillainId) > 3 
                            ORDER BY COUNT(mv.VillainId)";

            var cmd = new SqlCommand(query, sqlConnection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                output.AppendLine($"{reader["Name"]} -  " +
                    $"{reader["MinionsCount"]}");
            }
            return output.ToString().Trim();
        }

    }
}
