using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

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
                System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Nils") ?
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB\database\PicDB.mdf'; Integrated Security=True; MultipleActiveResultSets=true; Connect Timeout = 30" :
                @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Chris\source\repos\SWE2\PicDB\PicDB\database\Database1.mdf'; Integrated Security = True; MultipleActiveResultSets=true; Connect Timeout = 30";
        }       //MultipleActiveResultSets=true allows us to use DataReaders in nested functions (and then close them after)

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