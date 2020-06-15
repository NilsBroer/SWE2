using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    ///
    /// Model for the Picture
    ///
    public class PictureModel
    {

        ///
        /// Empty Constructor
        ///
        public PictureModel() { }

        ///
        /// Constructor for certain File
        ///
        public PictureModel(String filename)
        {
            FileName = filename;
        }

        ///
        /// Picture ID
        ///
        public int Id { get; set; }

        ///
        /// Filename
        ///
        public String FileName { get; set; }

        ///
        /// FilePath
        ///
        public String FilePath { get; set; }

        ///
        /// Creator
        ///
        public PhotographerModel Photographer { get; set; }

        ///
        /// Updates this Entry
        ///
        public void Update(PictureViewModel pic)
        {
            Id = pic.Id;
            Photographer = pic.Photographer == null ? null : new PhotographerModel();
            Photographer?.Update(pic.Photographer);
        }
    }
}
