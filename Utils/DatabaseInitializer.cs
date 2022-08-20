using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Repositories;

namespace QulixTask.Utils
{
    public class DatabaseInitializer
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ITextRepository textRepository;
        public DatabaseInitializer(
            IPhotoRepository photoRepository,
            IAuthorRepository authorRepository,
            ITextRepository textRepository)
        {
            this.authorRepository = authorRepository;
            this.photoRepository = photoRepository;
            this.textRepository = textRepository;
        }

        public void Initialize()
        {
            Author author = new Author
            {
                FirstName = "Aziz",
                LastName = "Habibov",
                NickName = "IbnHamid",
                BirthDate = DateTimeOffset.Parse("2002-01-16")
            };

            Photo photo = new Photo
            {
                Name = "Himalay",
                Link = "www.blahblah.com/himalay.jpg",
                AuthorId = author.Id,
                OriginalSize = 100000,
                Cost = 100
            };

            CreateTextDto textDto = new CreateTextDto
            {
                Name = "quote",
                Content = "Life is beautiful",
                AuthorId = author.Id,
                Cost = 10
            };

            authorRepository.Save(author);
            photoRepository.Save(photo);
            textRepository.Save(new Text(textDto));
        }
    }
}
