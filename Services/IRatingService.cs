using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Payload.RequestDto;

namespace QulixTask.Services
{
    public interface IRatingService
    {
        double GetRatingValue(Guid id);
        void Rate(RateItemDto rateItemDto);
    }
}
