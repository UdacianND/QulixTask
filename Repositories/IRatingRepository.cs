using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Repositories
{
    public interface IRatingRepository
    {
        public ICollection<Rate> GetRatings(Guid itemId);
        void Save(Rate rate);
    }
}
