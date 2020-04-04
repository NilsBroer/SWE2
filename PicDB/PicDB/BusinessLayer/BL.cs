using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB
{
    sealed class BL
    {
        private static readonly BL _instance = new BL();
        public List<PhotographerModel> Photographers { get; set; } = new List<PhotographerModel>();

        //To not mark type as 'beforefieldinit' we state a static constructor
        //Source: https://csharpindepth.com/articles/singleton [Type 4]
        static BL() { }
        private BL()
        {
            
        }

        public static BL Instance
        {
            get { return _instance; }
        }


    }
}
