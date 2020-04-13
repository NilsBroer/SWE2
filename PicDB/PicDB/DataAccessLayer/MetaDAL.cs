using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PicDB.Models;
using PicDB.Helper;

namespace PicDB
{
    sealed partial class DataAccessLayer
    {
        public static IPTCModel GetIPTC(int pictureId)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM IPTC WHERE PictureId = @Id;");
            command.Parameters.AddWithValue("@Id", pictureId);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null; //TODO: Handle
            }

            reader.Read();

            int i = 0;
            IPTCModel iptc = new IPTCModel()
            {
                PictureId = (int)reader[i++],
                License = reader[i++] is DBNull ? null : (string)reader[i-1],
                PhotographerName = reader[i++] is DBNull ? null : (string)reader[i-1],
                Category = reader[i++] is DBNull ? null : (string)reader[i-1],
                IsEdited = reader[i++] is DBNull ? null : (bool?)reader[i-1],
                KeyWords = reader[i++] is DBNull ? null : (string)reader[i-1],
                Notes = reader[i++] is DBNull ? null : (string)reader[i-1],
                CreationDate = reader[i++] is DBNull ? null : (DateTime?)reader[i-1]
            };

            reader.Close();
            return iptc;
        }
    }
}
