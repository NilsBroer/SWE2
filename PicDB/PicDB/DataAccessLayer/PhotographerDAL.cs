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
        public static PhotographerModel GetPhotographer(int id)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT Name, Surname, Birthday, Notes FROM Photographers WHERE Id = @Id;");
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                CustomException.ThrowNoDataException();
            }

            reader.Read();

            int i = 0;
            PhotographerModel photographer = new PhotographerModel
            {
                Id = id,
                Name = reader[i++] is DBNull ? null : (string)reader[i-1],
                Surname = reader[i++] is DBNull ? null : (string)reader[i-1],
                Birthday = reader[i++] is DBNull ? null : (DateTime?)reader[i-1],
                Notes = reader[i++] is DBNull ? null : (string)reader[i-1]
            };

            reader.Close();
            return photographer;
        }

        public static List<PhotographerModel> GetAllPhotographers()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Photographers");
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                CustomException.ThrowNoDataException();
            }

            List<PhotographerModel> photographerList = new List<PhotographerModel>();

            while (reader.Read())
            {
                int i = 0;
                photographerList.Add(new PhotographerModel()
                {
                    Id = (int)reader[i++],
                    Name = reader[i++] is DBNull ? null : (string)reader[i-1],
                    Surname = reader[i++] is DBNull ? null : (string)reader[i-1],
                    Birthday = reader[i++] is DBNull ? null : (DateTime?)reader[i-1],
                    Notes = reader[i++] is DBNull ? null : (string)reader[i-1]
                });
            }

            reader.Close();
            return photographerList;
        }
    }
}