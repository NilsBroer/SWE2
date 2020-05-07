using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Serilog;
using Serilog.Core;

namespace PicDB.Helper
{
    public sealed class DbHelper
    {
        private static readonly Lazy<DbHelper>
            Singleton = new Lazy<DbHelper>(() => new DbHelper());

        public static DbHelper Instance => Singleton.Value;

        private DbHelper()
        {

        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
        
        public static string ConnectionString = GetConnectionString();
        public static SqlConnection Connection = GetConnection();

        public static string GetConnectionString()
        {
            return
                System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Nils")
                    ? ConfigurationManager.ConnectionStrings["NilsConnectionString"].ConnectionString
                    : ConfigurationManager.ConnectionStrings["ChrisConnectionString"].ConnectionString;
        }

        private static SqlConnection GetConnection()
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public static SqlCommand CreateCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(null, Connection)
            {
                CommandText = commandText
            };

            return command;
        }

        public static DataTable GetDataTable(SqlCommand command)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }
    }
}