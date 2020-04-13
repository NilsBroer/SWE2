using PicDB.Helper;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
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
                Source = new BitmapImage(new Uri(Internal.Path + "/images/" + picture.FilePath + picture.FileName)), //TODO: Handle all possible errors
                Tag = picture.Id
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

        public static Image CloneImage(Image image)
        {
            return new Image()
            {
                Source = image.Source,
                Tag = image.Tag
            };
        }

        public static Image CloneImage(object obj)
        {
            return CloneImage((Image)obj);
        }
    }
}
