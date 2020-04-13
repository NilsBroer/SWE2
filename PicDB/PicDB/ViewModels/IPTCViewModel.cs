using System;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class IPTCViewModel : BaseViewModel
    {
        public IPTCViewModel() { }
        public IPTCViewModel(IPTCModel iptc)
        {
            if (iptc != null)
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

        public String License { get; set; }
        public String PhotographerName { get; set; }
        public String Category { get; set; }
        public bool? IsEdited { get; set; }
        public String KeyWords { get; set; }
        public String Notes { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
