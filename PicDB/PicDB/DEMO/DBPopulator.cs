﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PicDB.Helper;
using Serilog;

namespace PicDB.DEMO
{
    ///
    /// Helper to Populate the Database
    ///
    public static class DbPopulator
    {
        ///
        /// Inserts all Pokemon
        ///
        public static void InsertDemoImages(string path, string pattern)
        {
            List<string> fileNames = new List<string>(System.IO.Directory.EnumerateFiles(path,pattern));
            foreach (string fileName in fileNames)
            {
                var filepath = "/pokemon/";
                var filename = fileName.Substring(fileName.Length - "000.png".Length);
                SqlCommand command = DbHelper.CreateCommand("INSERT INTO Pictures (FileName,FilePath) values (@filename, @filepath)");
                command.Parameters.AddWithValue("@filepath", filepath);
                command.Parameters.AddWithValue("@filename", filename);
                command.ExecuteNonQuery();
            }
        }

        //USAGE: DEMO.DbPopulator.InsertDemoImages(Path + "/images/pokemon/","*.png");
        
    }
}