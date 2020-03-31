using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PicDB.Models;
using PicDB.database;

namespace PicDB
{
    class DataAccessLayer
    {
        public PhotographerModel GetPhotographer(int id)
        {
            PhotographerModel pg = new PhotographerModel
            {
                Id = 0
            };

            SqlCommand command = DBSingleton.Create_Command("SELECT Vorname, Nachname, Geburtstag, Notizen FROM Fotografen WHERE Id = @Id;");
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            pg.Id = id;
            pg.Vorname = (string)reader[0];
            pg.Nachname = (string)reader[1];
            pg.Geburtstag = (DateTime)reader[2];

            if (reader[3] is DBNull)
                pg.Notizen = "";
            else
                pg.Notizen = (string)reader[3];


            return pg;
        }

        //public PictureModel GetPicture(int id)
        //{
        //
        //}
    }
}
