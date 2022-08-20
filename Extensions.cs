using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;

namespace QulixTask
{
    public static class Extensions
    {
        public static AuthorDto ToAuthorDto(this Author author)
        {
            return new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                NickName = author.NickName
            };
        } 
        
        public static Photo ToPhoto(this CreatePhotoDto photoDto)
        {
            return new Photo
            {
                Name = photoDto.Name,
                Link = photoDto.Link,
                AuthorId = photoDto.AuthorId,
                OriginalSize = photoDto.OriginalSize,
                Cost = photoDto.Cost,
                NumberOfSales = 0
            };
        }
        public static Author ToAuthor(this CreateAuthorDto authorDto)
        {
            return new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                NickName = authorDto.NickName,
                BirthDate = authorDto.BirthDate
            };
        }
    }
}
