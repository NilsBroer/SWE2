using System;
using System.Data.SqlClient;
using PicDB.Models;
using PicDB.Helper;
using Serilog;

namespace PicDB
{
    ///
    /// MetaData-Part of the DAL. 
    ///
    sealed partial class DataAccessLayer
    {
        ///
        /// Returns the n-th picture's EXIF-Data
        ///
        public static EXIFModel GetEXIF(int pictureId)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM EXIF WHERE PictureID = @Id");
            command.Parameters.AddWithValue("@Id", pictureId);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                Log.Information("EXIF-data for Picture with Id {pictureId} does not exist.", pictureId);
                return null;
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
                Exposure = reader[i++] is DBNull ? null : reader[i - 1].ToString(),
                Iso = reader[i++] is DBNull ? null : (int?)reader[i - 1]
            };

            reader.Close();
            return exif;
        }

        ///
        /// Returns the n-th Picture's IPTC-Data
        ///
        public static IPTCModel GetIPTC(int pictureId)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM IPTC WHERE PictureId = @Id");
            command.Parameters.AddWithValue("@Id", pictureId);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                Log.Information("IPTC-data for Picture with Id {pictureId} does not exist.", pictureId);
                return null;
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

        ///
        /// Saves or Updates new IPTC-Data.
        ///
        public static void SaveIPTC(IPTCModel iptc)
        {
            SqlCommand command;
            var old = GetIPTC(iptc.PictureId);
            if(old != null)
            {
                command = DbHelper.CreateCommand("UPDATE IPTC SET " +
                                                            "License = @license," +
                                                            "PhotographerName = @photographer," +
                                                            "Category = @category," +
                                                            "IsEdited = @edited," +
                                                            "KeyWords = @keyWords," +
                                                            "Notes = @notes," +
                                                            "CreationDate = @date" +
                                                            " WHERE PictureId = @id");
                command.Parameters.AddWithValue("@edited", true);
                
                if (old.CreationDate != null)
                    command.Parameters.AddWithValue("@date", old.CreationDate);
                else
                    command.Parameters.AddWithValue("@date", DateTime.Now);
            }
            else
            {
                command = DbHelper.CreateCommand("INSERT INTO IPTC " +
                                                    "(PictureId, License, PhotographerName, Category, IsEdited, KeyWords, Notes, CreationDate)" +
                                                    " VALUES (@id, @license, @photographer, @category, @edited, @keyWords, @notes, @date)");
                command.Parameters.AddWithValue("@edited", false);
                command.Parameters.AddWithValue("@date", DateTime.Now);
            }
            command.Parameters.AddWithValue("@id", iptc.PictureId);
            command.Parameters.AddWithValue("@license", iptc.License ?? old.License);
            command.Parameters.AddWithValue("@photographer", iptc.PhotographerName ?? old.PhotographerName);
            command.Parameters.AddWithValue("@category", iptc.Category ?? old.Category);
            command.Parameters.AddWithValue("@keyWords", iptc.KeyWords ?? old.KeyWords);
            command.Parameters.AddWithValue("@notes", iptc.Notes ?? old.Notes);

            command.ExecuteNonQuery();
        }
    }
}
