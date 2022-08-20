using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Payload.ResponseDto
{
    public class TextDto
    {
        public TextDto(Text text, Author author, double ratingValue)
        {
            Name = text.Name;
            Content = text.Content;
            Cost = text.Cost;
            NumberOfSales = text.NumberOfSales;
            CreatedDate = text.CreatedDate;
            NameOfAuthor = author.FirstName;
            NicknameOfAuthor = author.NickName;
            Rating = ratingValue;

        }

        public string Name { get; set; }
        public string Content { get; set; }
        public double Cost { get; set; }
        public int NumberOfSales { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string NameOfAuthor { get; set; }
        public string NicknameOfAuthor { get; set; }
        public double Rating { get; set; }
    }
}
