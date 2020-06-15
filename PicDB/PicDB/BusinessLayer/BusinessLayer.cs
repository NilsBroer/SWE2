using System;
namespace PicDB
{
    ///
    /// Business Layer to mediate between Data and Program
    ///
    sealed partial class BusinessLayer
    {
        ///
        /// Singleton Accessor
        ///
        private static readonly Lazy<BusinessLayer>
            Singleton = new Lazy<BusinessLayer>(() => new BusinessLayer());

        public static BusinessLayer Instance => Singleton.Value;

        private BusinessLayer()
        {
        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
    }
}