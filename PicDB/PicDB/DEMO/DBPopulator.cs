using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PicDB.DEMO
{
    public static class DBPopulator
    {
        //Overhauled since we are not going to save actual images to the database, as it is bad practice
        /*
        public static void InsertImagesIntoDB(string path, string pattern)
        {
            List<string> fileNames = new List<string>(System.IO.Directory.EnumerateFiles(path,pattern));
            foreach (string fileName in fileNames)
            {
                byte[] img = ImageToStream(fileName);
                SqlCommand Command = database.DBhelper.Create_Command("INSERT INTO Bilder (Picture) values (@img)");
                Command.Parameters.AddWithValue("@img", img);
                Command.ExecuteNonQuery();
            }
        }

        private static byte[] ImageToStream(string fileName)
        {
            MemoryStream stream = new MemoryStream();

            try
            {
                BitmapImage image = new BitmapImage(new Uri(fileName));
                return stream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //USAGE: DEMO.DbPopulator.InsertImagesIntoDB(Path + "/images/pokemon/","*.png");
        */
    }
}