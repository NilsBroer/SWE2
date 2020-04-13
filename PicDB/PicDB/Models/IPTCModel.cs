using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    public class IPTCModel
    {
        public int PictureId { get; set; }
        public String License { get; set; }
        public String PhotographerName { get; set; }
        public String Category { get; set; }
        public bool? IsEdited { get; set; }
        public String KeyWords { get; set; }
        public String Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public void Update(IPTCViewModel iptc)
        {
            License = iptc.License;
            PhotographerName = iptc.PhotographerName;
            Category = iptc.Category;
            IsEdited = iptc.IsEdited;
            KeyWords = iptc.KeyWords;
            Notes = iptc.Notes;
            CreationDate = iptc.CreationDate;
        }
    }
}
