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
    public class RatingRepository : IRatingRepository
    {
        private readonly IMongoCollection<Rate> ratingCollection;
        private readonly string collectionName = "ratings";
        private readonly FilterDefinitionBuilder<Rate> filterBuilder = Builders<Rate>.Filter;
        public RatingRepository(IMongoDatabase database)
        {
            ratingCollection = database.GetCollection<Rate>(collectionName);
        }
        public ICollection<Rate> GetRatings(Guid itemId)
        {
            var filter = filterBuilder.Eq(rate => rate.ItemId, itemId);
            return ratingCollection
                    .Find(filter)
                    .ToList();
        }

        public void Save(Rate rate)
        {
            ratingCollection.InsertOne(rate);
        }
    }
}
