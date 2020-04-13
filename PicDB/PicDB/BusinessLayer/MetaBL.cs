using PicDB.Models;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static IPTCModel GetIPTC(int id)
        {
            return DataAccessLayer.GetIPTC(id);
        }

        public static IPTCModel GetIPTC(object obj)
        {
            return GetIPTC((int)obj);
        }
    }
}
