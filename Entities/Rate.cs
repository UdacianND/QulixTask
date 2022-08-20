using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Payload.RequestDto;

namespace QulixTask.Entities
{
    public class Rate : BaseModel
    {
        public Rate(RateItemDto rateItemDto)
        {
            ItemId = rateItemDto.ItemId;
            UserId = rateItemDto.UserId;
            RatingValue = rateItemDto.RatingValue;
        }
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
        public double RatingValue { get; set; }

    }
}
