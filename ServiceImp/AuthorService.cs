using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;
using QulixTask.Repositories;
using QulixTask.Services;

namespace QulixTask.ServiceImp
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public Author AddNewAuthor(CreateAuthorDto authorDto)
        {
            return authorRepository.Save(authorDto.ToAuthor());
        }

        public ICollection<AuthorDto> GetAuthors()
        {
            return authorRepository.GetAuthors()
                .Select(author => author.ToAuthorDto()).ToList();
        }
    }
}
