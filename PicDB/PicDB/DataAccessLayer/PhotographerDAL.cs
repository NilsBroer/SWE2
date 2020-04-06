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
        public static PhotographerModel GetPhotographer(int id)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT Name, Surname, Birthday, Notes FROM Photographers WHERE Id = @Id;"); //TODO: Cut time from Birthday
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                CustomException.ThrowNoDataException();
            }

            reader.Read();

            PhotographerModel photographer = new PhotographerModel
            {
                Id = id,
                Name = (string)reader[0],
                Surname = (string)reader[1],
                Birthday = reader[2] is DBNull ? null : (DateTime?)reader[2],
                Notes = reader[3] is DBNull ? null : (string)reader[3]
            };

            reader.Close();
            return photographer;
        }

        public static List<PhotographerModel> GetAllPhotographers()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Photographers"); //TODO: Cut time from Birthday
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                CustomException.ThrowNoDataException();
            }

            List<PhotographerModel> photographerList = new List<PhotographerModel>();

            while (reader.Read())
            {
                photographerList.Add(new PhotographerModel()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Surname = (string)reader[2],
                    Birthday = reader[3] is DBNull ? null : (DateTime?)reader[3],
                    Notes = reader[4] is DBNull ? null : (string)reader[4]
                });
            }

            reader.Close();
            return photographerList;
        }
    }
}