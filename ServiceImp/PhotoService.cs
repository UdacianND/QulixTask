using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;
using QulixTask.Entities;
using QulixTask.Exceptions;
using QulixTask.Services;
using QulixTask.Repositories;

namespace QulixTask.ServiceImp
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IRatingService ratingService;
        public PhotoService(
            IPhotoRepository photoRepository, 
            IAuthorRepository authorRepository,
            IRatingService ratingService)
        {
            this.photoRepository = photoRepository;
            this.authorRepository = authorRepository;
            this.ratingService = ratingService;         
        }
        public PhotoDto GetPhoto(Guid id)
        {
            return ConvertToDto(photoRepository.GetPhoto(id));
        }

        public ICollection<PhotoDto> GetPhotos(int pageNumber, int pageSize)
        {
            return photoRepository.GetPhotos(pageNumber, pageSize)
                .Select(photo => ConvertToDto(photo)).ToList();
        }

        public void RatePhoto(RateItemDto rateItemDto)
        {
            bool photoExists = photoRepository.CheckPhotoExists(rateItemDto.ItemId);
            if (!photoExists)
                throw new ItemNotFoundException();
            ratingService.Rate(rateItemDto);
        }

        public void UpdatePhoto(Guid id, UpdatePhotoDto photoDto)
        {
            Photo photo = photoRepository.GetPhoto(id);
            photo.Name = photoDto.Name;
            photo.Cost = photoDto.Cost;
            photo.Link = photoDto.Link;
            photoRepository.Update(photo);
        }

        public PhotoDto ConvertToDto(Photo photo)
        {
            if (photo is null)
                return null;
            Author author = authorRepository.GetAuthor(photo.AuthorId);
            double ratingValue = ratingService.GetRatingValue(photo.Id);
            return new PhotoDto(photo, author,ratingValue);
        }

        public Photo CreatePhoto(CreatePhotoDto photoDto)
        {
            bool authorExists = authorRepository.CheckAuthorExists(photoDto.AuthorId);
            if (!authorExists)
                throw new AuthorNotFoundException();
            return photoRepository.Save(photoDto.ToPhoto());
        }
    }
}
