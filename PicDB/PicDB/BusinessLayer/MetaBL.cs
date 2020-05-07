using PicDB.Models;
using EH = PicDB.Helper.ExceptionHandling;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static EXIFModel GetEXIF(int id)
        {
            return EH.Try<EXIFModel>(() => DataAccessLayer.GetEXIF(id));
        }

        public static EXIFModel GetEXIF(object obj)
        {
            return GetEXIF((int)obj);
        }

        public static IPTCModel GetIPTC(int id)
        {
            return EH.Try<IPTCModel>(() => DataAccessLayer.GetIPTC(id));
        }

        public static IPTCModel GetIPTC(object obj)
        {
            return GetIPTC((int)obj);
        }

        public static void SaveIPTC(IPTCModel iptc)
        {
            EH.Try(() => DataAccessLayer.SaveIPTC(iptc));
        }
    }
}
