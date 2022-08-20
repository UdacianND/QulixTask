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
    public class TextRepository : ITextRepository
    {
        private readonly IMongoCollection<Text> textCollection;
        private readonly string collectionName = "texts";
        private readonly FilterDefinitionBuilder<Text> filterBuilder = Builders<Text>.Filter;

        public TextRepository(IMongoDatabase database)
        {
            textCollection = database.GetCollection<Text>(collectionName);
        }
        public Text GetText(Guid id)
        {
            var filter = filterBuilder.Eq(text => text.Id, id);
            return textCollection
                    .Find(filter).SingleOrDefault();
        }

        public ICollection<Text> GetTexts(int pageNumber, int pageSize)
        {
            return textCollection
                .Find(new BsonDocument())
                .Skip((pageNumber-1)*pageSize)
                .Limit(pageSize)
                .ToList();
        }

        public Text Save(Text text)
        {
            textCollection.InsertOne(text);
            return text;
        }
    }
}
