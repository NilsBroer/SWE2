using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

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