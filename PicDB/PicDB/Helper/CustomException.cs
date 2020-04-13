using System;

namespace PicDB.Helper
{
    static class CustomException
    {
        public static void ThrowNoDataException()
        {
            throw new Exception("Could not receive and data from database.");
        }
    }
}