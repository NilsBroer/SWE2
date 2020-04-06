using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using PicDB.Helper;
using PicDB.Models;

namespace PicDB
{
    static partial class DataAccessLayer
    {
        public static PictureModel GetPicture()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT TOP 1 * FROM Pictures");
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();

            PictureModel picture = new PictureModel()
            {
                Id = (int)reader[0],
                FileName = (string)reader[1],
                FilePath = (string)reader[2],
                Photographer = reader[3] is DBNull ? null : GetPhotographer((int)reader[3])
            };

            reader.Close();
            return picture;
        }
        public static PictureModel GetPicture(int id)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT FileName, FilePath, PhotographerId FROM Pictures WHERE Id = @Id;");
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();

            PictureModel picture = new PictureModel()
            {
                Id = id,
                FileName = (string)reader[0],
                FilePath = (string)reader[1],
                Photographer = reader[2] is DBNull ? null : GetPhotographer((int)reader[2])
            };

            reader.Close();
            return picture;
        }

        public static List<PictureModel> GetAllPictures()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Pictures");
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                CustomException.ThrowNoDataException();
            }

            List<PictureModel> pictureList = new List<PictureModel>();

            while (reader.Read())
            {
                pictureList.Add(new PictureModel()
                {
                    Id = (int)reader[0],
                    FileName = (string)reader[1],
                    FilePath = (string)reader[2],
                    Photographer = reader[3] is DBNull ? null : GetPhotographer((int)reader[3])
                });
            }

            reader.Close();
            return pictureList;
        }

        //Get picture by name and/or path?
    }
}