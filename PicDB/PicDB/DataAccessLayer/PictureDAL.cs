using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using PicDB.Helper;
using PicDB.Models;

namespace PicDB
{
    sealed partial class DataAccessLayer
    {
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
            int i = 0;
            PictureModel picture = new PictureModel()
            {
                Id = id,
                FileName = reader[i++] is DBNull ? null : (string)reader[i-1],
                FilePath = reader[i++] is DBNull ? null : (string)reader[i-1],
                Photographer = reader[i++] is DBNull ? null : GetPhotographer((int)reader[i-1])
            };

            reader.Close();
            return picture;
        }

        public static List<PictureModel> GetAllPictures()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Pictures");
            SqlDataReader reader = command.ExecuteReader();
            List<PictureModel> pictureList = new List<PictureModel>();

            if (!reader.HasRows)
            {
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    int i = 0;
                    pictureList.Add(new PictureModel()
                    {
                        Id = (int)reader[i++],
                        FileName = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        FilePath = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        Photographer = reader[i++] is DBNull ? null : GetPhotographer((int)reader[i - 1])
                    });
                }

                reader.Close();
            }

            return pictureList;
        }

        public static List<PictureModel> GetPicturesOneParam(String param)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Pictures JOIN IPTC ON (Pictures.Id = IPTC.PictureId) WHERE CHARINDEX(@param,IPTC.PhotographerName) > 0 OR CHARINDEX(@param,IPTC.Category) > 0 OR CHARINDEX(@param,IPTC.KeyWords) > 0");
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = command.ExecuteReader();
            List<PictureModel> pictureList = new List<PictureModel>();

            if (!reader.HasRows)
            {
                reader.Close();
            }
            else 
            {
                while (reader.Read())
                {
                    int i = 0;
                    pictureList.Add(new PictureModel()
                    {
                        Id = (int)reader[i++],
                        FileName = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        FilePath = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        Photographer = reader[i++] is DBNull ? null : GetPhotographer((int)reader[i - 1])
                    });
                }

                reader.Close();
            }
            
            return pictureList;
        }

        public static List<PictureModel> GetPicturesMultipleParams(String[] param)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Pictures JOIN IPTC ON (Pictures.Id = IPTC.PictureId) WHERE 1=1");

            foreach (String i in param)
            {
                command.CommandText = command.CommandText + ($" AND ( CHARINDEX(@{i},IPTC.PhotographerName) > 0 OR CHARINDEX(@{i},IPTC.Category) > 0 OR CHARINDEX(@{i},IPTC.KeyWords) > 0 )");
                command.Parameters.AddWithValue(($"@{i}"), i);
            }

            SqlDataReader reader = command.ExecuteReader();
            List<PictureModel> pictureList = new List<PictureModel>();

            if (!reader.HasRows)
            {
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    int i = 0;
                    pictureList.Add(new PictureModel()
                    {
                        Id = (int)reader[i++],
                        FileName = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        FilePath = reader[i++] is DBNull ? null : (string)reader[i - 1],
                        Photographer = reader[i++] is DBNull ? null : GetPhotographer((int)reader[i - 1])
                    });
                }

                reader.Close();
            }

            return pictureList;
        }

        /*
        public static PictureModel GetFirstPicture()
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
        */
    }
}