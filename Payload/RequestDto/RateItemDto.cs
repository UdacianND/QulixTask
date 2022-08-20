using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Payload.RequestDto
{
    public class RateItemDto
    {
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Range(1,5)]
        public double RatingValue { get; set; }
    }
}
