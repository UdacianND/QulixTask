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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMongoCollection<Photo> photoCollection;
        private readonly string collectionName = "photos";
        private readonly FilterDefinitionBuilder<Photo> filterBuilder = Builders<Photo>.Filter;

        public PhotoRepository(IMongoDatabase database)
        {
            photoCollection = database.GetCollection<Photo>(collectionName);
        }
        public bool CheckPhotoExists(Guid id)
        {
            return !(GetPhoto(id) is null);
        }

        public Photo GetPhoto(Guid id)
        {
            var filter = filterBuilder.Eq(photo => photo.Id, id);
            return photoCollection
                    .Find(filter).SingleOrDefault();
        }

        public ICollection<Photo> GetPhotos(int pageNumber, int pageSize)
        {
            return photoCollection
                .Find(new BsonDocument())
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToList();
        }

        public Photo Save(Photo photo)
        {
            photoCollection.InsertOne(photo);
            return photo;
        }

        public Photo Update(Photo photo)
        {
            var filter = filterBuilder.Eq(existingPhoto => existingPhoto.Id, photo.Id);
            photoCollection.ReplaceOne(filter, photo);
            return photo;
        }
    }
}
