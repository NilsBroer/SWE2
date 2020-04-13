using System;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        private static readonly Lazy<BusinessLayer>
            Singleton = new Lazy<BusinessLayer>(() => new BusinessLayer());

        public static BusinessLayer Instance => Singleton.Value;

        private BusinessLayer()
        {

        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]
    }
}
