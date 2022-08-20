using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Repositories;
using QulixTask.Services;

namespace QulixTask.ServiceImp
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public double GetRatingValue(Guid id)
        {
            ICollection<Rate> ratings = ratingRepository.GetRatings(id);
            if (ratings.Count() == 0)
                return 0;
            return ratings.Average(rate => rate.RatingValue);         
        }

        public void Rate(RateItemDto rateItemDto)
        {
            ratingRepository.Save(new Rate(rateItemDto));
        }
    }
}
