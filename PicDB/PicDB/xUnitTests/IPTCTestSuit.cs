using PicDB.Models;
using System;
using Xunit;

namespace PicDB.UnitTests
{
    public class IPTCTestSuit
    {
        enum Id
        {
            Empty = 0,
            Default = 1
        }
        IPTCModel defaultIPTC = new IPTCModel
        {
            PictureId = (int) Id.Default,
            License = "TLicense",
            PhotographerName = "TName",
            Category = "TCategory",
            IsEdited = false,
            KeyWords = "TKeyWord1,TKeyWord",
            Notes = null,
            CreationDate = DateTime.Now
        };

        [Fact]
        public void ItShallReturnNullForNonExistantIPTC()
        {
            var sut = BusinessLayer.GetIPTC(Id.Empty);
            Assert.Null(sut);
        }

        [Fact]
        public void ItShallSaveOrUpdateIPTC()
        {
            BusinessLayer.SaveIPTC(defaultIPTC);
            var sut = BusinessLayer.GetIPTC(Id.Default);
            Assert.Equal(sut,defaultIPTC);
        }

        /*
         *[Fact / Theory]
         *...
         *
         */
    }
}
