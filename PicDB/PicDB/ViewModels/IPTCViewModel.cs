using System;
using PicDB.Models;

namespace PicDB.ViewModels
{
    ///
    /// IPTC ViewModel
    ///
    public class IPTCViewModel : BaseViewModel
    {
        ///
        /// Empty Constructor
        ///
        public IPTCViewModel() { }

        ///
        /// Constructor for existing Data
        ///
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

        ///
        /// License
        ///
        public String License { get; set; }

        ///
        /// Name of the Photographer
        ///
        public String PhotographerName { get; set; }

        ///
        /// Category
        ///
        public String Category { get; set; }

        ///
        /// Bool whether the IPTC has been Edited since the Last Update
        ///
        public bool? IsEdited { get; set; }

        ///
        /// KeyWords
        ///
        public String KeyWords { get; set; }

        ///
        /// Notes
        ///
        public String Notes { get; set; }

        ///
        /// Date of Creation
        ///
        public DateTime? CreationDate { get; set; }
    }
}
