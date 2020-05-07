using PicDB.Helper;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Serilog;
using EH = PicDB.Helper.ExceptionHandling;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static PictureModel GetPicture(int id)
        {
            return EH.Try(() => DataAccessLayer.GetPicture(id));
        }

        public static List<PictureModel> GetAllPictures()
        {
            return EH.Try(DataAccessLayer.GetAllPictures);
        }

        public static List<PictureModel> GetPicturesOneParam(String param)
        {
            return EH.Try(() => DataAccessLayer.GetPicturesOneParam(param));
        }

        public static List<PictureModel> GetPicturesMultipleParams(String[] param)
        {
            return EH.Try(() => DataAccessLayer.GetPicturesMultipleParams(param));
        }

        public static Image PictureToImage(PictureModel picture)
        {
            try
            {
                return new Image()
                {
                    Source = new BitmapImage(new Uri(Internal.Path + "/images/" + picture.FilePath + picture.FileName)), //TODO: Handle all possible errors
                    Tag = picture.Id
                };
            }
            catch (Exception e)
            {
                Log.Warning("Could not convert Picture(Model) to (System..Media..)Image. Exception: {e}", e);
                return null;
            }
            
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
