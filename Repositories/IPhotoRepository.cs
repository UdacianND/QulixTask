using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Repositories
{
    public interface IPhotoRepository
    {
        Photo GetPhoto(Guid id);
        ICollection<Photo> GetPhotos(int pageNumber, int pageSize);
        Photo Save(Photo photo);
        bool CheckPhotoExists(Guid id);
        Photo Update(Photo photo);
    }
}
