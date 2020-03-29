using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PicDB.database
{
    public static class DBhelper
    {

        private static string Connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB\database\Database1.mdf'; Integrated Security = True; Connect Timeout = 30";

        public static SqlConnection Connection = Get_Connection();
        public static SqlConnection Get_Connection()
        {
            SqlConnection connection = new SqlConnection(Connection_String);
            if(connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public static SqlCommand Create_Command(string _CommandText)
        {
            SqlCommand command = new SqlCommand(null, Connection)
            {
                CommandText = _CommandText
            };

            return command;
        }

        public static DataTable Get_DataTable(SqlCommand _Command)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(_Command);
            adapter.Fill(table);

            return table;
        }
    }
}