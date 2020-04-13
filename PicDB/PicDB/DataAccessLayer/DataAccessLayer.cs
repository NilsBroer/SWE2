using System;

namespace PicDB
{
    sealed partial class DataAccessLayer
    {
        private static readonly Lazy<DataAccessLayer>
            Singleton = new Lazy<DataAccessLayer>(() => new DataAccessLayer());

        public static DataAccessLayer Instance => Singleton.Value;

        private DataAccessLayer()
        {

        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
    }
}