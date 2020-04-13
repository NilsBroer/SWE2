

namespace PicDB.Helper
{
    public static class Internal
    {
        public static string Path = GetPath();

        public static string GetPath()
        {
            return
                System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Chris") ?
                @"C:\Users\Chris\source\repos\SWE2\PicDB\PicDB" :
                @"C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB";
        }
    }
}
