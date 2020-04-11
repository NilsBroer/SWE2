using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    public class PictureModel
    {

        //Should we even save the Path in the Database? Not like it's the same for every user
        public PictureModel() { }
        public PictureModel(String filename)
        {
            FileName = filename;
        }

        public int Id { get; set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }
        public PhotographerModel Photographer { get; set; }
        
        //Not in DB:
        public EXIFModel Exif { get; set; }
        public IPTCModel Iptc { get; set; }

        public void Update(PictureViewModel pic)
        {
            Id = pic.Id;
            FileName = pic.FileName;
            FilePath = pic.FilePath;
            Photographer = pic.Photographer == null ? null : new PhotographerModel();
            Photographer?.Update(pic.Photographer);
            Iptc = pic.Iptc == null ? null : new IPTCModel();
            Iptc?.Update(pic.Iptc);
        }
    }
}
