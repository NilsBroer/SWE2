using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    ///
    /// IPTC-Data Model
    ///
    public class IPTCModel
    {
        ///
        /// ID of the Corresponding Picture
        ///
        public int PictureId { get; set; }

        ///
        /// License Name
        ///
        public String License { get; set; }

        ///
        /// Name of the Creator
        ///
        public String PhotographerName { get; set; }

        ///
        /// Category
        ///
        public String Category { get; set; }

        ///
        /// Bool whether the IPTC Entry has been edited since the last Update
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

        ///
        /// Method to Update an Entry
        ///
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
