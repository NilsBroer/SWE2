using System;
using System.Data.SqlClient;
using PicDB.Internal;
using PicDB.Models;

namespace PicDB
{
    static class PhotographerDAL
    {
        public static PhotographerModel GetPhotographer(int id)
        {
            PhotographerModel pg = new PhotographerModel
            {
                Id = 0
            };

            SqlCommand command = DBhelper.Create_Command("SELECT Vorname, Nachname, Geburtstag, Notizen FROM Fotografen WHERE Id = @Id;");
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

            reader.Close();
            return pg;
        }
    }
}