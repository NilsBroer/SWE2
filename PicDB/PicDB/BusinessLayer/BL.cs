using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB
{
    sealed class BusinessLayer
    {
        private static readonly BusinessLayer _instance = new BusinessLayer();
        public List<PhotographerModel> Photographers { get; set; } = new List<PhotographerModel>();

        //To not mark type as 'beforefieldinit' we state a static constructor
        //Source: https://csharpindepth.com/articles/singleton [Type 4]
        static BusinessLayer() { }
        private BusinessLayer()
        {
            
        }

        public static BusinessLayer Instance
        {
            get { return _instance; }
        }


    }
}
