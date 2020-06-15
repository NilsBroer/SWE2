using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PicDB.Helper
{
    ///
    /// Various Helper Methods for Database Access
    ///
    public sealed class DbHelper
    {
        public static readonly Lazy<DbHelper>
            Singleton = new Lazy<DbHelper>(() => new DbHelper());

        public static DbHelper Instance => Singleton.Value;

        private DbHelper()
        {

        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
        
        public static string ConnectionString = GetConnectionString();
        public static SqlConnection Connection = GetConnection();

        ///
        /// Gets either Chris' or Nils' File Path to the Database from a ConfigFile
        ///
        public static string GetConnectionString()
        {
            return
                System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Nils")
                    ? ConfigurationManager.ConnectionStrings["NilsConnectionString"].ConnectionString
                    : ConfigurationManager.ConnectionStrings["ChrisConnectionString"].ConnectionString;
        }

        ///
        /// Gets the Connection to the Database
        ///
        private static SqlConnection GetConnection()
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        ///
        /// Builds SQL Commands for better readability in the Code
        ///
        public static SqlCommand CreateCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(null, Connection)
            {
                CommandText = commandText
            };

            return command;
        }

        ///
        /// Returns a Table from a Query
        ///
        public static DataTable GetDataTable(SqlCommand command)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }
    }
}