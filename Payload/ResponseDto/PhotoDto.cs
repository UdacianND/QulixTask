using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Payload.ResponseDto
{
    public class PhotoDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public double OriginalSize { get; set; }
        public double Cost { get; set; }
        public int NumberOfSales { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string NameOfAuthor { get; set; }
        public string NicknameOfAuthor { get; set; }
        public double Rating { get; set; }

        public PhotoDto(Photo photo, Author author, double ratingValue)
        {
            Name = photo.Name;
            Link = photo.Link;
            OriginalSize = photo.OriginalSize;
            Cost = photo.Cost;
            NumberOfSales = photo.NumberOfSales;
            CreatedDate = photo.CreatedDate;
            NameOfAuthor = author.FirstName;
            NicknameOfAuthor = author.NickName;
            Rating = ratingValue;
        }
    }
}
