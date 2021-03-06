﻿

using System.Configuration;
using Serilog;

namespace PicDB.Helper
{
    ///
    /// Class for Internal Information
    ///
    public static class Internal
    {
        public static string Path = GetPath();

        ///
        /// Returns Path towards the project Folder
        ///
        public static string GetPath()
        {
            return
                System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Chris") ?
                @"C:\Users\Chris\source\repos\SWE2\PicDB\PicDB" :
                @"C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB";
        }
    }
}
