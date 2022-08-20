using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;

namespace QulixTask.Services
{
    public interface IPhotoService
    {
        ICollection<PhotoDto> GetPhotos(int pageNumber, int pageSize);
        PhotoDto GetPhoto(Guid id);
        void UpdatePhoto(Guid id, UpdatePhotoDto photoDto);
        void RatePhoto(RateItemDto rateItemDto);
        Photo CreatePhoto(CreatePhotoDto photoDto);
        public PhotoDto ConvertToDto(Photo photo);
    }
}
