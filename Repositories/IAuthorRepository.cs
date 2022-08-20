using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Repositories
{
    public interface IAuthorRepository
    {
        Author GetAuthor(Guid authorId);
        ICollection<Author> GetAuthors();
        bool CheckAuthorExists(Guid authorId);
        Author Save(Author author);
    }
}
