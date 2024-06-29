using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace form
{
    public static class DatabaseConnection
    {
        private static string dataSource = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        private static string initialCatalog = "x";
        private static string uid = "x";
        private static string password = "x";

        public static string connectionString = $"Data Source = {dataSource}; Initial Catalog = {initialCatalog}; uid= {uid}; password = {password}";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}