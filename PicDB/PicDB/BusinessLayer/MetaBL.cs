using PicDB.Models;
using EH = PicDB.Helper.ExceptionHandling;

namespace PicDB
{
    ///
    /// MetaData-Part of the BL
    ///
    sealed partial class BusinessLayer
    {
        ///
        /// Returns the EXIF-Data of the n-th Database Entry
        ///
        public static EXIFModel GetEXIF(int id)
        {
            return EH.Try<EXIFModel>(() => DataAccessLayer.GetEXIF(id));
        }

        ///
        /// Generic Version of the GetEXIF Method
        ///
        public static EXIFModel GetEXIF(object obj)
        {
            return GetEXIF((int)obj);
        }

        ///
        /// Returns the IPTC Data of the n-th Database Entry
        ///
        public static IPTCModel GetIPTC(int id)
        {
            return EH.Try<IPTCModel>(() => DataAccessLayer.GetIPTC(id));
        }

        ///
        /// Generic Version of the GetIPTC Method
        ///
        public static IPTCModel GetIPTC(object obj)
        {
            return GetIPTC((int)obj);
        }

        ///
        /// Updates the IPTC Model in the Database
        ///
        public static void SaveIPTC(IPTCModel iptc)
        {
            DataAccessLayer.SaveIPTC(iptc);
        }
    }
}
