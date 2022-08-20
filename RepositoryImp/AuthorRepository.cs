using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using QulixTask.Entities;
using QulixTask.Repositories;

namespace QulixTask.RepositoryImp
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> authorCollection;
        private readonly string collectionName = "authors";
        private readonly FilterDefinitionBuilder<Author> filterBuilder = Builders<Author>.Filter;

        public AuthorRepository(IMongoDatabase database)
        {
            authorCollection = database.GetCollection<Author>(collectionName);
        }
        public bool CheckAuthorExists(Guid authorId)
        {
            return !(GetAuthor(authorId) is null);
        }

        public Author GetAuthor(Guid authorId)
        {
            var filter = filterBuilder.Eq(author => author.Id, authorId);
            return authorCollection
                    .Find(filter).SingleOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return authorCollection
                .Find(new BsonDocument())
                .ToList();
        }

        public Author Save(Author author)
        {
            authorCollection.InsertOne(author);
            return author;
        }
    }
}
