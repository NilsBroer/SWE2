﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Documents;
using PicDB.Helper;
using PicDB.Models;
using PicDB.ViewModels;
using Serilog;

namespace PicDB
{
    ///
    /// Photographer-Part of the DAL
    ///
    sealed partial class DataAccessLayer
    {
        ///
        /// Returns the n-th Photographer as a Model.
        ///
        public static PhotographerModel GetPhotographer(int id)
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT Name, Surname, Birthday, Notes FROM Photographers WHERE Id = @Id;");
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                Log.Error("Data for Photographer with Id {id} does not exist.", id);
                return null;
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

        ///
        /// Returns all Photographers as a List 
        ///
        public static List<PhotographerModel> GetAllPhotographers()
        {
            SqlCommand command = DbHelper.CreateCommand("SELECT * FROM Photographers");
            SqlDataReader reader = command.ExecuteReader();
            List<PhotographerModel> photographerList = new List<PhotographerModel>();


            if (!reader.HasRows)
            {
                reader.Close();
                Log.Error("Unable to fetch data for Photographers from DataBase.");
                return /*empty*/ photographerList;
            }

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

        ///
        /// Updates a specific Photographer
        ///
        public static void UpdatePhotographer(PhotographerViewModel vm)
        {
            SqlCommand command;
            
            command = DbHelper.CreateCommand("UPDATE PHOTOGRAPHERS SET " +
                                                        "Name = @name," +
                                                        "Surname = @surname," +
                                                        "Birthday = @birthday," +
                                                        "Notes = @notes" +
                                                        " WHERE Id = @id");

            command.Parameters.AddWithValue("@id", vm.Id);
            command.Parameters.AddWithValue("@surname", vm.Surname);
            command.Parameters.AddWithValue("@name", vm.Name);
            command.Parameters.AddWithValue("@birthday", vm.Birthday ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@notes", vm.Notes ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }

        ///
        /// Creates a new Photographer
        ///
        public static void CreatePhotographer(PhotographerViewModel vm)
        {
            SqlCommand command;

            command = DbHelper.CreateCommand("INSERT INTO PHOTOGRAPHERS " +
                                                "(Name, Surname, Birthday, Notes)" +
                                                " VALUES (@name, @surname, @birthday, @notes)");

            command.Parameters.AddWithValue("@surname", vm.Surname);
            command.Parameters.AddWithValue("@name", vm.Name);
            command.Parameters.AddWithValue("@birthday", vm.Birthday ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@notes", vm.Notes ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }
    }
}