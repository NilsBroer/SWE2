using System;
using Serilog.Core;

namespace PicDB
{
    ///
    /// DataAccessLayer is the hub for all things Database related
    ///
    sealed partial class DataAccessLayer
    {
        ///
        /// Singleton implementation
        ///
        private static readonly Lazy<DataAccessLayer>
            Singleton = new Lazy<DataAccessLayer>(() => new DataAccessLayer());

        public static DataAccessLayer Instance => Singleton.Value;

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
    }
}