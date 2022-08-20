using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;

namespace QulixTask.Services
{
    public interface IAuthorService
    {
        public ICollection<AuthorDto> GetAuthors();
        Author AddNewAuthor(CreateAuthorDto authorDto);
    }
}
