using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PicDB.Helper;
using PicDB.Models;

namespace PicDB
{
    sealed class BusinessLayer
    {
        private static readonly Lazy<BusinessLayer>
            Singleton = new Lazy<BusinessLayer>(() => new BusinessLayer());

        public static BusinessLayer Instance => Singleton.Value;

        private BusinessLayer()
        {

        }

        //Singleton-Source: https://csharpindepth.com/articles/singleton [Type 6]

        public static List<string> GetAllPhotographerNames()
        {
            List<PhotographerModel> photographerList = DataAccessLayer.GetAllPhotographers();
            List<String> photographerNames = new List<string>();

            foreach (var photographer in photographerList)
            {
                photographerNames.Add(photographer.Name + " " + photographer.Surname);
            }

            return photographerNames;
        }

        public static PictureModel GetPicture()
        {
            return DataAccessLayer.GetPicture();
        }

        public static PictureModel GetPicture(int id)
        {
            return DataAccessLayer.GetPicture(id);
        }

        public static List<PictureModel> GetAllPictures()
        {
            return DataAccessLayer.GetAllPictures();
        }

        public static Image PictureToImage(PictureModel picture)
        {
            return new Image()
            {
                Source = new BitmapImage(new Uri(Internal.Path + "/images/" + picture.FilePath + picture.FileName)) //TODO: Handle all possible errors
            };
        }
        public static Image PictureToImage(PictureModel picture, int width, int height)
        {
            return new Image()
            {
                Source = new BitmapImage(new Uri(picture.FilePath + picture.FileName)),
                Height = height,
                Width = width
            };
        }
        
        public static List<Image> PicturesToImages(List<PictureModel> pictureList) 
        {
            List<Image> imageList = new List<Image>();
            foreach (var picture in pictureList)
            {
                imageList.Add(PictureToImage(picture));
            }

            return imageList;
        }

    }
}
