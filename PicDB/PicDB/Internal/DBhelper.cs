using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PicDB.Internal
{
    public sealed class DBhelper
    {
        private static readonly DBhelper _instance = new DBhelper();

        private static string Connection_String_Nils =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB\database\PicDB.mdf'; Integrated Security=True; Connect Timeout = 30";
        private static string Connection_String_Chris =
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Chris\source\repos\SWE2\PicDB\PicDB\database\Database1.mdf'; Integrated Security = True; Connect Timeout = 30";

        //To not mark type as 'beforefieldinit' we state a static constructor
        //Source: https://csharpindepth.com/articles/singleton [Type 4]
        static DBhelper() { }
        private DBhelper() { }
        public static DBhelper Instance
        {
            get { return _instance; }
        }

        public static SqlConnection Connection = Get_Connection();
        private static SqlConnection Get_Connection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Connection_String_Nils);
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return connection;

            }
            catch (Exception e1)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(Connection_String_Chris);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    return connection;
                }
                catch (Exception e2)
                {
                    Console.WriteLine("SqlConnectionErrors for both possible paths: \n" + e1 + "\n" + e2);
                    throw;
                }
                
            }
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