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
        public static EXIFModel GetEXIF(int pictureId)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM EXIF WHERE PictureID = @Id");
            command.Parameters.AddWithValue("@Id", pictureId);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null; //TODO: Handle
            }

            reader.Read();

            int i = 0;
            EXIFModel exif = new EXIFModel()
            {
                PictureId = (int) reader[i++],
                DateAndTime = reader[i++] is DBNull ? null : (DateTime?)reader[i - 1],
                Orientation = reader[i++] is DBNull ? null : (int?)reader[i - 1],
                FocalLength = new Tuple<float?, float?>(
                    reader[i++] is DBNull ? null : (float?)reader[i - 1],
                    reader[i++] is DBNull ? null : (float?)reader[i - 1]),
                FNumber = reader[i++] is DBNull ? null : (float?)reader[i - 1],
                Exposure = reader[i++] is DBNull ? null : (string)reader[i - 1],
                Iso = reader[i++] is DBNull ? null : (int?)reader[i - 1]
            };

            reader.Close();
            return exif;
        }
        public static IPTCModel GetIPTC(int pictureId)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM IPTC WHERE PictureId = @Id");
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

        public static void saveIPTC(IPTCModel iptc)
        {
            throw new NotImplementedException();
        }
    }
}
