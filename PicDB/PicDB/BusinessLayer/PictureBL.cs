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
    ///
    /// Picture-Part of the BusinessLayer. Calls the DAL. Also handles Picture-Reports
    ///
    sealed partial class BusinessLayer
    {
        ///
        /// Gets the n-th Picture.
        ///
        public static PictureModel GetPicture(int id)
        {
            return EH.Try(() => DataAccessLayer.GetPicture(id));
        }

        ///
        /// Returns a List of all Pictures
        ///
        public static List<PictureModel> GetAllPictures()
        {
            return EH.Try(DataAccessLayer.GetAllPictures);
        }

        ///
        /// Returns a List of all Pictures including one Search Term
        ///
        public static List<PictureModel> GetPicturesOneParam(String param)
        {
            return EH.Try(() => DataAccessLayer.GetPicturesOneParam(param));
        }

        public static void GetReportOneParam(String param)
        {
            EH.Try(() => DataAccessLayer.GetReportOneParam(param));
        }

        ///
        /// Returns a List of all Pictures including multiple Search Terms
        ///
        public static List<PictureModel> GetPicturesMultipleParams(String[] param)
        {
            return EH.Try(() => DataAccessLayer.GetPicturesMultipleParams(param));
        }

        public static void GetReportMultipleParams(String[] param)
        {
            EH.Try(() => DataAccessLayer.GetReportMultipleParams(param));
        }

        ///
        /// Converts a PictureModel to the Image Type.
        ///
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

        ///
        /// Converts a List of Pictures to a List of Images
        ///
        public static List<Image> PicturesToImages(List<PictureModel> pictureList)
        {
            List<Image> imageList = new List<Image>();
            foreach (var picture in pictureList)
            {
                imageList.Add(PictureToImage(picture));
            }

            return imageList;
        }

        ///
        /// Clones an Image
        ///
        public static Image CloneImage(Image image)
        {
            return new Image()
            {
                Source = image.Source,
                Tag = image.Tag
            };
        }

        ///
        /// Generic version for the CloneImage-Method
        ///
        public static Image CloneImage(object obj)
        {
            return CloneImage((Image)obj);
        }
    }
}
