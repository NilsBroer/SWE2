using PicDB.Models;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static EXIFModel GetEXIF(int id)
        {
            return DataAccessLayer.GetEXIF(id);
        }

        public static EXIFModel GetEXIF(object obj)
        {
            return GetEXIF((int)obj);
        }

        public static IPTCModel GetIPTC(int id)
        {
            return DataAccessLayer.GetIPTC(id);
        }

        public static IPTCModel GetIPTC(object obj)
        {
            return GetIPTC((int)obj);
        }

        public static void saveIPTC(IPTCModel iptc)
        {
            DataAccessLayer.saveIPTC(iptc);
        }
    }
}
